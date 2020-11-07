// Inicia os componentes da página resumo:
$(document).ready(function () {
    var receitas = $dominusChart.filterData(_transacoes, 'TipoFluxo', 'Receita');
    var despesas = $dominusChart.filterData(_transacoes, 'TipoFluxo', 'Despesa');

    var dados = { Receita: $dominusChart.calcTotal(receitas, 'Valor'), Despesa: $dominusChart.calcTotal(despesas, 'Valor') };
    var saldo = dados.Receita - dados.Despesa;

    $dominusChart.createPieChart($('#chartFluxos')[0], 'Balanço mensal: ' + saldo.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' }), dados, ['#597dfe', '#ff5a5a'], true);
    $dominusChart.createColumnChart($('#chartReceitas')[0], 'Receitas no mês', $dominusChart.groupData(receitas, 'Categoria', 'Valor'), ["#03045e", "#023e8a", "#0077b6", "#0096c7", "#00b4d8", "#48cae4", "#90e0ef", "#ade8f4", "#caf0f8", "#f94144", "#f3722c", "#f8961e", "#f9844a", "#f9c74f", "#90be6d", "#43aa8b", "#4d908e", "#577590", "#277da1"]);
    $dominusChart.createColumnChart($('#chartDespesas')[0], 'Despesas no mês', $dominusChart.groupData(despesas, 'Categoria', 'Valor'), ["#f94144", "#f3722c", "#f8961e", "#f9844a", "#f9c74f", "#90be6d", "#277da1", "#03071e", "#370617", "#6a040f", "#9d0208", "#d00000", "#dc2f02", "#e85d04", "#43aa8b", "#4d908e", "#577590", "#f48c06", "#faa307", "#ffba08"]);
});
