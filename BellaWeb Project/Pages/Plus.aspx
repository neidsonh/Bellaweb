<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="Plus.aspx.cs" Inherits="Pages_Plus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="container class-paddingTop17px">
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <fieldset>
                    <h3 class="text-center text-principal-analise-estab">Plus<small> - Ativar/Desativar</small></h3>
                    <div class="row">
                        <p class="text-estab-informacoes">
                            Definir estado plus do estabelecimento <strong>
                                <asp:Label ID="lblNomeFantasia" runat="server" Text=""></asp:Label></strong>
                        </p>
                        <br />
                        <div class="row">
                            <div class="col-sm-4">
                                <p class="text-titulos-informacoes">Nome Responsável: </p>
                            </div>
                            <div class="col-sm-5">
                                <asp:Label ID="lblNomeResponsavel" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <p class="text-titulos-informacoes">Contato: </p>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblTelefone" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                            </div>
                            <div class="col-sm-4">
                                <asp:Label ID="lblCelular" runat="server" Text="" CssClass="text-estab-informacoes"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <hr />

                    <div class="text-center">
                        <div class="btn-group" role="group">                            
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" OnClick="btnCancelar_Click" />
                            <asp:Button Text="Ativar" runat="server" ID="btnPlusAtivar" CssClass="btn btn-success" OnClick="btnPlusAtivar_Click" />
                            <asp:Button Text="Desativar" runat="server" ID="btnPlusDesativar" CssClass="btn btn-danger" OnClick="btnPlusDesativar_Click" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
</asp:Content>

