<%@ Page Title="Sobre o Dominus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="Dominus.WebApp.Sobre" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="accordion" class="row m-2 w-100 mx-auto">
        <div class="col-md">
            <div class="row p-4 m-3 bg-light shadow rounded">
                <a id="titleSobre" data-toggle="collapse" href="#collapseSobre" title="Sobre o Dominus" aria-expanded="true" aria-controls="collapseSobre">
                    <h3>Sobre o Dominus</h3>
                </a>
                <div id="collapseSobre" class="collapse show" data-parent="#accordion" aria-controls="titleSobre">
                    <p class="lead font-weight-normal">Grande parte dos lares brasileiros não faz nenhum tipo de controle sobre as finanças domésticas. Quando olhamos para o currículo escolar, observamos que o tópico é pouco abordado pelos educadores. Essa condição nos leva a uma situação onde a população em geral tem pouco conhecimento sobre o assunto e é exposta a produtos financeiros incrementalmente variados e complexos.</p>
                    <p class="lead font-weight-normal">O endividamento e a inadimplência são grandes fatores de estresse da vida cotidiana. O conhecimento e a tecnologia da informação podem ser importantes aliados contra as adversidades financeiras.</p>
                    <p class="lead font-weight-normal">O Dominus oferece ferramentas que permitem ao usuário entender a evolução de sua condição financeira, desta forma, permitindo que tome suas decisões de maneira melhor e mais informada.</p>
                </div>
            </div>
            <div class="row p-4 m-3 bg-light shadow rounded">
                <a id="titleDicas" data-toggle="collapse" href="#collapseDicas" title="Dicas de uso do Dominus" aria-expanded="false" aria-controls="collapseDicas">
                    <h3>Dicas de uso do Dominus</h3>
                </a>
                <div id="collapseDicas" class="collapse" data-parent="#accordion" aria-controls="titleDicas">
                    <p class="lead font-weight-normal">A principal qualidade para se manter um bom controle financeiro é a disciplina. Guarde todos os recibos, notas fiscais e anotações sobre receitas e despesas para lançá-las no site quando tiver um tempo livre com paciência.</p>
                    <p class="lead font-weight-normal">Lembre-se que a qualidade e precisão de seus relatórios serão tão bons quanto a qualidade dos dados inseridos. Execute os lançamentos com atenção e consciência.</p>
                    <p class="lead font-weight-normal">Agrupar despesas com características afins dá um entendimento melhor do seu orçamento, as categorias representam essa função.</p>
                    <p class="lead font-weight-normal">Veja mais algumas dicas abaixo:</p>
                    <ul class="list">
                        <li class="list-item lead font-weight-normal">Evite duplicidades: é fácil se confundir e lançar uma mesma transação duas vezes. Verifique se uma transação já foi lançada, especialmente para pagamentos parcelados ou pagos com cartão de crédito (certifique-se de lançar apenas a nota fiscal ou os respectivos pagamentos do cartão de crédito).</li>
                        <li class="list-item lead font-weight-normal">Estude as categorias pré-definidas e lance as despesas recorrentes nas mesmas categorias todo mês. É possível reclassificar as despesas, mas esse cuidado evita retrabalhos.</li>
                        <li class="list-item lead font-weight-normal">Encargos/receitas financeiras (multa, juros, taxas, ágio etc) são fluxos importantes e nem sempre aparecem com destaque nos documentos. Elas tem categorias distintas no site.</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
