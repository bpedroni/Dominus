// Inicia os componentes da página extrato:
$(document).ready(function () {
    $(document).keypress(
        function (event) {
            if (event.which == '13') {
                event.preventDefault();
            }
        });
});

// Gerencia a lista de categorias das transações:
listarCategorias = function (tipo) {
    var select = $('#listCategorias');
    if (Boolean(select[0])) {
        select.children().remove()

        var lista = _categorias.filter(function (el) { return el.TipoFluxo == tipo });
        if (lista.length > 0) {
            $('#imgCategoria')[0].src = 'Images/Categorias/' + lista[0].Icone;

            lista.forEach(function (categoria) {
                select.append($('<option>', {
                    value: categoria.IdCategoria,
                    text: categoria.Nome
                }))
            });
        }
    }
}

// Gerencia a categoria seleiconada no radiobutton:
selecionarCategoria = function (idCategoria) {
    var categoria = _categorias.filter(function (el) { return el.IdCategoria == idCategoria });
    if (categoria.length > 0) {
        $('#txtIdCategoria').val(idCategoria);
        $('#imgCategoria')[0].src = 'Images/Categorias/' + categoria[0].Icone;
    }
}

// Limpa o formulário de transações:
limparFormTransacao = function () {
    $('#txtIdTransacao').val('');
    $('#txtDescricao').val('');
    $('#txtValor').val('');
    $('#rdoReceita').click();
    $('#rdoTransacao').click();
    $('#txtIdCategoria').val($('#listCategorias').val());
    $('#txtData').val('');
    $('#txtComentario').val('');
    $('.fieldMoney').mask('#.##0,00', { reverse: true });
    $('#txtData').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#chkRepetirMes')[0].checked = false;
}
