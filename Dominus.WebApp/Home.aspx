<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Dominus.WebApp.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Algum conteúdo</h1>
        <p class="lead">Escrever sobre o Dominus</p>
    </div>
    <div class="row">
        <div class="col-md-6">
            <h2>Sobre o Dominus</h2>
            <p>Breve descrição sobre o Dominus</p>
            <p>
                <a class="btn btn-default" href="Sobre">Link para página sobre &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Dicas de uso do Dominus</h2>
            <p>Breve descrição do uso do Dominus</p>
            <p>
                <a class="btn btn-default" href="Contato">Link para página de contato &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
