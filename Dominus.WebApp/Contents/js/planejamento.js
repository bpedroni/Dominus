// Inicia os componentes da página planejamento:
$(document).ready(function () {
    $(document).keypress(
        function (event) {
            if (event.which == '13') {
                event.preventDefault();
            }
        });

    desenharGraficoPlanejamento();
});

// Desenhao gráfico de planejamentos:
desenharGraficoPlanejamento = function () {
    var receitas = $dominusChart.filterData(_planejamentos, 'TipoFluxo', 'Receita');
    var despesas = $dominusChart.filterData(_planejamentos, 'TipoFluxo', 'Despesa');

    var dados = {
        Receita: {
            'Realizado': $dominusChart.calcTotal(receitas, 'ValorRealizado'),
            'Planejado': $dominusChart.calcTotal(receitas, 'ValorPlanejado')
        },
        Despesa: {
            'Realizado': $dominusChart.calcTotal(despesas, 'ValorRealizado'),
            'Planejado': $dominusChart.calcTotal(despesas, 'ValorPlanejado')
        }
    };

    window._chartPlanejamento = null;

    if (_planejamentos.length > 0) {
        window._chartPlanejamento = $dominusChart.createBarChart($('#chartPlanejamentos')[0], 'Realizado X Planejado no mês', dados, ["#90be6d", "#f8961e"], true);
    }
    else {
        $('#chartPlanejamentos').parent().hide();
    }
}

// Limpa o formulário de planejamentos:
limparFormPlanejamento = function () {
    $('#txtIdPlanejamento').val('');
    $('#rdoReceita').click();
    $('#txtIdCategoria').val($('#listCategorias').val());
    $('#txtValor').val('');
    $('.fieldMoney').mask('#.##0,00', { reverse: true });
    $('#chkRepetirMes')[0].checked = false;
}
