// Inicia os componentes da página extrato:
$(document).ready(function () {
    $(document).keypress(
        function (event) {
            if (event.which == '13') {
                event.preventDefault();
            }
        });
});

// Limpa o formulário de transações:
limparFormTransacao = function () {
    $('#txtIdTransacao').val('');
    $('#txtDescricao').val('');
    $('#txtValor').val('');
    $('#rdoReceita').click();
    $('#rdoTransacao').click();
    $('#txtIdCategoria').val($('#listCategorias').val());
    $('#txtData').val(_dataPeriodo);
    $('#txtComentario').val('');
    $('.fieldMoney').mask('#.##0,00', { reverse: true });
    $('#txtData').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#chkRepetirMes')[0].checked = false;
}
