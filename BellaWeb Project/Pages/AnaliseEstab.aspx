<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="AnaliseEstab.aspx.cs" Inherits="Pages_AnaliseEstab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="container class-paddingTop17px">
        <fieldset>
            <h3 class="text-center text-principal-analise-estab">Análise de Cadastro<small> - Autorização de divulgação pela BellaWeb</small></h3>
            <br />
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">E-mail: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblEmail" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">Nome Responsável: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblNomeResponsavel" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">Contato: </p>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblTelefone" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblCelular" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">Nome Fantasia: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblNomeFantasia" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">Razão Social: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblRazaoSocial" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">CNPJ: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblCnpj" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">CEP: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblCep" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">Logradouro: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblLogradouro" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
                <div class="col-sm-1">
                    <p class="text-titulos-informacoes">Nº: </p>
                </div>
                <div class="col-sm-2">
                    <asp:Label ID="lblNumero" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">Bairro: </p>
                </div>
                <div class="col-sm-5">
                    <asp:Label ID="lblBairro" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <p class="text-titulos-informacoes">Cidade: </p>
                </div>
                <div class="col-sm-4">
                    <asp:Label ID="lblCidade" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
                <div class="col-sm-2">
                    <p class="text-titulos-informacoes">UF: </p>
                </div>
                <div class="col-sm-3">
                    <asp:Label ID="lblEstado" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                </div>
            </div>

            <hr />

            <div class="text-center">
                <div class="btn-group" role="group">
                    <asp:Button ID="btnCancelar" runat="server" Text="Voltar" CssClass="btn btn-default" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnNegar" runat="server" Text="Negar" CssClass="btn btn-danger" OnClick="btnNegar_Click" />
                    <asp:Button ID="btnAguardar" runat="server" Text="Aguardar" CssClass="btn btn-info" OnClick="btnAguardar_Click" />
                    <asp:Button ID="btnAprovar" runat="server" Text="Aprovar" CssClass="btn btn-success" OnClick="btnAprovar_Click" />
                </div>
            </div>


        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
</asp:Content>

