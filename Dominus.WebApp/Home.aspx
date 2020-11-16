<%@ Page Title="Dominus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Dominus.WebApp.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row m-2 w-100 mx-auto">
        <div class="col-md p-4 m-2 bg-light shadow rounded">
            <div class="d-block d-md-flex">
                <div class="col-md">
                    <h1>Controle suas finanças</h1>
                    <p class="lead font-weight-normal">O Dominus é uma solução desenvolvida para auxiliar na sua gestão financeira.</p>
                    <p class="lead font-weight-normal">Tenha um maior controle de suas receitas e despesas através do uso de uma plataforma que organiza para você os seus recursos.</p>
                </div>
                <div class="text-center">
                    <img src="Contents/img/financas.png" class="img-fluid" style="max-height: 300px;" alt="finanças.png" title="Controle suas finanças" />
                </div>
            </div>
        </div>
        <div class="w-100"></div>
        <div class="col-md p-4 m-2 bg-light shadow rounded">
            <h3>Sobre o Dominus</h3>
            <p class="lead font-weight-normal">Conheça mais sobre o site e a sua finalidade.</p>
            <a class="lead font-weight-normal" href="Sobre" title="Ir para a página sobre">Link para página sobre &raquo;</a>
        </div>
        <div class="col-md p-4 m-2 bg-light shadow rounded">
            <h3>Entre em contato</h3>
            <p class="lead font-weight-normal">Envie sua mensagem para a equipe do dominus para tirar suas dúvidas, fazer sugestões ou se encontrar algum problema.</p>
            <a class="lead font-weight-normal" href="Contato" title="Ir para a página contato">Link para página de contato &raquo;</a>
        </div>
    </div>
</asp:Content>
