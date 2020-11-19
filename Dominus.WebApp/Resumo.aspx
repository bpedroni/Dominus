<%@ Page Title="Resumo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumo.aspx.cs" Inherits="Dominus.WebApp.Resumo" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="Contents/lib/chartjs/Chart.min.js"></script>
    <script src="Contents/js/dominus-chart.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script src="Contents/js/resumo.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
    <script type="text/javascript">
        window._transacoes = <%: new HtmlString(GetTransacoes()) %>;
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row m-2 w-100 mx-auto">
        <div class="col-lg-4 col-md-6 p-2">
            <canvas id="chartReceitas" class="bg-light shadow rounded"></canvas>
        </div>
        <div class="col-lg-4 col-md-6 p-2">
            <canvas id="chartDespesas" class="bg-light shadow rounded"></canvas>
        </div>
        <div class="col-lg-4 p-2">
            <canvas id="chartFluxos" class="bg-light shadow rounded"></canvas>
        </div>
        <div class="col card p-0 m-2 bg-light shadow rounded">
            <div class="card-header">
                <h5 class="text-center">Últimos Lançamentos</h5>
            </div>
            <div class="card-body p-0">
                <asp:GridView ID="gridTransacoes" CssClass="table table-striped p-0 border rounded" EmptyDataText="Não há transações registradas para o período" EmptyDataRowStyle-CssClass="col font-weight-bold text-center" runat="server" AutoGenerateColumns="False">
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
                        <asp:TemplateField HeaderText="Descrição" ControlStyle-CssClass="col">
                            <ItemTemplate>
                                <small><%# DataBinder.Eval(Container.DataItem, "Descricao") %></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Data" ControlStyle-CssClass="col" ItemStyle-CssClass="d-none d-md-table-cell" HeaderStyle-CssClass="d-none d-md-table-cell">
                            <ItemTemplate>
                                <small><%# ((DateTime)DataBinder.Eval(Container.DataItem, "Data")).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")) %></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor" ControlStyle-CssClass="col">
                            <ItemTemplate>
                                <small><%# ((Decimal)DataBinder.Eval(Container.DataItem, "Valor")).ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")) %></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comentário" ControlStyle-CssClass="col" ItemStyle-CssClass="d-none d-lg-table-cell" HeaderStyle-CssClass="d-none d-lg-table-cell">
                            <ItemTemplate>
                                <small><%# DataBinder.Eval(Container.DataItem, "Comentario") %></small>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="text-right mx-3 my-1">
                    <a class="btn btn-info" href="Extrato" title="Extrato Financeiro">
                        <i class="fas fa-dollar-sign"></i>&nbsp;Ir Para Extrato Financeiro
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
