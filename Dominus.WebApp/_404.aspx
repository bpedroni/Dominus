<%@ Page Title="Página não encontrada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="_404.aspx.cs" Inherits="Dominus.WebApp._404" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row m-2 w-100 mx-auto">
        <div class="col-md p-4 m-2 mx-4 bg-light shadow rounded">
            <div class="d-block d-md-flex">
                <div class="col-sm">
                    <h1>Página não encontrada</h1>
                    <p class="lead">Desculpe. A página solicitada não existe ou foi removida.</p>
                    <a href="./" title="Ir para a página inicial"><i class="fas fa-home"></i>&nbsp;Ir para a página inicial</a>
                    <br /><br />
                </div>
                <div class="text-center">
                    <img src="Contents/img/erro404.png" class="img-fluid" style="max-height: 400px;" alt="erro404.png" title="Página não encontrada" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
