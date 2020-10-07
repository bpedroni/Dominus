// Função que remove os anúncios do somee do corpo da página.
// Esta função é disparada após o carregamento da página e mantém apenas a tag form da masterpage no body.
function removerAnunciosSomee() {
    $("form").nextAll('div').remove();
    $("form").nextAll('center').remove();
    $("form").nextAll('script').remove();
}

// Função que que compara as os textos da senha e adiciona uma mensagem de erro no caso de divergência dos valores.
function validarSenhas(elemSenha, elemValidarSenha, elemMsg) {
    if (elemSenha.validity.valid && elemSenha.value != elemValidarSenha.value) {
        elemValidarSenha.classList.add('is-invalid');
        elemMsg.textContent = 'As senhas não conferem!';
        elemValidarSenha.select();
    }
    else {
        elemValidarSenha.classList.remove('is-invalid');
    }

    return elemSenha.value == elemValidarSenha.value;
}
