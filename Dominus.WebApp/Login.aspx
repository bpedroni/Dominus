<%@ Page Title="Entrar no Dominus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dominus.WebApp.Login" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validarForm(button) {
            var msg = document.getElementById("<%=lblMsg.ClientID %>");
            msg.textContent = '';

            var login = document.getElementById("<%=txtLogin.ClientID %>");
            var senha = document.getElementById("<%=txtSenha.ClientID %>");

            if (!login.validity.valid || !senha.validity.valid) {
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
            <h5 class="text-center">Login</h5>
        </div>
        <div class="card-body">
            <div class="text-center">
                <img class="img-fluid mb-3" src="Contents/img/logo_160x120.png" alt="Dominus" title="Logotipo Dominus" width="160">
            </div>
            <div class="form-group input-group my-2" title="Digite o seu login ou e-mail">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="far fa-user"></i></span>
                </div>
                <input id="txtLogin" name="login" class="form-control rounded-right" type="text" runat="server" placeholder="Digite o seu login ou e-mail" required oninvalid="setCustomValidity('Insira um nome de usuário.')" oninput="setCustomValidity('')" maxlength="100" />
            </div>
            <div class="form-group input-group my-2" title="Digite a sua senha">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-key"></i></span>
                </div>
                <input id="txtSenha" name="senha" class="form-control rounded-right" type="password" runat="server" placeholder="Digite a sua senha" required oninvalid="setCustomValidity('Insira a sua senha.')" oninput="setCustomValidity('')" maxlength="20" />
            </div>
            <button type="button" class="btn btn-link btn-block text-left" data-toggle="modal" data-target="#recuperarSenhaModal" title="Recuperar a senha de acesso">Esqueci minha senha</button>
            <div class="text-center">
                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
            </div>
            <div class="d-flex justify-content-end">
                <span id="loading" class="mr-2 fa-2x text-primary" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-lg" runat="server" Text="Login" ToolTip="Realizar o login" OnClientClick="validarForm(this);" OnClick="BtnLogin_Click" />
            </div>
            <div class="text-center">
                <asp:Label ID="lblCadastro" Text="Não possui conta? " runat="server" /><a href="Cadastro" title="Ir para a página de Cadastro">Cadastre-se</a>
            </div>
        </div>
    </div>
    <div id="recuperarSenhaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="recuperarSenhaTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="recuperarSenhaTitle">Recuperar Senha</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <iframe class="iframeModal" src="RecuperarSenha" title="Recuperar Senha"></iframe>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
