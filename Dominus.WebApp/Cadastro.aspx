<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Dominus.WebApp.Cadastro" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validarTermosUso(sender, args) {
            args.IsValid = document.getElementById("<%=chkTermosUso.ClientID %>").checked == true;
        }

        function verificarSenhas() {
            var senha = document.getElementById("<%=txtSenha.ClientID %>");
            var verificarSenha = document.getElementById("<%=txtVerificarSenha.ClientID %>");
            var msg = document.getElementById("<%=lblMsg.ClientID %>");

            return validarSenhas(senha, verificarSenha, msg);
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="shadow p-3 mb-5 bg-white rounded formulario">
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="far fa-user"></i></span>
            </div>
            <input id="txtNome" name="nome" class="form-control rounded-right" type="text" runat="server" placeholder="Insira seu nome" required oninvalid="this.setCustomValidity('Insira o seu nome.')" oninput="setCustomValidity('')" maxlength="100">
        </div>
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="fas fa-user-circle"></i></span>
            </div>
            <input id="txtLogin" name="login" class="form-control rounded-right" type="text" runat="server" placeholder="Defina um login de acesso" required oninvalid="this.setCustomValidity('Insira um nome de usuário.')" oninput="setCustomValidity('')" maxlength="15">
        </div>
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="fas fa-envelope"></i></span>
            </div>
            <input id="txtEmail" name="email" class="form-control rounded-right" type="email" runat="server" placeholder="Insira o seu e-mail" required oninvalid="this.setCustomValidity('Insira um endereço de e-mail.')" oninput="setCustomValidity('')" maxlength="100">
        </div>
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="fas fa-key"></i></span>
            </div>
            <input id="txtSenha" name="senha" class="form-control rounded-right" type="password" runat="server" placeholder="Defina uma senha" required oninvalid="this.setCustomValidity('Insira uma senha válida.')" oninput="setCustomValidity('')" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Verifique abaixo as regras para senha" maxlength="20">
        </div>
        <div class="form-group input-group">
            <div class="input-group-prepend">
                <span class="input-group-text"><i class="fas fa-key"></i></span>
            </div>
            <input id="txtVerificarSenha" name="verificarSenha" class="form-control rounded-right" type="password" runat="server" placeholder="Confirme a senha" required oninvalid="this.setCustomValidity('Repita a sua senha.')" oninput="setCustomValidity('')" maxlength="20">
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
        <div class="form-group form-check">
            <asp:CheckBox ID="chkTermosUso" runat="server" AutoPostBack="false" />
            <label class="form-check-label" for="chkTermosUso">Li e aceito os <a href="#">termos de uso</a></label><br />
            <asp:CustomValidator ID="vTermosUso" CssClass="text-danger" runat="server" ErrorMessage="É necessário aceitar os termos de uso!" ClientValidationFunction="validarTermosUso" OnServerValidate="TermosUso_ServerValidate"></asp:CustomValidator>
        </div>
        <div class="text-center">
            <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
        </div>
        <div class="text-right">
            <asp:Button ID="btnCadastrar" CssClass="btn btn-primary btn-lg" runat="server" Text="Cadastrar" OnClientClick="return verificarSenhas();" OnClick="BtnCadastrar_Click" />
        </div>
        <br />
        <div class="text-center">
            <asp:Label ID="lblCadastro" Text="Já possui uma conta? Faça o seu " runat="server" /><a href="Login">Login</a>
        </div>
    </div>
</asp:Content>
