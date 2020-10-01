<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dominus.WebApp.Login" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <div class="shadow p-3 mb-5 bg-white rounded formulario">
            <div class="text-center">
                <img src="Contents/img/logo_160x120.png" alt="Login" width="160">
            </div>
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="far fa-user"></i></span>
                </div>
                <input id="txtLogin" class="form-control rounded-right" type="text" runat="server" placeholder="Digite o seu login ou e-mail." required oninvalid="this.setCustomValidity('Insira um nome de usuário.')" oninput="setCustomValidity('')">
            </div>
            <div class="form-group input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-key"></i></span>
                </div>
                <input id="txtSenha" class="form-control rounded-right" type="password" runat="server" placeholder="Digite a sua senha." required oninvalid="this.setCustomValidity('Insira a sua senha.')" oninput="setCustomValidity('')">
            </div>
            <a class="btn btn-link btn-block text-left" href="RecuperarSenha">Esqueci minha senha</a>
            <div class="text-center">
                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
            </div>
            <div class="text-right">
                <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-lg" runat="server" Text="Login" OnClick="BtnLogin_Click" />
            </div>
            <br />
            <div class="text-center">
                <asp:Label ID="lblCadastro" Text="Não possui conta? " runat="server" /><a href="Cadastro">Cadastre-se</a>
            </div>
        </div>
    </form>
</asp:Content>
