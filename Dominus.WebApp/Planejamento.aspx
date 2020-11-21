<%@ Page Title="Planejamento" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Planejamento.aspx.cs" Inherits="Dominus.WebApp.Planejamento" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="Contents/lib/jquery-mask-plugin/jquery.mask.js"></script>
    <script src="Contents/lib/chartjs/Chart.min.js"></script>
    <script src="Contents/js/dominus-chart.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script src="Contents/js/planejamento.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script type="text/javascript">
        window._planejamentos = <%: new HtmlString(GetPlanejamentos()) %>;
        window._categorias = <%: new HtmlString(GetCategorias()) %>;
        window._dataPeriodo = '<%: new HtmlString(GetInicioPeriodo()) %>';

        function validarForm(button) {
            var msg = document.getElementById("<%=lblMsg.ClientID %>");
            msg.textContent = '';

            var valor = document.getElementById("<%=txtValor.ClientID %>");

            if (!valor.validity.valid) {
                return false;
            }

            $('#loading')[0].hidden = false;
            setTimeout(function () { button.disabled = true; }, 100);
            return true;
        }

        function removerPlanejamento(button) {
            $('#loadingRemover')[0].hidden = false;
            setTimeout(function () { button.disabled = true; }, 100);
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerPlanejamento" runat="server"></asp:ScriptManager>
    <div class="row m-2 w-100 mx-auto">
        <div class="col-12 chartArea">
            <canvas id="chartPlanejamentos" class="bg-light shadow rounded"></canvas>
        </div>
        <div class="col card p-0 m-2 bg-light shadow rounded">
            <div class="card-header">
                <h5 class="text-center">Planejamento no mês</h5>
            </div>
            <div class="card-body p-0">
                <div class="text-right mx-3 my-1">
                    <button type="button" class="btn btn-info" runat="server" data-toggle="modal" data-target="#gerenciarPlanejamentoModal" title="Adicionar Novo Planejamento" onclick="limparFormPlanejamento()">Adicionar Planejamento</button>
                </div>
                <asp:UpdatePanel ID="upGridPlanejamentos" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gridPlanejamentos" CssClass="table table-sm table-striped p-0 border rounded" HeaderStyle-CssClass="table-info" OnRowCommand="GridPlanejamentos_RowCommand" EmptyDataText="Não há lançamentos ou planejamentos registrados para o período" EmptyDataRowStyle-CssClass="col font-weight-bold text-center" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCategoria">
                            <Columns>
                                <asp:TemplateField HeaderText="Tipo" ControlStyle-CssClass="col" ItemStyle-CssClass="d-none d-lg-table-cell" HeaderStyle-CssClass="d-none d-lg-table-cell">
                                    <ItemTemplate>
                                        <small><%# DataBinder.Eval(Container.DataItem, "TipoFluxo") %></small>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Categoria" ControlStyle-CssClass="col">
                                    <ItemTemplate>
                                        <img src='<%# DataBinder.Eval(Container.DataItem, "IconeCategoria") %>' height="24" width="24" alt='<%# DataBinder.Eval(Container.DataItem, "Categoria") %>' title='<%# DataBinder.Eval(Container.DataItem, "DescricaoCategoria") %>' />
                                        &nbsp;<small class="d-block d-md-inline"><%# DataBinder.Eval(Container.DataItem, "Categoria") %></small>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor Lançado" ControlStyle-CssClass="col">
                                    <ItemTemplate>
                                        <small><%# ((Decimal)DataBinder.Eval(Container.DataItem, "ValorRealizado")).ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")) %></small>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor Planejado" ControlStyle-CssClass="col">
                                    <ItemTemplate>
                                        <small><%# ((Decimal)DataBinder.Eval(Container.DataItem, "ValorPlanejado")).ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")) %></small>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField CommandName="editPlanejamento" ButtonType="Image" ImageUrl="Contents/img/icon_edit.png"></asp:ButtonField>
                                <asp:ButtonField CommandName="deletePlanejamento" ButtonType="Image" ImageUrl="Contents/img/icon_delete.png"></asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div id="gerenciarPlanejamentoModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="gerenciarPlanejamentoTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="gerenciarPlanejamentoTitle" class="modal-title">Planejamento</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="upGerenciarPlanejamento" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <form id="formGerenciarPlanejamento">
                                <div class="d-none form-group row my-2">
                                    <label for="idplanejamento" class="col-3 col-form-label">Id Planejamento</label>
                                    <div class="col-9">
                                        <input id="txtIdPlanejamento" class="form-control" type="text" runat="server" clientidmode="static" readonly />
                                    </div>
                                </div>
                                <div class="d-none form-group row my-2">
                                    <label for="idcategoria" class="col-3 col-form-label">Id Categoria</label>
                                    <div class="col-9">
                                        <input id="txtIdCategoria" class="form-control" type="text" runat="server" clientidmode="static" required readonly />
                                    </div>
                                </div>
                                <div class="form-group row my-2">
                                    <label for="tipofluxo" class="col-3 col-form-label">Tipo</label>
                                    <div class="col-9">
                                        <div class="form-check form-check-inline">
                                            <input id="rdoReceita" class="form-check-input" type="radio" runat="server" clientidmode="static" name="rdoTipoFluxo" value="Receita" onclick="listarCategorias(this.value);" />
                                            <label class="form-check-label" for="rdoReceita">Receita</label>
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <input id="rdoDespesa" class="form-check-input" type="radio" runat="server" clientidmode="static" name="rdoTipoFluxo" value="Despesa" onclick="listarCategorias(this.value);" />
                                            <label class="form-check-label" for="rdoDespesa">Despesa</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row my-2">
                                    <label for="categoria" class="col-3 col-form-label">Categoria</label>
                                    <img id="imgCategoria" src="/" width="32" height="32" alt="icon" title="Ícone" />
                                    <div class="col">
                                        <select id="listCategorias" class="form-control" onchange="selecionarCategoria(this.value);">
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group row my-2">
                                    <label for="valor" class="col-3 col-form-label">Valor (R$)</label>
                                    <div class="col-9">
                                        <input id="txtValor" class="form-control fieldMoney" type="text" runat="server" clientidmode="static" placeholder="0,00" required oninvalid="this.setCustomValidity('Insira um valor para a transação.')" oninput="setCustomValidity('')" maxlength="13" />
                                    </div>
                                </div>
                                <div class="form-group row my-2">
                                    <label for="periodo" class="col-3 col-form-label">Período</label>
                                    <label class="col-9 col-form-label"><%: new HtmlString(Periodo) %></label>
                                </div>
                                <div id="divRepetirMes" class="form-group row my-2" runat="server" clientidmode="static">
                                    <label for="repetirmes" class="col-3 col-form-label"></label>
                                    <div class="col-9">
                                        <div class="form-check">
                                            <input id="chkRepetirMes" type="checkbox" class="form-check-input" runat="server" clientidmode="static">
                                            <label class="form-check-label" for="chkRepetirMes">
                                                <span>Repetir nos</span>
                                                <asp:TextBox ID="txtRepetirMes" type="number" min="1" max="12" runat="server" TextMode="Number" Text="3" Width="48px"></asp:TextBox>
                                                <span>meses seguintes</span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </form>
                            <div class="text-center">
                                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <span id="loading" class="mr-2 text-success" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                            <asp:Button ID="btnSalvarPlanejamento" CssClass="btn btn-success" runat="server" Text="Salvar" ToolTip="Salvar planejamento" OnClientClick="validarForm(this);" OnClick="BtnSalvarPlanejamento_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSalvarPlanejamento" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div id="deletarPlanejamentoModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="deletarPlanejamentoTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="deletarPlanejamentoTitle" class="modal-title">Remover planejamento</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="upDeletarPlanejamento" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <form id="formDeletarPlanejamento">
                                <div class="d-none form-group row my-2">
                                    <label for="iddeletarplanejamento" class="col-3 col-form-label">Id Planejamento</label>
                                    <div class="col-9">
                                        <input id="txtDeletarPlanejamento" class="form-control" type="text" runat="server" clientidmode="static" readonly />
                                    </div>
                                </div>
                            </form>
                            <p>Deseja realmente excluir o valor planejado selecionado?</p>
                        </div>
                        <div class="modal-footer">
                            <span id="loadingRemover" class="mr-2 text-danger" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                            <asp:Button ID="btnDeletarPlanejamento" CssClass="btn btn-danger" runat="server" Text="Remover" ToolTip="Remover planejamento" OnClientClick="removerPlanejamento(this);" OnClick="BtnDeletarPlanejamento_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnDeletarPlanejamento" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
