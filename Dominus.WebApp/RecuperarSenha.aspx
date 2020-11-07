<%@ Page Title="Recuperar Senha" Language="C#" AutoEventWireup="true" CodeBehind="RecuperarSenha.aspx.cs" Inherits="Dominus.WebApp.RecuperarSenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Recuperar Senha</title>
    <link href="Contents/img/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="Contents/lib/fontawesome/css/all.css" rel="stylesheet" />
    <link href="Contents/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Contents/css/site.css" rel="stylesheet" />
    <script src="Contents/lib/jquery/jquery-3.5.1.min.js"></script>
    <script src="Contents/lib/bootstrap/js/bootstrap.min.js"></script>
    <script src="Contents/js/site.js?ts=<%: new HtmlString(DateTime.Now.Ticks.ToString()) %>"></script>
</head>
<body style="height: auto;">
    <form runat="server">
        <div class="p-3 mb-5 bg-white formulario">
            <asp:Label ID="lblRecuperarSenha" CssClass="text-info" Text="Informe seu e-mail cadastrado e enviaremos um link de recuperação de senha." runat="server" /><p></p>
            <div class="form-group input-group" title="Digite o seu e-mail">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                </div>
                <input id="txtEmail" class="form-control rounded-right" type="email" runat="server" placeholder="Digite o seu e-mail" required="required" oninvalid="this.setCustomValidity('Insira um e-mail.')" oninput="setCustomValidity('')" maxlength="100" />
            </div>
            <div class="text-center">
                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
            </div>
            <div class="text-right">
                <asp:Button ID="btnRecuperarSenha" CssClass="btn btn-primary" runat="server" Text="Enviar senha por e-mail" ToolTip="Enviar senha por e-mail" OnClientClick="return VerificarEmail();" OnClick="BtnRecuperarSenha_Click" />
            </div>
        </div>
    </form>
</body>
</html>
