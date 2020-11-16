<%@ Page Title="Erro Inesperado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Erro.aspx.cs" Inherits="Dominus.WebApp.Erro" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row m-2 w-100 mx-auto">
        <div class="col-md p-4 m-2 mx-4 bg-light shadow rounded">
            <div class="d-block d-md-flex">
                <div class="col-sm">
                    <h1>Erro em tempo de execução</h1>
                    <p class="lead">Ocorreu um erro ao processar a sua solicitação.</p>
                    <p class="lead">Entre em contato com a equipe de suporte do Dominus para que este problema seja analisado e corrigido.</p>
                    <br />
                    <a href="./" title="Ir para a página inicial"><i class="fas fa-home"></i>&nbsp;Ir para a página inicial</a>
                    <br /><br />
                    <a href="./Contato" title="Ir para a página de contato"><i class="fas fa-at"></i>&nbsp;Ir para a página de contato</a>
                    <br /><br />
                </div>
                <div class="text-center">
                    <img src="Contents/img/erro.png" class="img-fluid" style="max-height: 400px;" alt="erro.png" title="Erro inesperado" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
