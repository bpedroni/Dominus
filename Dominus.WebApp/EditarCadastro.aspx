<%@ Page Title="Editar Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCadastro.aspx.cs" Inherits="Dominus.WebApp.EditarCadastro" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function verificarSenhas() {
            var alterarSenha = document.getElementById("<%=chkAlterarSenha.ClientID %>");
            var novaSenha = document.getElementById("<%=txtNovaSenha.ClientID %>");
            var verificarSenha = document.getElementById("<%=txtVerificarSenha.ClientID %>");
            var msg = document.getElementById("<%=lblMsg.ClientID %>");

            if (!alterarSenha.checked) {
                novaSenha.required = false;
                verificarSenha.required = false;
                return true;
            }
            novaSenha.required = true;
            verificarSenha.required = true;
            return validarSenhas(novaSenha, verificarSenha, msg);
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="shadow p-3 mb-5 bg-white rounded formulario">
        <a class="btn btn-link btn-block text-left" href="Resumo"><i class="fas fa-long-arrow-alt-left"></i>Voltar para o resumo financeiro</a><p></p>
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="far fa-user"></i></span>
            </div>
            <input id="txtNome" name="nome" class="form-control rounded-right" type="text" runat="server" placeholder="Nome" required oninvalid="this.setCustomValidity('Insira o seu nome.')" oninput="setCustomValidity('')" maxlength="100" />
        </div>
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="fas fa-user-circle"></i></span>
            </div>
            <input id="txtLogin" name="login" class="form-control rounded-right" type="text" runat="server" placeholder="Login de acesso" required oninvalid="this.setCustomValidity('Insira um nome de usuário.')" oninput="setCustomValidity('')" maxlength="15" onkeypress="validarLogin(this, event)" />
        </div>
        <p id="msgLogin" class="text-danger" hidden><small>Digite apenas letras, números ou '_' (sublinhado)</small></p>
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="fas fa-key"></i></span>
            </div>
            <input id="txtSenha" name="senha" class="form-control rounded-right" type="password" runat="server" placeholder="Senha" required oninvalid="this.setCustomValidity('Informe a sua senha.')" oninput="setCustomValidity('')" maxlength="20" />
        </div>
        <div class="form-group form-check">
            <asp:CheckBox ID="chkAlterarSenha" runat="server" AutoPostBack="false" data-toggle="collapse" data-target="#alterarSenha" aria-expanded="true" aria-controls="alterarSenha" />
            <label class="form-check-label" for="chkAlterarSenha">Alterar senha</label>
        </div>
        <div <%= chkAlterarSenha.Checked ? "class='expand'" : "class='collapse'" %> id="alterarSenha">
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-key"></i></span>
                </div>
                <input id="txtNovaSenha" name="novaSenha" class="form-control rounded-right" type="password" runat="server" placeholder="Digite uma nova senha" maxlength="20">
            </div>
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-key"></i></span>
                </div>
                <input id="txtVerificarSenha" name="verificarSenha" class="form-control rounded-right" type="password" runat="server" placeholder="Confirme a nova senha" maxlength="20">
            </div>
            <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#regraSenha" aria-expanded="true" aria-controls="regraSenha">
                Regras para senha
            </button>
            <div class="collapse" id="regraSenha">
                <ul>
                    <li>Deve conter entre 8 e 20 caracteres</li>
                    <li>Deve conter ao menos um número</li>
                    <li>Deve conter ao menos uma letra maiúscula</li>
                    <li>Deve conter ao menos uma letra minúscula</li>
                </ul>
            </div>
        </div>
        <div class="text-center">
            <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
        </div>
        <div class="text-right">
            <asp:Button ID="btnEditarCadastro" CssClass="btn btn-primary btn-lg" runat="server" Text="Salvar alterações" OnClientClick="return verificarSenhas();" OnClick="BtnEditarCadastro_Click" />
        </div>
        <br />
    </div>
</asp:Content>
