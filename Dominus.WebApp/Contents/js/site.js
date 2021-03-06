﻿window.onload = function () {
    // Remove os anúncios do somee do corpo da página. Esta função é disparada após o carregamento da página e mantém apenas a tag form da masterpage no body.
    $("form").nextAll('div').remove();
    $("form").nextAll('center').remove();
    $("form").nextAll('script').remove();
};

// Função que valida um campo de login.
function validarLogin(elem, evt) {
    var regex = new RegExp("^[a-zA-Z0-9_]*$");
    var str = String.fromCharCode(!evt.charCode ? evt.which : evt.charCode);

    if (regex.test(str) || evt.charCode == 13) {
        $('#msgLogin')[0].hidden = true;
        return true;
    }
    else {
        if (Boolean($('#msgLogin')[0])) {
            $('#msgLogin')[0].hidden = false;
            setTimeout(function () { $('#msgLogin')[0].hidden = true; }, 2000);
        }
        evt.preventDefault();
        return false;
    }
}

// Função que compara as os textos da senha e adiciona uma mensagem de erro no caso de divergência dos valores.
function validarSenhas(elemSenha, elemValidarSenha, elemMsg) {
    // Variável para testar se o formato da senha é válido:
    var patternSenha = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}/;

    if (!patternSenha.test(elemSenha.value)) {
        elemSenha.classList.add('is-invalid');
        elemSenha.select();
    }
    else if (elemSenha.value != elemValidarSenha.value) {
        elemSenha.classList.remove('is-invalid');
        elemValidarSenha.classList.add('is-invalid');
        elemMsg.textContent = 'As senhas não conferem!';
        elemValidarSenha.select();
    }
    else {
        elemSenha.classList.remove('is-invalid');
        elemValidarSenha.classList.remove('is-invalid');
    }

    return !elemSenha.classList.contains('is-invalid') && elemSenha.value == elemValidarSenha.value;
}

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
                    text: categoria.Nome,
                    title: categoria.Descricao
                }))
            });
        }
    }
}

// Gerencia a categoria selecionada no radiobutton:
selecionarCategoria = function (idCategoria) {
    var categoria = _categorias.filter(function (el) { return el.IdCategoria == idCategoria });
    if (categoria.length > 0) {
        $('#txtIdCategoria').val(idCategoria);
        $('#imgCategoria')[0].src = 'Images/Categorias/' + categoria[0].Icone;
        $('#imgCategoria')[0].title = categoria[0].Nome;
    }
}
