<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="AdmIndex.aspx.cs" Inherits="Pages_AdmIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="container class-paddingTop17px">
        <fieldset>
            <div class="row">
                <p class="text-center title-adm-page">Painel Administrativo</p>

                <div class="col-sm-2 border-search">
                    <ul class="nav nav-pills nav-stacked">
                        <li role="presentation" id="liCadastros" runat="server">
                            <asp:LinkButton ID="lkbEstabelecimentos" OnClick="MudarView" runat="server" CssClass="adm-menu">Estabelecimentos</asp:LinkButton></li>

                        <li role="presentation" id="liServicos" runat="server">
                            <asp:LinkButton ID="lkbServicos" OnClick="MudarView" runat="server" CssClass="adm-menu">Serviços</asp:LinkButton></li>

                        <li role="presentation" id="liCidades" runat="server">
                            <asp:LinkButton ID="lkbCidades" OnClick="MudarView" runat="server" CssClass="adm-menu">Cidades / Estados</asp:LinkButton></li>

                        <li role="presentation" id="liDestaques" runat="server">
                            <asp:LinkButton ID="lkbDestaques" OnClick="MudarView" runat="server" CssClass="adm-menu">Destaques</asp:LinkButton></li>

                    </ul>
                </div>
                <div class="col-sm-10">
                    <asp:MultiView ID="mtvAdm" runat="server">
                        <%--VIEW 1 Cadastros Ativos--%>
                        <asp:View ID="vCadastros" runat="server">
                            <div class="form-horizontal filtro-adm">
                                <div class="form-group">
                                    <label class="col-sm-4 col-xs-1 control-label">Filtro</label>
                                    <div class="col-sm-3 col-xs-2">
                                        <asp:DropDownList ID="ddlEstadoAtivacao" CssClass="form-control dropdown text-center" OnSelectedIndexChanged="ddlEstadoAtivacao_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                            <asp:ListItem Value="" Text="Todos"></asp:ListItem>
                                            <asp:ListItem Value="APROVADO" Text="Aprovados"></asp:ListItem>
                                            <asp:ListItem Value="AGUARDANDO" Text="Aguardando"></asp:ListItem>
                                            <asp:ListItem Value="NEGADO" Text="Negados"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <asp:GridView ID="gdvEstabelecimentos" runat="server" CssClass="table table-responsive table-bordered table-hover table-striped" OnRowCommand="gdvEstabelecimentos_RowCommand" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="est_fantasia" HeaderText="Nome Fantasia" />
                                    <asp:BoundField DataField="est_plus" HeaderText="Plus" />
                                    <asp:BoundField DataField="est_razaosocial" HeaderText="Razão Social" />
                                    <asp:BoundField DataField="est_cnpj" HeaderText="CNPJ" />
                                    <asp:BoundField DataField="est_nomeresponsavel" HeaderText="Responsável" />
                                    <asp:BoundField DataField="est_telefone" HeaderText="Telefone" />
                                    <asp:BoundField DataField="est_celular" HeaderText="Celular" />
                                    <asp:BoundField DataField="est_ativacaoestado" HeaderText="Estado de Ativação" />

                                    <asp:TemplateField HeaderText="" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <ul class="nav navbar-nav menu">
                                                <li class="dropdown">
                                                    <button class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown"
                                                        role='button' aria-haspopup='true' aria-expanded='false'>
                                                        Opção <span class="caret"></span>
                                                    </button>

                                                    <ul class="dropdown-menu">
                                                        <li>
                                                            <asp:LinkButton ID="linkChecar" runat="server" CommandName="Editar" CommandArgument='<%#Bind("est_codigo") %>'>
                                                            <span class="glyphicon glyphicon-pencil"></span>&nbsp Analisar</asp:LinkButton></li>
                                                        <li><asp:LinkButton ID="linkPlus" runat="server" CommandName="Plus" CommandArgument='<%#Bind("est_codigo") %>'>
                                                            <span class="glyphicon glyphicon-plus"></span>&nbsp Plus</asp:LinkButton></li>
                                                    </ul>
                                                </li>
                                            </ul>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label Text="" runat="server" ID="lblResultEstAtivos" />
                            <hr />
                        </asp:View>
                        <%--VIEW 2 Adicionar/Excluir Serviços--%>
                        <asp:View ID="vServicos" runat="server">

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <h4>Tipo de Serviço</h4>
                                        <label class="control-label">Nome</label>
                                        <asp:TextBox ID="txbAddServico" ClientIDMode="Static" runat="server" CssClass="form-control text-center" placeholder="Digite um novo serviço"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Button ID="btnAddServico" Text="Cadastrar" runat="server" CssClass="btn btn-purple" OnClick="btnAddServico_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label class="control-label">Nome</label>
                                        <asp:DropDownList ID="ddlExcluirServico" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">
                                        <br />
                                        <asp:Button ID="btnExcluirTipoServico" Text="Excluir" runat="server" CssClass="btn btn-danger" OnClick="btnExcluirTipoServico_Click" />
                                    </div>
                                    <div class="col-sm-4">
                                        <br />
                                        <p class="label label-default">Obs: Para excluir um Serviço, ele não</p>
                                        <p class="label label-default ">pode ter nenhum SubServiço atrelado.</p>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <h4>SubTipo de Serviço</h4>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <label class="control-label">Tipo de Serviço</label>
                                        <asp:DropDownList ID="ddlServico" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label">SubTipo de Serviço</label>
                                        <asp:TextBox ID="txbAddTipoServico" ClientIDMode="Static" runat="server" CssClass="form-control text-center" placeholder="Nome do Subtipo"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <br />
                                        <asp:Button ID="btnAddTipoServico" Text="Cadastrar" runat="server" CssClass="btn btn-purple" OnClick="btnAddTipoServico_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3">
                                        <label class="control-label">Tipo de Serviço</label>
                                        <asp:DropDownList ID="ddlSelectExcluirServico" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static" OnSelectedIndexChanged="ddlSelectExcluirServico_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4">
                                        <label class="control-label">SubTipo de Serviço</label>
                                        <asp:DropDownList ID="ddlExcluirSubTipo" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <br />
                                        <asp:Button ID="btnExcluirSubTipo" Text="Excluir" runat="server" CssClass="btn btn-danger" OnClick="btnExcluirSubTipo_Click" />
                                    </div>
                                </div>

                            </div>
                        </asp:View>

                        <%--VIEW 3 Adicionar/Excluir Cidade--%>
                        <asp:View ID="vCidades" runat="server">
                            <p class="h4">Cidades</p>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <label class="control-label">UF</label>
                                        <asp:DropDownList ID="ddlUf" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="control-label">Cidade</label>
                                        <asp:TextBox ID="txbAddCidade" ClientIDMode="Static" runat="server" CssClass="form-control text-center" placeholder="Digite o nome da Cidade"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <br />
                                        <asp:Button ID="btnAddCidade" Text="Cadastrar" runat="server" CssClass="btn btn-purple" OnClick="btnAddCidade_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <label class="control-label">UF</label>
                                        <asp:DropDownList ID="ddlUf2" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static" OnSelectedIndexChanged="ddlUf2_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="control-label">Cidade</label>
                                        <asp:DropDownList ID="ddlCidade" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <br />
                                        <asp:Button ID="btnExcluirCidade" Text="Excluir" runat="server" CssClass="btn btn-danger" OnClick="btnExcluirCidade_Click" />
                                    </div>
                                </div>
                            </div>
                            <hr />

                            <p class="h4">Estados</p>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <label class="control-label">UF Sigla</label>
                                        <asp:TextBox ID="txbAddUfSigla" ClientIDMode="Static" runat="server" CssClass="form-control text-center" placeholder="Ex: SP, RJ, MG"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="control-label">UF Nome</label>
                                        <asp:TextBox ID="txbAddUfNome" ClientIDMode="Static" runat="server" CssClass="form-control text-center" placeholder="Digite o nome do Estado"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3">
                                        <br />
                                        <asp:Button ID="btnAddUf" Text="Cadastrar" runat="server" CssClass="btn btn-purple" OnClick="btnAddUf_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <label class="control-label">UF Sigla</label>
                                        <asp:DropDownList ID="ddlUf3" runat="server"
                                            CssClass="form-control dropdown text-center" ClientIDMode="Static" OnSelectedIndexChanged="ddlUf3_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3">
                                        <label class="control-label">UF Nome</label><br />
                                        <asp:Label ID="lblExcluirUf" runat="server" Text="" class="control-label text-center"></asp:Label>
                                    </div>
                                    <div class="col-sm-3">
                                        <br />
                                        <asp:Button ID="btnExcluirUf" Text="Excluir" runat="server" CssClass="btn btn-danger" OnClick="btnExcluirUf_Click" />
                                    </div>
                                </div>
                            </div>

                        </asp:View>

                        <%--VIEW 4 Destaques--%>
                        <asp:View ID="vDestaques" runat="server">
                            <p class="h4">Destaques</p>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label class="control-label">Url do destaque</label>
                                        <asp:TextBox ID="txbUrlDestaque" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite a url da noticia em destaque"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label class="control-label">Url da imagem</label>
                                        <asp:TextBox ID="txbUrlImagem" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite a url da imagem"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-4">
                                        <label class="control-label">Titulo</label>
                                        <asp:TextBox ID="txbTitulo" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite um titulo"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-sm-4">
                                        <asp:Button ID="btnCadastrarDestaque" Text="Cadastrar" runat="server" CssClass="btn btn-purple" OnClick="btnCadastrarDestaque_Click" />
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <br />
                            <div>
                                <asp:GridView ID="gdvDestaques" runat="server" CssClass="table table-responsive table-bordered table-hover table-striped" AutoGenerateColumns="False" OnRowCommand="gdvDestaques_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="des_titulo" HeaderText="Título" />
                                        <asp:HyperLinkField DataNavigateUrlFields="des_url" DataTextField="des_url" HeaderText="URL Destaque" Target="_blank" />
                                        <asp:BoundField DataField="adm_nome" HeaderText="Adicionado por" />
                                        <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkExcluir" runat="server" CommandName="Excluir" CommandArgument='<%#Bind("des_codigo") %>' Text=""><span class="glyphicon glyphicon-remove-circle glyphicon-red"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:ImageField DataImageUrlField="des_imgurl" HeaderText="Imagem" ItemStyle-CssClass="img-responsive">
                                    </asp:ImageField>--%>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblResultDestaques" runat="server" Text=""></asp:Label>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </div>
        </fieldset>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
    <script src="<%= ResolveUrl("~/assets/js/ServicoNotify.js") %>"></script>
    <script>
        run('<%= notify %>');
    </script>
</asp:Content>

