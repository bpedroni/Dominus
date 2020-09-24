﻿<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Dominus.WebApp.Cadastro" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ValidarTermosUso(sender, args) {
            args.IsValid = document.getElementById("<%=chkTermosUso.ClientID %>").checked == true;
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card" style="margin: 20px auto; max-width: 400px;">
        <div class="card-body">
            <form>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="far fa-user"></i></span>
                    </div>
                    <input id="txtNome" class="form-control rounded-right" type="text" runat="server" placeholder="Insira seu nome" required oninvalid="this.setCustomValidity('Insira o seu nome.')" oninput="setCustomValidity('')">
                </div>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-user-circle"></i></span>
                    </div>
                    <input id="txtLogin" class="form-control rounded-right" type="text" runat="server" placeholder="Defina um login de acesso" required oninvalid="this.setCustomValidity('Insira um nome de usuário.')" oninput="setCustomValidity('')">
                </div>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                    </div>
                    <input id="txtEmail" class="form-control rounded-right" type="email" runat="server" placeholder="Insira o seu e-mail" required oninvalid="this.setCustomValidity('Insira um endereço de e-mail.')" oninput="setCustomValidity('')">
                </div>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-key"></i></span>
                    </div>
                    <input id="txtSenha" class="form-control rounded-right" type="password" runat="server" placeholder="Defina uma senha" required oninvalid="this.setCustomValidity('Insira uma senha válida.')" oninput="setCustomValidity('')">
                </div>
                <div class="form-group input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-key"></i></span>
                    </div>
                    <input id="txtVerficarSenha" class="form-control rounded-right" type="password" runat="server" placeholder="Confirme a senha" required oninvalid="this.setCustomValidity('Repita a sua senha.')" oninput="setCustomValidity('')">
                </div>
                <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#regraSenha" aria-expanded="true" aria-controls="regraSenha">
                    Regras para senha
                </button>
                <div class="collapse" id="regraSenha">
                    <ul>
                        <li>Deve conter no mínimo 8 caracteres</li>
                        <li>Deve conter letras e números</li>
                    </ul>
                </div>
                <div class="form-group form-check">
                    <asp:CheckBox ID="chkTermosUso" runat="server" AutoPostBack="false" />
                    <label class="form-check-label" for="chkTermosUso">Li e aceito os <a href="#">termos de uso</a></label><br />
                    <asp:CustomValidator ID="vTermosUso" CssClass="text-danger" runat="server" ErrorMessage="É necessário aceitar os termos de uso!" ClientValidationFunction="ValidarTermosUso" OnServerValidate="TermosUso_ServerValidate"></asp:CustomValidator>
                </div>
                <div class="text-center">
                    <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
                </div>
                <div class="text-right">
                    <asp:Button ID="btnCadastrar" CssClass="btn btn-primary btn-lg" runat="server" Text="Cadastrar" />
                </div>
                <br />
                <div class="text-center">
                    <asp:Label ID="lblCadastro" Text="Já possui uma conta? Faça o seu " runat="server" /><a href="Login">Login</a>
                </div>
            </form>
        </div>
    </div>
</asp:Content>