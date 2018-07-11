<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MastersPages/Index.master" CodeFile="Index.aspx.cs" Inherits="Pages_Index" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="server">
    <link href="../assets/css/carousel.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="server">
    <article>
        <div>
            <img src="../assets/img/LogoPrincipal.png" class="img-responsive center-block img-logo" />
            <div style="width: 600px;" class="center-block">
                <div class="form-group input-group" style="padding-top: 10px;">
                    <asp:TextBox ID="txbPesquisa" CssClass="form-control input-lg search-input" PlaceHolder="Pesquisar" runat="server" />
                    <div class="input-group-btn">
                        <asp:DropDownList ID="ddlPesquisa" CssClass="btn btn-default btn-lg ddl-search-index" runat="server">
                            <asp:ListItem Value="">Todos</asp:ListItem>
                            <asp:ListItem Value="servico">Serviços</asp:ListItem>
                            <asp:ListItem Value="estabelecimento">Estabelecimentos</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="input-group-btn">
                        <button class="btn btn-default btn-lg" type="submit" id="btnSearch" onserverclick="btnSearch_ServerClick" runat="server"><i class="glyphicon glyphicon-search"></i></button>
                    </div>
                </div>
            </div>
        </div>

        <%--Container Index--%>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="row">

                        <%--Esquerda - Carousel--%>

                        <div class="col-sm-6">
                            <br />
                            <asp:Panel runat="server" ID="destaquesContainer"></asp:Panel>
                        </div>

                        <%--Direita - Carousel--%>

                        <div class="col-sm-6">
                            <br />
                            <div id="myCarousel2" class="carousel slide" data-ride="carousel">

                                <!-- Indicators -->
                                <ol class="carousel-indicators">
                                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                                    <li data-target="#myCarousel" data-slide-to="1"></li>
                                    <li data-target="#myCarousel" data-slide-to="2"></li>
                                </ol>

                                <!-- PROMOÇÕES E PLUS -->
                                <div class="carousel-inner" role="listbox">

                                    <div class="item active">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="position-img">
                                                            <img src="../assets/img/tipo-servico-01.jpg" class="img-responsive full-screen" />
                                                        </div>
                                                        <div class="text-img">
                                                            <a class="carousel-link" href="#">Promoções</a>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="position-img">
                                                            <img src="../assets/img/logo-salao-01.jpg" class="img-responsive full-screen" />
                                                        </div>
                                                        <div class="text-img">
                                                            <a class="carousel-link" href="#">Venha conhecer nossos serviços</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <br />

                                        <div class="row">
                                            <div class="col-sm-12">
                                                <div class="row">
                                                    <div class="col-sm-6">
                                                        <div class="position-img">
                                                            <img src="../assets/img/logo-salao-02.jpg" class="img-responsive full-screen" />
                                                        </div>
                                                        <div class="text-img">
                                                            <a class="carousel-link" href="#">Venha conhecer nossos serviços</a>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="position-img">
                                                            <img src="../assets/img/tipo-servico-02.jpg" class="img-responsive full-screen" />
                                                        </div>
                                                        <div class="text-img">
                                                            <a class="carousel-link" href="#">Promoções</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Left and right controls -->
                                    <a class="left carousel-control" href="#myCarousel2" role="button" data-slide="prev">
                                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="right carousel-control" href="#myCarousel2" role="button" data-slide="next">
                                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <hr />

                <div class="row">
                    <div class="col-sm-12">
                        <div class="row row-modify-apresentation">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-8 center-block text-center texto">
                                <p>
                                    O <strong>BellaWeb</strong> é uma plataforma de <strong>BUSCA</strong> para localizar serviços 
                                    e estabelecimentos de beleza e estética mais próximos a você.
                                </p>
                                <p>De forma simples, rápida e prática! </p>
                                <p>Siga apenas 3 passos!  </p>
                            </div>
                            <div class="col-sm-2"></div>
                        </div>
                    </div>
                </div>

                <br />

                <%--Passo 1--%>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-6">
                                <img src="../assets/img/search-logo.JPG" alt="searchBellaWeb" class="center-block img-responsive" />
                            </div>

                            <div class="col-sm-6">
                                <div class="instruction text-center center-block texto-passos">
                                    <p class="title-passos">1. PESQUISE SALÕES OU SERVIÇOS</p>
                                    <p>Digite o serviço que procura, exemplo: Corte de Cabelo, Depilação Perna, etc. Ou o salão: SkinaHair e Prossiga.</p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <%--Passo 2--%>

                <div class="row">
                    <div class="col-sm-12 full-screen">
                        <div class="row row-modify-servico">
                            <div class="col-sm-6">
                                <div class="instruction text-center center-block texto-passos">
                                    <p class="title-passos">2. SELECIONE O SERVIÇO</p>
                                    <p>O resultado da sua busca anterior será exibido, você pode filtrar resultados!</p>
                                    <p>Selecione o serviço que lhe achar mais atraente e prossiga!</p>
                                </div>
                            </div>

                            <div class="col-sm-6">
                                <img src="../assets/img/LogoLocaliza.png" alt="maps-icon" style="width: 300px" class="center-block" />
                            </div>


                        </div>
                    </div>
                </div>

                <%--Passo 3--%>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="row row-modify-servico">
                            <div class="col-sm-6">
                                <img src="../assets/img/LogoContato.png" alt="phone-icon" style="width: 300px" class="center-block" />
                            </div>

                            <div class="col-sm-6">
                                <div class="instruction text-center center-block texto-passos">
                                    <p class="title-passos">3. CONTATO</p>
                                    <p>Pronto! Será exibido o perfil do Estabelecimento, com informações de contato, localização, horário de funcionamento e serviços.</p>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>



            </div>
        </div>
    </article>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="server">
    <script src="<%= ResolveUrl("~/assets/js/ServicoNotify.js") %>"></script>
    <script>
        run('<%= notify %>');
    </script>  
</asp:Content>
