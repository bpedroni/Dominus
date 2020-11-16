<%@ Page Title="Contato" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="Dominus.WebApp.Contato" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validarForm(button) {
            var msg = document.getElementById("<%=lblMsg.ClientID %>");
            msg.textContent = '';

            var nome = document.getElementById("<%=txtNome.ClientID %>");
            var email = document.getElementById("<%=txtEmail.ClientID %>");
            var assunto = document.getElementById("<%=txtAssunto.ClientID %>");
            var mensagem = document.getElementById("<%=txtMensagem.ClientID %>");

            if (!nome.validity.valid || !email.validity.valid || !assunto.validity.valid || !mensagem.validity.valid) {
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
            <h5 class="text-center">Registre seu contato</h5>
        </div>
        <div class="card-body">
            <div class="form-group input-group" title="Insira o seu nome">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="far fa-user"></i></span>
                </div>
                <input id="txtNome" name="nome" class="form-control rounded-right" type="text" runat="server" placeholder="Insira seu nome" required oninvalid="setCustomValidity('Insira o seu nome.')" oninput="setCustomValidity('')" maxlength="100" />
            </div>
            <div class="form-group input-group" title="Insira o seu e-mail">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="fas fa-envelope"></i></span>
                </div>
                <input id="txtEmail" name="email" class="form-control rounded-right" type="email" runat="server" placeholder="Insira o seu e-mail" required oninvalid="setCustomValidity('Insira um endereço de e-mail.')" oninput="setCustomValidity('')" maxlength="100" />
            </div>
            <div class="form-group input-group" title="Insira o assunto da mensagem">
                <div class="input-group-prepend">
                    <span class="input-group-text"><i class="far fa-comment"></i></span>
                </div>
                <input id="txtAssunto" name="assunto" class="form-control rounded-right" type="text" runat="server" placeholder="Insira o assunto da mensagem" required oninvalid="setCustomValidity('Insira o assunto da mensagem.')" oninput="setCustomValidity('')" maxlength="50" />
            </div>
            <div class="form-group input-group" title="Insira a mensagem">
                <textarea id="txtMensagem" name="assunto" class="form-control rounded-right" rows="5" runat="server" placeholder="Insira a mensagem" required oninvalid="setCustomValidity('Insira a mensagem.')" oninput="setCustomValidity('')" maxlength="1000"></textarea>
            </div>
            <div class="text-center">
                <asp:Label ID="lblMsg" CssClass="text-danger" runat="server" /><p></p>
            </div>
            <div class="d-flex justify-content-end">
                <span id="loading" class="mr-2 fa-2x text-primary" runat="server" clientidmode="static" hidden><i class="fas fa-spinner fa-spin"></i></span>
                <asp:Button ID="btnEnviar" CssClass="btn btn-primary btn-lg" runat="server" Text="Enviar Mensagem" ToolTip="Enviar mensagem" OnClientClick="validarForm(this);" OnClick="BtnEnviar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
