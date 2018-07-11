<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="EditarEstab.aspx.cs" Inherits="Pages_EditarEstab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="container">
        <fieldset>
            <div class="row">
                <div class="col-sm-2 border-edit">
                    <ul class="nav nav-pills nav-stacked">
                        <li role="presentation" id="liEditarPerfil" runat="server">
                            <asp:LinkButton ID="lkbEditarPerfil" OnClick="MudarView" runat="server" CommandName="perfil" CssClass="adm-menu">Editar Perfil</asp:LinkButton></li>
                        <li role="presentation" id="liConta" runat="server">
                            <asp:LinkButton ID="lkbConta" OnClick="MudarView" CommandName="conta" CssClass="adm-menu" runat="server">Alterar Senha</asp:LinkButton></li>
                        <li role="presentation" id="liMeusServicos" runat="server">
                            <asp:LinkButton ID="lkbMeusServicos" OnClick="MudarView" runat="server" CommandName="meusservicos" CssClass="adm-menu">Meus Serviços</asp:LinkButton></li>
                        <li role="presentation" id="liAddServicos" runat="server">
                            <asp:LinkButton ID="lkbAddServicos" OnClick="MudarView" runat="server" CommandName="addservicos" CssClass="adm-menu">Adicionar Serviços</asp:LinkButton></li>
                        <li role="presentation" id="liPlus" runat="server">
                            <asp:LinkButton ID="lkbPlus" OnClick="MudarView" runat="server" CommandName="plus" CssClass="adm-menu">Plus</asp:LinkButton></li>
                    </ul>
                </div>
                <div class="col-sm-8">
                    <asp:MultiView ID="mtvEditarEstab" runat="server">
                        <%--VIEW 1 EDITAR PERFIL--%>
                        <asp:View ID="vEditarPerfil" runat="server">
                            <h3 class="text-center font-notosans">Editar Perfil</h3>
                            <hr />
                            <div class="form-group">
                                <asp:TextBox ID="txbEditCodEst" class="form-control input-sm text-left" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Nome Fantasia:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditFantasia" class="form-control text-left" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">CNPJ:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditCnpj" class="form-control text-left" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Razão Social:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditRazaoSocial" class="form-control text-left" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">CEP:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditCep" class="form-control text-left" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Endereço:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditEnd" class="form-control text-left" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Nº:</div>
                                    <div class="col-sm-2">
                                        <asp:TextBox ID="txbEditNum" class="form-control text-left" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Bairro:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditBairro" class="form-control text-left" ReadOnly="true" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Cidade:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditCidade" class="form-control text-left" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">UF:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditUf" class="form-control text-left" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Responsável:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditNomeResponsavel" class="form-control text-left" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Telefone:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditTel" class="form-control text-left" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">Celular:</div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txbEditCel" class="form-control text-left" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txbImgUrl" class="form-control text-left" runat="server" Visible="false"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm-4"></div>
                                <div class="col-sm-3">
                                    <asp:Button ClientIDMode="Static" ID="btnEditCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnEditCancelar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ClientIDMode="Static" ID="btnEditConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-purple" OnClick="btnEditConfirmar_Click" />
                                </div>
                            </div>
                        </asp:View>

                        <%--VIEW 2 - EDITAR CONTA--%>

                        <asp:View ID="vConta" runat="server">
                            <h3 class="text-center font-notosans">Alterar Senha</h3>
                            <hr />
                            <div class="form-group">
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">
                                        Senha:
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" ID="txbSenha" CssClass="form-control text-left" TextMode="Password" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">
                                        Nova senha:
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" ID="txbNovaSenha" CssClass="form-control text-left" TextMode="Password" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3 text-right padd-top-txt">
                                        Digite Novamente:
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox runat="server" ID="txbConfirmarSenha" CssClass="form-control text-left" TextMode="Password" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm-3">
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:Label ID="lblErro" Text="" runat="server" CssClass="lbl-erro" />
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <div class="col-sm-4"></div>
                                    <div class="col-sm-3">
                                        <asp:Button ClientIDMode="Static" ID="btnEditSenhaCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnEditSenhaCancelar_Click" />
                                    </div>
                                    <div class="col-sm-3">
                                        <asp:Button ClientIDMode="Static" ID="btnEditSenhaConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-purple" OnClick="btnEditSenhaConfirmar_Click" />
                                    </div>
                                </div>
                            </div>
                        </asp:View>

                        <%-- VIEW 3 MEUS SERVIÇOS --%>
                        <asp:View ID="vMeusServicos" runat="server">
                            <h3 class="text-center font-notosans">Meus Serviços</h3>
                            <hr />
                            <asp:GridView ID="gdvMeusServicos" runat="server" CssClass="table table-responsive table-bordered table-hover table-striped font-notosans" AutoGenerateColumns="False" OnRowCommand="gdvMeusServicos_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="tipo_pai" HeaderText="Categoria" />
                                    <asp:BoundField DataField="tipo_servico" HeaderText="Tipo" />
                                    <asp:BoundField DataField="nome" HeaderText="Descrição" />
                                    <asp:BoundField DataField="valor" HeaderText="Preço" DataFormatString="{0:C}" />
                                    <asp:TemplateField HeaderText="Excluir" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkExcluir" runat="server" CommandName="Excluir" CommandArgument='<%#Bind("codigo") %>' Text=""><span class="glyphicon glyphicon-remove-circle glyphicon-red"></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label Text="" runat="server" ID="lblResultMeusServicos" />

                            <hr />

                        </asp:View>
                        <%--VIEW 4 ADICIONAR SERVIÇOS--%>
                        <asp:View ID="vAddServicos" runat="server">
                            <h3 class="text-center font-notosans">Adicionar Serviços</h3>
                            <hr />
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <p class="text-right">Tipo de serviço:</p>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlTipoServico" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoServico_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <p class="text-right">Sub-tipo de serviço:</p>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlSubTipoServico" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <p class="text-right">Descrição:</p>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txbNomeServico" runat="server" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <p class="text-right">Preço:</p>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="input-group">
                                            <span class="input-group-addon">R$</span>
                                            <asp:TextBox ID="txbValorServico" runat="server" CssClass="form-control text-right" />
                                            <%--<span class="input-group-addon">.00</span>--%>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <p class="text-right">Promoção:</p>
                                    </div>
                                    <div class="col-sm-6">

                                        <input type="checkbox" value="" id="cbxPromocao" />

                                    </div>
                                </div>
                            </div>
                            <div id="promocao">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <p class="text-right">Preço promocional:</p>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="input-group">
                                                <span class="input-group-addon">R$</span>
                                                <asp:TextBox ID="txbValorPromocao" runat="server" CssClass="form-control text-right" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <p class="text-right">Período:</p>
                                        </div>
                                        <div class="col-sm-3">
                                            <p>De:</p>
                                            <asp:TextBox ID="txbDataInicio" runat="server" CssClass="form-control" TextMode="DateTime" />
                                        </div>
                                        <div class="col-sm-3">
                                            <p>Até:</p>
                                            <asp:TextBox ID="txbDataFim" runat="server" CssClass="form-control" TextMode="DateTime" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-3">
                                    <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnEditCancelar_Click" />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="btnAdicionarServico" runat="server" Text="Adicionar" CssClass="btn btn-purple" OnClick="btnAdicionarServico_Click" />
                                </div>
                                <div class="col-sm-3"></div>
                            </div>

                        </asp:View>

                        <%-- VIEW 5 - PLUS --%>

                        <asp:View ID="vPlus" runat="server">
                            <h3 class="text-center font-notosans">Plus</h3>
                            <hr />
                            <p class="text-title-plus">O que é/como funciona o Plus?</p>
                            <p class="text-plus">
                                Plus é um mecanismo para DESTACAR seu estabelecimento no sistema <i>BellaWeb</i>.
                        Ele funciona de modo onde os resultados das pesquisas, privilegiam estabelecimentos PLUS, destacando o serviço e o estabelecimento que o possui.
                            </p>
                            <br />

                            <p class="text-title-plus">Vale a pena?</p>
                            <p class="text-plus">Se você está buscando uma maior visibilidade pelos seus clientes, vale muito a pena. Market é o maior aliado da empresa, clientes que acessarem o sistema verão primeiramente os estabelecimentos que aderirem o mecanismo Plus. </p>
                            <p class="text-plus">Você desembolsará um valor simbólico que trará resultados em pouco tempo, não perca essa oportunidade, seja Plus!</p>
                            <br />

                            <p class="text-title-plus">Planos Plus</p>

                            <%--<div class="container">--%>
                            <div class="row">
                                <div class="col-md-4 col-sm-4">
                                    <div class="panel panel-danger panel-price">
                                        <div class="panel-heading">
                                            <h3 class="text-center">Plano Plus Mensal</h3>
                                            <p class="text-center">1 Mês</p>
                                        </div>
                                        <div class="panel-body text-center">
                                            <p class="lead" style="font-size: 30px"><strong>R$50/mês</strong></p>
                                        </div>
                                        <ul class="list-group list-group-flush text-center">
                                            <li class="list-group-item">
                                                <span class="glyphicon glyphicon-calendar"></span>1 mês de contrato.
                                            </li>
                                            <%--<li class="list-group-item">
                                                <span class="glyphicon glyphicon-envelope"></span>Unlimited Email Invitations
                                            </li>
                                            <li class="list-group-item">
                                                <span class="glyphicon glyphicon-heart"></span>Fantastic Support
                                            </li>--%>
                                        </ul>
                                        <div class="panel-footer"><a class="btn btn-lg btn-block btn-danger" href="/fale-conosco">SOLICITAR</a> </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <div class="panel panel-info panel-price">
                                        <div class="panel-heading">
                                            <h3 class="text-center">Plano Plus Trimestral</h3>
                                            <p class="text-center">3 Meses</p>
                                        </div>
                                        <div class="panel-body text-center">
                                            <p class="lead" style="font-size: 30px"><strong>R$40/mês</strong></p>
                                        </div>
                                        <ul class="list-group list-group-flush text-center">
                                            <li class="list-group-item">
                                                <span class="glyphicon glyphicon-calendar"></span>3 meses de contrato.
                                            </li>
                                            <%--<li class="list-group-item">
                                                <span class="glyphicon glyphicon-envelope"></span>Unlimited Email Invitations
                                            </li>
                                            <li class="list-group-item">
                                                <span class="glyphicon glyphicon-heart"></span>Fantastic Support
                                            </li>--%>
                                        </ul>
                                        <div class="panel-footer"><a class="btn btn-lg btn-block btn-danger" href="/fale-conosco">SOLICITAR</a> </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <div class="panel panel-success panel-price">
                                        <div class="panel-heading">
                                            <h3 class="text-center">Plano Plus Semestral</h3>
                                            <p class="text-center">6 Meses</p>
                                        </div>
                                        <div class="panel-body text-center">
                                            <p class="lead" style="font-size: 30px"><strong>R$35/mês</strong></p>
                                        </div>
                                        <ul class="list-group list-group-flush text-center">
                                            <li class="list-group-item">
                                                <span class="glyphicon glyphicon-calendar"></span>6 meses de contrato.
                                            </li>
                                            <%--<li class="list-group-item">
                                                <span class="glyphicon glyphicon-envelope"></span>Unlimited Email Invitations
                                            </li>
                                            <li class="list-group-item">
                                                <span class="glyphicon glyphicon-heart"></span>Fantastic Support
                                            </li>--%>
                                        </ul>
                                        <div class="panel-footer"><a class="btn btn-lg btn-block btn-danger" href="/fale-conosco">SOLICITAR</a> </div>
                                    </div>
                                </div>

                            </div>
                            <%--</div>--%>
                        </asp:View>

                    </asp:MultiView>
                </div>
                <div class="col-sm-2"></div>
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

