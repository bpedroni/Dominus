<%@ Page Title="Contato" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="Dominus.WebApp.Contato" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#lblChamados').hide();
            if (Boolean($("#<%=lblNovaMsg.ClientID %>").text())) {
                openModalMsg($('#txtRespChamado').val());
            }
            debugger;
        });

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

        function ignorarForm(novaMsg) {
            document.getElementById("<%=txtNome.ClientID %>").required = false;
            document.getElementById("<%=txtEmail.ClientID %>").required = false;
            document.getElementById("<%=txtAssunto.ClientID %>").required = false;
            document.getElementById("<%=txtMensagem.ClientID %>").required = false;
            if (novaMsg)
                document.getElementById("<%=txtEnviarNovaMsg.ClientID %>").required = true;
            else
                document.getElementById("<%=txtEnviarNovaMsg.ClientID %>").required = false;
        }

        function openModalMsg(idChamado) {
            $('#enviarNovaMsgModal').modal('show');
            $('#txtRespChamado').val(idChamado);
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <% if (Usuario != null)
        {%>
    <asp:ScriptManager ID="ScriptManagerContato" runat="server"></asp:ScriptManager>
    <ul class="nav nav-tabs nav-pills m-2" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" href="#ExibirHistorico" data-toggle="tab" role="tab" aria-controls="exibir-historico" aria-selected="false" title="Visualizar histórico de mensagens">Minhas mensagens
                <asp:Label ID="lblChamados" CssClass="blinking badge badge-pill" runat="server" Visible="false" Text="0"></asp:Label>
            </a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="#EnviarMensagem" data-toggle="tab" role="tab" aria-controls="enviar-mensagem" aria-selected="true" title="Enviar Mensagem para o suporte do dominus">Escrever mensagem
            </a>
        </li>
    </ul>
    <div class="tab-content">
        <asp:Panel ID="ExibirHistorico" CssClass="tab-pane active m-2" runat="server" ClientIDMode="Static" role="tabpanel" aria-labelledby="exibir-historico-tab"></asp:Panel>
        <%}%>
        <div id="EnviarMensagem" class="tab-pane card shadow rounded formulario" role="tabpanel" aria-labelledby="enviar-mensagem-tab">
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
        <% if (Usuario != null)
            {%>
    </div>
    <div id="enviarNovaMsgModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="enviarNovaMsgTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 id="enviarNovaMsgTitle" class="modal-title">Nova mensagem</h5>
                    <button type="button" class="close" title="Fechar" data-dismiss="modal" aria-label="Fechar">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="d-none form-group row">
                        <label for="idRespChamado" class="col-3 col-form-label">Id Chamado</label>
                        <div class="col-9">
                            <input id="txtRespChamado" class="form-control" type="text" runat="server" clientidmode="static" readonly />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="idEnviarNovaMsg" class="col-3 col-form-label">Mensagem</label>
                        <div class="col-9">
                            <textarea id="txtEnviarNovaMsg" class="form-control rounded-right" rows="5" runat="server" placeholder="Insira a sua nova mensagem" oninvalid="setCustomValidity('Insira a mensagem.')" oninput="setCustomValidity('')" maxlength="1000"></textarea>
                        </div>
                    </div>
                    <div class="text-center">
                        <asp:Label ID="lblNovaMsg" CssClass="text-danger" runat="server" /><p></p>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnEnviarNovaMsg" CssClass="btn btn-info" runat="server" Text="Enviar" ToolTip="Enviar nova mensagem" OnClientClick="ignorarForm(true)" OnClick="GerenciarChamado" CommandName="NovaMensagemChamado" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
    <%}%>
</asp:Content>
