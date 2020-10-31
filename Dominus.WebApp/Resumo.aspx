<%@ Page Title="Resumo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resumo.aspx.cs" Inherits="Dominus.WebApp.Resumo" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="Contents/lib/chartjs/Chart.js"></script>
    <script src="Contents/js/dominus-chart.js"></script>
    <script type="text/javascript">
        window._transacoes = <%: new HtmlString(GetTransacoes()) %>;

        $(document).ready(function () {
            var receitas = $dominusChart.filterData(_transacoes, 'TipoFluxo', 'Receita');
            var despesas = $dominusChart.filterData(_transacoes, 'TipoFluxo', 'Despesa');

            var dados = { Receita: $dominusChart.calcTotal(receitas, 'Valor'), Despesa: $dominusChart.calcTotal(despesas, 'Valor') };
            var saldo = dados.Receita - dados.Despesa;

            $dominusChart.createPieChart($('#chartFluxos')[0], 'Balanço mensal: ' + saldo.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }), dados, ['#597dfe', '#ff5a5a']);
            $dominusChart.createColumnChart($('#chartReceitas')[0], 'Receitas no mês', $dominusChart.groupData(receitas, 'Categoria', 'Valor'), ["#03045e", "#023e8a", "#0077b6", "#0096c7", "#00b4d8", "#48cae4", "#90e0ef", "#ade8f4", "#caf0f8", "#f94144", "#f3722c", "#f8961e", "#f9844a", "#f9c74f", "#90be6d", "#43aa8b", "#4d908e", "#577590", "#277da1"]);
            $dominusChart.createColumnChart($('#chartDespesas')[0], 'Despesas no mês', $dominusChart.groupData(despesas, 'Categoria', 'Valor'), ["#f94144", "#f3722c", "#f8961e", "#f9844a", "#f9c74f", "#90be6d", "#277da1", "#03071e", "#370617", "#6a040f", "#9d0208", "#d00000", "#dc2f02", "#e85d04", "#43aa8b", "#4d908e", "#577590", "#f48c06", "#faa307", "#ffba08"]);
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row w-100 mx-auto">
        <div class="col-lg-4 col-md-6 border rounded">
            <canvas id="chartReceitas"></canvas>
        </div>
        <div class="col-lg-4 col-md-6 border rounded">
            <canvas id="chartDespesas"></canvas>
        </div>
        <div class="col-lg-4 border rounded">
            <canvas id="chartFluxos"></canvas>
        </div>
    </div>
    <div class="card border">
        <div class="card-body p-0">
            <div class="card-header ">
                <h5 class="text-center">Últimas Transações</h5>
            </div>
            <asp:GridView ID="gridTransacoes" CssClass="table table-striped border rounded" EmptyDataText="Não há transações registradas para o período" EmptyDataRowStyle-CssClass="col font-weight-bold text-center" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Categoria">
                        <ItemTemplate>
                            <asp:Image ID="imgCategoria" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "IconeCategoria") %>' Height="24px" Width="24px" AlternateText='<%# DataBinder.Eval(Container.DataItem, "Categoria") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "Categoria") %>' runat="server" />
                            &nbsp;<asp:Label Text='<%# DataBinder.Eval(Container.DataItem, "Categoria") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Descricao" HeaderText="Transação" ControlStyle-CssClass="col-3" />
                    <asp:TemplateField HeaderText="Data" ControlStyle-CssClass="col-3">
                        <ItemTemplate>
                            <asp:Label Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "Data")).ToString("dd/MM/yyyy") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor" ControlStyle-CssClass="col-3">
                        <ItemTemplate>
                            &nbsp;<asp:Label Text='<%# ((Decimal)DataBinder.Eval(Container.DataItem, "Valor")).ToString("C2", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")) %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="text-right mx-3 my-1">
                <a class="btn btn-secondary" href="Extrato" title="Extrato Financeiro">
                    <i class="fas fa-dollar-sign"></i>&nbsp;Ir Para Extrato Financeiro
                </a>
            </div>
        </div>
    </div>
</asp:Content>
