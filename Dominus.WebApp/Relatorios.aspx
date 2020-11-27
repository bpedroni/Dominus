<%@ Page Title="Relatórios" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="Dominus.WebApp.Relatorios" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="Contents/lib/pivottable/pivot.min.css" rel="stylesheet" />
    <script src="Contents/lib/jquery-mask-plugin/jquery.mask.js"></script>
    <script src="Contents/lib/pivottable/pivot.min.js"></script>
    <script src="Contents/lib/pivottable/pivot.pt.min.js"></script>
    <script src="Contents/lib/pivottable/plotly-basic-latest.min.js"></script>
    <script src="Contents/lib/pivottable/plotly_renderers.js"></script>
    <script src="Contents/js/dominus-pivot.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script src="Contents/js/relatorios.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script type="text/javascript">
        window._tiposRelatorio = <%: new HtmlString(GetTiposRelatorio()) %>;
        window._relatorioUsuario = <%: new HtmlString(GetRelatorioUsuario()) %>;
        window._relatorio = <%: new HtmlString(GetItemRelatorio()) %>;

        function validarForm(button) {
            var msg = document.getElementById("<%=lblMsg.ClientID %>");
            msg.textContent = '';

            var nome = document.getElementById("<%=txtNome.ClientID %>");
            nome.required = true;

            if (!nome.validity.valid) {
                return false;
            }

            $('#loadingSalvarRelatorio')[0].hidden = false;
            setTimeout(function () { button.disabled = true; }, 100);
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerRelatorios" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upGerenciarRelatorio" runat="server">
        <ContentTemplate>
            <div class="info-usuario form-inline m-0 bg-white">
                <div class="form-row col-lg m-2">
                    <span>Modelo de relatório:&nbsp;&nbsp;</span>
                    <asp:DropDownList ID="ddListaRelatorios" CssClass="form-control" Width="300" ToolTip="Selecione um modelo de relatório" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdListaRelatorios_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row m-0 bg-light">
                <div class="form-row col-lg m-2">
                    <div class="col-auto p-1 my-auto">
                        <div style="width: 100px;" class="d-inline-block text-right">Data Inicial:</div>
                        <input id="txtDataInicial" type="text" runat="server" clientidmode="static" value="" readonly />
                        <div style="width: 100px;" class="d-inline-block text-right">Data Final:</div>
                        <input id="txtDataFinal" type="text" runat="server" clientidmode="static" value="" readonly />
                    </div>
                    <div class="col-auto p-1 my-auto">
                        <span id="loadingFiltro" class="mr-2 text-primary" hidden><i class="fas fa-spinner fa-spin"></i></span>
                        <asp:Button ID="btnFiltrar" CssClass="btn btn-primary" runat="server" Text="Filtrar relatório" ToolTip="Filtrar dados do relatório" OnClientClick="aguardarFiltro($('#loadingFiltro')[0], this);" OnClick="BtnFiltrar_Click" />
                        <button type="button" class="btn btn-secondary" title="Limpar o filtro do relatório" onclick="limparFormFiltro();">Limpar filtro</button>
                    </div>
                    <div class="col-auto p-1 my-auto">
                        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#salvarModeloRelatorioModal" title="Salvar o relatório atual como um modelo" onclick="abrirFormRelatorio();">Salvar modelo do relatório</button>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="m-2 w-100 mx-auto">
        <div class="card p-0 m-2 bg-light shadow rounded">
            <div id="pnlPivot" class="card-body p-0">
            </div>
        </div>
    </div>
    <div id="salvarModeloRelatorioModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="salvarModeloRelatorioTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="salvarModeloRelatorioTitle" class="modal-title">Salvar modelo de relatório</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <asp:UpdatePanel ID="upSalvarModeloRelatorio" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <form id="formSalvarModeloRelatorio">
                                <div class="d-none form-group row my-2">
                                    <label for="idTipoRelatorio" class="col-3 col-form-label">Id Tipo Relatorio</label>
                                    <div class="col-9">
                                        <input id="txtTipoRelatorio" class="form-control" type="text" runat="server" clientidmode="static" required readonly />
                                    </div>
                                </div>
                                <div class="d-none form-group row my-2">
                                    <label for="infoLinha" class="col-3 col-form-label">Info Linha</label>
                                    <div class="col-9">
                                        <input id="txtInfoLinha" class="form-control" type="text" runat="server" clientidmode="static" required readonly />
                                    </div>
                                </div>
                                <div class="d-none form-group row my-2">
                                    <label for="infoColuna" class="col-3 col-form-label">Info Coluna</label>
                                    <div class="col-9">
                                        <input id="txtInfoColuna" class="form-control" type="text" runat="server" clientidmode="static" required readonly />
                                    </div>
                                </div>
                                <div class="form-group row my-2">
                                    <label for="nome" class="col-3 col-form-label">Nome do modelo</label>
                                    <div class="col-9">
                                        <input id="txtNome" class="form-control" type="text" runat="server" clientidmode="static" placeholder="Digite uma descrição para a transação" required oninvalid="this.setCustomValidity('Insira um nome para o modelo de relatório.')" oninput="setCustomValidity('')" maxlength="100" />
                                    </div>
                                </div>
                            </form>
                            <div class="text-center">
                                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <span id="loadingSalvarRelatorio" class="mr-2 text-success" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                            <asp:Button ID="btnSalvarRelatorio" CssClass="btn btn-success" runat="server" Text="Salvar" ToolTip="Salvar modelo" OnClientClick="validarForm(this);" OnClick="BtnSalvarRelatorio_Click" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSalvarRelatorio" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
