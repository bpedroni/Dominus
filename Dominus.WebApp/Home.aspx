<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Dominus.WebApp.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col mx-3 jumbotron">
            <h1>Algum conteúdo</h1>
            <p class="lead">Escrever sobre o Dominus</p>
        </div>
        <div class="col mx-3">
            <div class="row jumbotron">
                <h3>Sobre o Dominus</h3>
                <p>Breve descrição sobre o Dominus</p>
                <br />
                <a class="btn btn-default" href="Sobre">Link para página sobre &raquo;</a>
            </div>
            <div class="row jumbotron">
                <h3>Dicas de uso do Dominus</h3>
                <p>Breve descrição do uso do Dominus</p>
                <br />
                <a class="btn btn-default" href="Contato">Link para página de contato &raquo;</a>
            </div>
        </div>
    </div>
</asp:Content>
