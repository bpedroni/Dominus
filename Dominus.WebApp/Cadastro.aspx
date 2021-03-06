﻿<%@ Page Title="Cadastre-se no Dominus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Dominus.WebApp.Cadastro" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validarTermosUso(sender, args) {
            args.IsValid = document.getElementById("<%=chkTermosUso.ClientID %>").checked;
        }

        function validarForm(button) {
            var msg = document.getElementById("<%=lblMsg.ClientID %>");
            msg.textContent = '';

            var nome = document.getElementById("<%=txtNome.ClientID %>");
            var login = document.getElementById("<%=txtLogin.ClientID %>");
            var email = document.getElementById("<%=txtEmail.ClientID %>");
            var senha = document.getElementById("<%=txtSenha.ClientID %>");
            if (!nome.validity.valid || !login.validity.valid || !email.validity.valid || !senha.validity.valid) {
                return;
            }
            var verificarSenha = document.getElementById("<%=txtVerificarSenha.ClientID %>");
            if (!validarSenhas(senha, verificarSenha, msg)) {
                return false;
            }
            if (!document.getElementById("<%=chkTermosUso.ClientID %>").checked) {
                msg.textContent = 'É necessário aceitar os termos de uso!';
                return false;
            }
            $('#loading')[0].hidden = false;
            setTimeout(function () { button.disabled = true; }, 100);
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card shadow rounded formulario">
        <div class="card-header">
            <h5 class="text-center">Cadastro</h5>
        </div>
        <div class="card-body">
            <div class="form-group input-group my-2" title="Insira o seu nome">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="far fa-user"></i></span>
                </div>
                <input id="txtNome" name="nome" class="form-control rounded-right" type="text" runat="server" placeholder="Insira seu nome" required oninvalid="setCustomValidity('Insira o seu nome.')" oninput="setCustomValidity('')" maxlength="100" />
            </div>
            <div class="form-group input-group my-2" title="Defina um login de acesso">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-user-circle"></i></span>
                </div>
                <input id="txtLogin" name="login" class="form-control rounded-right" type="text" runat="server" placeholder="Defina um login de acesso" required oninvalid="setCustomValidity('Insira um nome de usuário.')" oninput="setCustomValidity('')" maxlength="15" onkeypress="validarLogin(this, event)" />
            </div>
            <p id="msgLogin" class="alert alert-danger" hidden><small>Digite apenas letras, números ou '_' (sublinhado)</small></p>
            <div class="form-group input-group my-2" title="Insira o seu e-mail">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                </div>
                <input id="txtEmail" name="email" class="form-control rounded-right" type="email" runat="server" placeholder="Insira o seu e-mail" required oninvalid="setCustomValidity('Insira um endereço de e-mail.')" oninput="setCustomValidity('')" maxlength="100" />
            </div>
            <div class="form-group input-group my-2" title="Defina uma senha">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-key"></i></span>
                </div>
                <input id="txtSenha" name="senha" class="form-control rounded-right" type="password" runat="server" placeholder="Defina uma senha" required oninvalid="setCustomValidity('Insira uma senha válida.')" oninput="setCustomValidity('')" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Verifique abaixo as regras para senha" maxlength="20" />
            </div>
            <div class="form-group input-group my-2" title="Confirme a senha">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-key"></i></span>
                </div>
                <input id="txtVerificarSenha" name="verificarSenha" class="form-control rounded-right" type="password" runat="server" placeholder="Confirme a senha" required oninvalid="setCustomValidity('Repita a sua senha.')" oninput="setCustomValidity('')" maxlength="20" />
            </div>
            <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#regraSenha" aria-expanded="true" aria-controls="regraSenha" title="Verifique as regras para a senha">
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
            <div class="form-group form-check">
                <asp:CheckBox ID="chkTermosUso" runat="server" AutoPostBack="false" />
                <label class="form-check-label" for="chkTermosUso">
                    Li e aceito os termos de uso
                <button type="button" class="btn btn-link" data-toggle="modal" data-target="#termosUsoModal" title="Verifique os termos de uso"><i class="fas fa-external-link-alt"></i></button>
                </label>
                <br />
                <div class="text-center">
                    <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" />
                </div>
            </div>
            <div class="d-flex justify-content-end">
                <span id="loading" class="mr-2 fa-2x text-primary" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                <asp:Button ID="btnCadastrar" CssClass="btn btn-primary btn-lg" runat="server" Text="Cadastrar" ToolTip="Realizar o cadastro" OnClientClick="return validarForm(this);" OnClick="BtnCadastrar_Click" />
            </div>
            <div class="text-center">
                <asp:Label ID="lblCadastro" Text="Já possui uma conta? Faça o seu " runat="server" /><a href="Login" title="Ir para a página de Login">Login</a>
            </div>
        </div>
    </div>
    <div id="termosUsoModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="termosUsoModalTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="termosUsoModalTitle">Termos de Uso</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <iframe class="iframeModal" src="TermosUso.html" title="Termos de Uso"></iframe>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
