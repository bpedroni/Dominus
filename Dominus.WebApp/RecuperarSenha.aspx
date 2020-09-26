<%@ Page Title="Recuperar Senha" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarSenha.aspx.cs" Inherits="Dominus.WebApp.RecuperarSenha" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card" style="margin: 20px auto; width: 400px;">
        <%--<img src="." class="card-img-top" alt="Login">--%>
        <div class="card-body">
            <form>
                <a class="btn btn-link btn-block text-left" href="Login"><i class="fas fa-long-arrow-alt-left"></i> Voltar para o login</a><p></p>
                <asp:Label ID="lblRecuperarSenha" CssClass="text-info" Text="Informe seu e-mail cadastrado e enviaremos um link de recuperação de senha." runat="server" /><p></p>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                    </div>
                    <input id="txtEmail" class="form-control rounded-right" type="email" runat="server" placeholder="Digite o seu e-mail." required oninvalid="this.setCustomValidity('Insira um e-mail.')" oninput="setCustomValidity('')">
                </div>
                <div class="text-center">
                    <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
                </div>
                <div class="text-right">
                    <asp:Button ID="btnRecuperarSenha" CssClass="btn btn-primary" runat="server" Text="Enviar senha por e-mail" OnClientClick="return VerificarEmail();" OnClick="BtnRecuperarSenha_Click" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
