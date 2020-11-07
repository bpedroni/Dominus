<%@ Page Title="Extrato" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Extrato.aspx.cs" Inherits="Dominus.WebApp.Extrato" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="Contents/lib/jquery-mask-plugin/jquery.mask.js"></script>
    <script src="Contents/js/extrato.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script type="text/javascript">
        window._categorias = <%: new HtmlString(GetCategorias()) %>;
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerTransacao" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upGridTransacoes" runat="server">
        <ContentTemplate>
            <div class="card border">
                <div class="card-body p-0">
                    <div class="card-header ">
                        <h5 class="text-center">Lançamentos no mês</h5>
                    </div>
                    <div class="text-right mx-3 my-1">
                        <button type="button" class="btn btn-info" runat="server" data-toggle="modal" data-target="#gerenciarTransacaoModal" title="Adicionar Novo Lançamento" onclick="limparFormTransacao()">Adicionar Lançamento</button>
                    </div>
                    <asp:GridView ID="gridTransacoes" CssClass="table table-striped p-0 border rounded" OnRowCommand="GridTransacoes_RowCommand" EmptyDataText="Não há transações registradas para o período" EmptyDataRowStyle-CssClass="col font-weight-bold text-center" runat="server" AutoGenerateColumns="False" DataKeyNames="IdTransacao">
                        <Columns>
                            <asp:TemplateField HeaderText="Tipo" ControlStyle-CssClass="col" ItemStyle-CssClass="d-none d-lg-table-cell" HeaderStyle-CssClass="d-none d-lg-table-cell">
                                <ItemTemplate>
                                    <small><%# DataBinder.Eval(Container.DataItem, "TipoFluxo") %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modo" ControlStyle-CssClass="col" ItemStyle-CssClass="d-none d-lg-table-cell" HeaderStyle-CssClass="d-none d-lg-table-cell">
                                <ItemTemplate>
                                    <small><%# DataBinder.Eval(Container.DataItem, "Modo") %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria" ControlStyle-CssClass="col">
                                <ItemTemplate>
                                    <img src='<%# DataBinder.Eval(Container.DataItem, "IconeCategoria") %>' height="24" width="24" alt='<%# DataBinder.Eval(Container.DataItem, "Categoria") %>' title='<%# DataBinder.Eval(Container.DataItem, "Categoria") %>' />
                                    &nbsp;<small class="d-block d-md-inline"><%# DataBinder.Eval(Container.DataItem, "Categoria") %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descrição" ControlStyle-CssClass="col">
                                <ItemTemplate>
                                    <small><%# DataBinder.Eval(Container.DataItem, "Descricao") %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data" ControlStyle-CssClass="col" ItemStyle-CssClass="d-none d-md-table-cell" HeaderStyle-CssClass="d-none d-md-table-cell">
                                <ItemTemplate>
                                    <small><%# ((DateTime)DataBinder.Eval(Container.DataItem, "Data")).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")) %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Valor" ControlStyle-CssClass="col">
                                <ItemTemplate>
                                    <small><%# ((Decimal)DataBinder.Eval(Container.DataItem, "Valor")).ToString("C2", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")) %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comentário" ControlStyle-CssClass="col" ItemStyle-CssClass="d-none d-lg-table-cell" HeaderStyle-CssClass="d-none d-lg-table-cell">
                                <ItemTemplate>
                                    <small><%# DataBinder.Eval(Container.DataItem, "Comentario") %></small>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField CommandName="editTransacao" ButtonType="Image" ImageUrl="Contents/img/icon_edit.png"></asp:ButtonField>
                            <asp:ButtonField CommandName="deleteTransacao" ButtonType="Image" ImageUrl="Contents/img/icon_delete.png"></asp:ButtonField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="gerenciarTransacaoModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="gerenciarTransacaoTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="gerenciarTransacaoTitle" class="modal-title">Lançamento</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="upGerenciarTransacao" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <form id="formGerenciarTransacao">
                                <div class="d-none form-group row">
                                    <label for="idtransacao" class="col-3 col-form-label">Id Transação</label>
                                    <div class="col-9">
                                        <input id="txtIdTransacao" class="form-control" type="text" runat="server" clientidmode="static" readonly />
                                    </div>
                                </div>
                                <div class="d-none form-group row">
                                    <label for="idcategoria" class="col-3 col-form-label">Id Categoria</label>
                                    <div class="col-9">
                                        <input id="txtIdCategoria" class="form-control" type="text" runat="server" clientidmode="static" required readonly />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="descricao" class="col-3 col-form-label">Descrição</label>
                                    <div class="col-9">
                                        <input id="txtDescricao" class="form-control" type="text" runat="server" clientidmode="static" placeholder="Digite uma descrição para a transação" required oninvalid="this.setCustomValidity('Insira uma descrição para a transação.')" oninput="setCustomValidity('')" maxlength="100" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="valor" class="col-3 col-form-label">Valor (R$)</label>
                                    <div class="col-9">
                                        <input id="txtValor" class="form-control fieldMoney" type="text" runat="server" clientidmode="static" placeholder="0,00" required oninvalid="this.setCustomValidity('Insira um valor para a transação.')" oninput="setCustomValidity('')" maxlength="13" />
                                    </div>
                                </div>
                                <div class="form-group row">
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
                                <div class="form-group row">
                                    <label for="tipofluxo" class="col-3 col-form-label">Modo</label>
                                    <div class="col-9">
                                        <div class="form-check form-check-inline">
                                            <input id="rdoTransacao" class="form-check-input" type="radio" runat="server" clientidmode="static" name="rdoModo" value="0" />
                                            <label class="form-check-label" for="rdoTransacao">Transação</label>
                                        </div>
                                        <div class="form-check form-check-inline">
                                            <input id="rdoProvisao" class="form-check-input" type="radio" runat="server" clientidmode="static" name="rdoModo" value="1" checked />
                                            <label class="form-check-label" for="rdoProvisao">Provisão</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="categoria" class="col-3 col-form-label">Categoria</label>
                                    <img id="imgCategoria" src="/" width="32" height="32" alt="icon" title="Ícone" />
                                    <div class="col">
                                        <select id="listCategorias" class="form-control" onchange="selecionarCategoria(this.value);">
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="data" class="col-3 col-form-label">Data</label>
                                    <div class="col-9">
                                        <input id="txtData" class="form-control" type="text" runat="server" clientidmode="static" required readonly />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="repetirmes" class="col-3 col-form-label"></label>
                                    <div class="col-9">
                                        <div class="form-check">
                                            <input id="chkRepetirMes" type="checkbox" class="form-check-input" runat="server" clientidmode="static">
                                            <label class="form-check-label" for="chkRepetirMes">Repetir nos 3 meses seguintes</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="comentario" class="col-3 col-form-label">Comentário</label>
                                    <div class="col-9">
                                        <textarea id="txtComentario" class="form-control" type="text" runat="server" clientidmode="static" placeholder="Coloque um comentário para a transação (opcional)" oninput="setCustomValidity('')" maxlength="255"></textarea>
                                    </div>
                                </div>
                            </form>
                            <div class="text-center">
                                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnSalvarTransacao" CssClass="btn btn-success" runat="server" Text="Salvar" ToolTip="Salvar lançamento" OnClick="BtnSalvarTransacao_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSalvarTransacao" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div id="deletarTransacaoModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="deletarTransacaoTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="deletarTransacaoTitle" class="modal-title">Remover lançamento</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="upDeletarTransacao" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <form id="formDeletarTransacao">
                                <div class="d-none form-group row">
                                    <label for="iddeletartransacao" class="col-3 col-form-label">Id Transação</label>
                                    <div class="col-9">
                                        <input id="txtDeletarTransacao" class="form-control" type="text" runat="server" clientidmode="static" readonly />
                                    </div>
                                </div>
                            </form>
                            <p>Deseja realmente excluir o lançamento selecionado?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnDeletarTransacao" CssClass="btn btn-danger" runat="server" Text="Remover" ToolTip="Remover lançamento" OnClick="BtnDeletarTransacao_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnDeletarTransacao" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
