// Inicia os componentes da página relatórios:
$(document).ready(function () {
    $('#txtDataInicial').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#txtDataFinal').datepicker({ dateFormat: 'dd/mm/yy' });
    carregarPivotTable($('#pnlPivot'));
});

// Limpa o formulário do filtro do relatório:
carregarPivotTable = function (div) {
    var frFormat = $.pivotUtilities.numberFormat({ thousandsSep: ".", decimalSep: ",", prefix: "R$ " });

    div.pivotUI(
        _relatorioUsuario, {
        renderers: {
            "Tabela": $.pivotUtilities.renderers.Table,
            "Gráfico de colunas": $.pivotUtilities.plotly_renderers["Bar Chart"],
            "Gráfico de barras": $.pivotUtilities.plotly_renderers["Horizontal Bar Chart"],
            "Gráfico de linhas": $.pivotUtilities.plotly_renderers["Line Chart"]
        },
        sorters: {
            "Mês": $.pivotUtilities.sortAs(["janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"]),
            "Tipo": $.pivotUtilities.sortAs(["Receita", "Despesa"]),
            "Modo": $.pivotUtilities.sortAs(["Transação", "Provisão"])
        },
        aggregators: {
            "Total em reais": function () {
                return $.pivotUtilities.aggregatorTemplates.sum(frFormat)(["Valor"]);
            }
        }
    });
}

// Limpa o formulário do filtro do relatório:
limparFormFiltro = function () {
    $('#txtDataInicial').val('');
    $('#txtDataFinal').val('');
    $('#txtDataInicial').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#txtDataFinal').datepicker({ dateFormat: 'dd/mm/yy' });
}
