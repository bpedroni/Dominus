<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Erro.aspx.cs" Inherits="Dominus.WebApp.Erro" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="p-2 m-3 bg-light">
        <h1>Erro em tempo de execução</h1>
        <p class="lead">Ocorreu um erro ao processar a sua solicitação.</p>
        <p class="lead">Entre em contato com a equipe de suporte do Dominus para que este problema seja analisado e corrigido.</p>
        <a href="./" title="Ir para a página inicial">Ir para a página inicial</a>
    </div>
</asp:Content>
