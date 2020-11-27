// Inicia os componentes da página relatórios:
$(document).ready(function () {
    $('#txtDataInicial').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#txtDataFinal').datepicker({ dateFormat: 'dd/mm/yy' });

    $dominusPivot.loadRenderers(_tiposRelatorio, 'Tipo', 'Descricao');

    carregarPivotTable($('#pnlPivot'));
});

// Abre a janela para salvar um novo modelo de relatório:
function abrirFormRelatorio() {
    var pivotOptions = $dominusPivot.pivotOptions($('#pnlPivot'));
    var tipo = _tiposRelatorio.find(element => element.Tipo == pivotOptions.rendererName);

    $('#txtTipoRelatorio').val(tipo.IdTipoRelatorio);
    $('#txtInfoLinha').val(JSON.stringify(pivotOptions.rows));
    $('#txtInfoColuna').val(JSON.stringify(pivotOptions.cols));
}

// Desabilita o botão até o retorno da resposta do servidor:
function aguardarFiltro(loading, button) {
    $('#txtNome')[0].required = false;
    loading.hidden = false;
    setTimeout(function () { button.disabled = true; }, 100);
    return true;
}

// Limpa o formulário do filtro do relatório:
function carregarPivotTable (div) {
    if (Boolean(_relatorio)) {
        $dominusPivot.createPivotUI($('#pnlPivot'), _relatorioUsuario, _relatorio.Rows, _relatorio.Cols, _relatorio.Renderer);
    }
    else {
        var pivotOptions = $dominusPivot.pivotOptions($('#pnlPivot'));
        $dominusPivot.createPivotUI(div, _relatorioUsuario, pivotOptions.rows, pivotOptions.cols, pivotOptions.rendererName);
    }
}

// Limpa o formulário do filtro do relatório:
function limparFormFiltro () {
    $('#txtDataInicial').val('');
    $('#txtDataFinal').val('');
    $('#txtDataInicial').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#txtDataFinal').datepicker({ dateFormat: 'dd/mm/yy' });
}
