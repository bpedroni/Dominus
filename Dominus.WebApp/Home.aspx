<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Dominus.WebApp.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row w-100 mx-auto">
        <div class="col-md p-2 m-3 bg-light">
            <h1>Controle suas finanças</h1>
            <p class="lead">O Dominus é uma solução desenvolvida para auxiliar na sua gestão financeira.</p>
            <p class="lead">Tenha um maior controle de suas receitas e despesas através do uso de uma plataforma que organiza para você os seus recursos.</p>
        </div>
        <div class="col-md">
            <div class="row p-2 m-3 bg-light">
                <div>
                    <h3>Sobre o Dominus</h3>
                    <p>Breve descrição sobre o Dominus</p>
                    <a class="btn btn-default" href="Sobre">Link para página sobre &raquo;</a>
                </div>
            </div>
            <div class="row p-2 m-3 bg-light">
                <div>
                    <h3>Dicas de uso do Dominus</h3>
                    <p>Breve descrição do uso do Dominus</p>
                    <a class="btn btn-default" href="Contato">Link para página de contato &raquo;</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
