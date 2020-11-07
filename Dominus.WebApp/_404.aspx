<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="_404.aspx.cs" Inherits="Dominus.WebApp._404" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="p-2 m-3 bg-light">
        <h1>Página não encontrada</h1>
        <p class="lead">Desculpe. A página solicitada não existe ou foi removida.</p>
        <a href="./" title="Ir para a página inicial">Ir para a página inicial</a>
    </div>
</asp:Content>
