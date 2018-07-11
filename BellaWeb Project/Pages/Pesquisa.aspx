<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="Pesquisa.aspx.cs" Inherits="Pages_Pesquisa" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
    <link href="../assets/libs/jquery-ui/jquery-ui.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <article>
        <div class="container texto-filter">
            <div class="row">
                <div class="col-sm-12 col-md-2 col-md-offset-5 col-lg-6 col-lg-offset-3">
                    <a href="/">
                        <img src="../assets/img/LogoPrincipal.png" class="img-responsive center-block" style="width: 300px; padding: 10px;" /></a>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3 border-search">
                    <h4 class="text-center">Pesquisa Avançada</h4>
                    <div class="form-group">
                        <div class="input-group-lg">
                            <asp:TextBox ID="txbPesquisa" ClientIDMode="Static" CssClass="form-control" PlaceHolder="Pesquisar por" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="ft-titulo" runat="server">Tipo de pesquisa</label>
                        <div class="input-group-btn">
                            <asp:DropDownList ID="ddlPesquisa" CssClass="btn btn-default btn-sm ddl-search" runat="server">
                                <asp:ListItem Value="">Todos</asp:ListItem>
                                <asp:ListItem Value="servico">Serviços</asp:ListItem>
                                <asp:ListItem Value="estabelecimento">Estabelecimentos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="ft-titulo" runat="server">Cidade</label>
                        <asp:DropDownList ID="ddlCidade" runat="server"
                            CssClass="btn btn-sm btn-default ddl-search" ClientIDMode="Static">
                        </asp:DropDownList>

                    </div>
                    <div class="form-group">
                        <label class="ft-titulo" runat="server">Tipo de Serviço</label>
                        <asp:DropDownList ID="ddlTipo" runat="server"
                            CssClass="btn btn-sm btn-default ddl-search" ClientIDMode="Static"
                            OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                    </div>

                    <div id="divSubtipo" class="form-group" runat="server">
                        <label class="ft-titulo" runat="server">Subtipo de Serviço</label>
                        <asp:DropDownList ID="ddlSubtipo" runat="server"
                            CssClass="btn btn-sm btn-default ddl-search" ClientIDMode="Static">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="ft-titulo" runat="server">Preço</label>
                        <div class="row">
                            <div class="col-sm-6">
                                De:
                                <input id="min" type="text" class="valor input-group form-control" data-index="0" runat="server" />
                            </div>
                            <div class="col-sm-6">
                                Até:
                                <input id="max" type="text" class="valor input-group form-control" data-index="1" runat="server" />
                            </div>
                        </div>

                        <br />
                        <div id="slider" class="range"></div>
                    </div>
                    <div class="form-group">
                        <asp:Button CssClass="btn btn-purple" runat="server" ID="btnPesquisaAvancada" OnClick="btnSearch_ServerClick" Text="Pesquisar" />
                    </div>
                </div>
                <div class="col-sm-9">
                    <div class="border-search">
                        <div class="row">
                            <div class="col-sm-12 texto-filter">
                                <asp:Panel runat="server">
                                    <div class="row">
                                        <div class="col-sm-4">
                                            <label class="ft-titulo" runat="server">Ordenar por: &nbsp</label>
                                            <asp:DropDownList ID="ordem" runat="server" CssClass="btn btn-sm">
                                                <asp:ListItem Value="0" Selected="True">Selecione</asp:ListItem>
                                                <asp:ListItem Value="1">Maior Preço</asp:ListItem>
                                                <asp:ListItem Value="2">Menor Preço</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                        <asp:Panel ID="pHolder" runat="server"></asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </article>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
    <script src="../assets/libs/jquery-ui/jquery-ui.js"></script>
    <script src="../assets/js/RangePrecos.js"></script>
</asp:Content>
