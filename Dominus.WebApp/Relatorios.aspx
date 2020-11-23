<%@ Page Title="Relatórios" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="Dominus.WebApp.Relatorios" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="Contents/lib/pivottable/pivot.min.css" rel="stylesheet" />
    <script src="Contents/lib/jquery-mask-plugin/jquery.mask.js"></script>
    <script src="Contents/lib/pivottable/pivot.min.js"></script>
    <script src="Contents/lib/pivottable/pivot.pt.min.js"></script>
    <script src="Contents/lib/pivottable/plotly-basic-latest.min.js"></script>
    <script src="Contents/lib/pivottable/plotly_renderers.js"></script>
    <script src="Contents/js/relatorios.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script type="text/javascript">
        window._relatorioUsuario = <%: new HtmlString(GetRelatorioUsuario()) %>;

        function aguardarFiltro(button) {
            $('#loading')[0].hidden = false;
            setTimeout(function () { button.disabled = true; }, 100);
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManagerRelatorios" runat="server"></asp:ScriptManager>
    <div class="form-row m-0 bg-light">
        <asp:UpdatePanel ID="upFiltrarRelatorio" runat="server">
            <ContentTemplate>
                <div class="form-row col-lg m-2">
                    <div class="col-auto p-1 my-auto">
                        <div style="width: 100px;" class="d-inline-block text-right">Data Inicial:</div>
                        <input id="txtDataInicial" type="text" runat="server" clientidmode="static" value="" readonly />
                        <div style="width: 100px;" class="d-inline-block text-right">Data Final:</div>
                        <input id="txtDataFinal" type="text" runat="server" clientidmode="static" value="" readonly />
                    </div>
                    <div class="col-auto">
                        <span id="loading" class="mr-2 text-primary" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                        <asp:Button ID="btnFiltrar" CssClass="btn btn-primary" runat="server" Text="Filtrar relatório" ToolTip="Filtrar dados do relatório" OnClientClick="aguardarFiltro(this);" OnClick="BtnFiltrar_Click" />
                        <button type="button" class="btn btn-secondary" title="Limpar o filtro do relatório" onclick="limparFormFiltro();">Limpar filtro</button>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFiltrar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="m-2 w-100 mx-auto">
        <div class="card p-0 m-2 bg-light shadow rounded">
            <div id="pnlPivot" class="card-body p-0">
            </div>
        </div>
    </div>
</asp:Content>
