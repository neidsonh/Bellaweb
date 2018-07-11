<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="CadastroEstab.aspx.cs" Inherits="Pages_CadastroEstab" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">

    <div class="container">
        <div class="well well-lg">
            <h3><strong>Bem vindo a área de Cadastro de Estabelecimento</strong></h3>
            <p>Você deseja ter seus seviços divulgados pela BellaWeb e fazer parte desse grande time?</p>
            <p>Se sim, estaremos felizes em recebê-los! A equipe BellaWeb te dará suporte a tudo que precisar.</p>
            <p>Vamos prosseguir com o cadastro, preencha os campos e prossiga.</p>

        </div>


        <div id="formulario">


            <ul id="progress">
                <li class="ativo">Localização e Informações do Estabelecimento</li>
                <li>Informações de acesso</li>
                <li>Contato / Configurações Finais</li>
            </ul>
            <hr />

            <%---------------Step 1---------------%>

            <fieldset>
                <h2>Verificação de disponibilidade para região</h2>
                <hr />
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-inline">
                            <div class="form-group">
                                <label class="control-label required-warn">CEP</label>
                                <asp:TextBox ID="txbCep" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite o CEP"></asp:TextBox>
                                <input type="button" id="btnChecar" class="btn btn-purple btn-group" value="Checar" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--ESCONDER--%>
                <div id="locationOk">
                    <h2 class="text-left">Informações do Estabelecimento</h2>
                    <hr />
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="control-label required-warn">Nome Fantasia</label>
                                <asp:TextBox ID="txbFantasia" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite o nome fantasia"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="control-label required-warn">Razão Social</label>
                                <asp:TextBox ID="txbRazaoSocial" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite a razao social"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="control-label required-warn">CNPJ</label>
                                <asp:TextBox ID="txbCnpj" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite o CNPJ"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <h2 class="text-left">Localização</h2>
                    <hr />
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="control-label required-warn">Endereço</label>
                                <asp:TextBox ID="txbLogradouro" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label required-warn">Nº</label>
                                <asp:TextBox ID="txbNumero" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite o numero"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <label class="control-label required-warn">UF</label>
                                <asp:TextBox ID="txbUf" ClientIDMode="Static" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="control-label required-warn">Bairro</label>
                                <asp:TextBox ID="txbBairro" ClientIDMode="Static" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <label class="control-label required-warn">Cidade</label>
                                <asp:TextBox ID="txbCidade" ClientIDMode="Static" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <input id="btnFirst" type="button" name="next" class="next acao btn btn-default pull-right" value="Próximo" />
                        <span class="glyphicon glyphicon-question-sign pull-right questions" data-toggle="tooltip" title="Campos com (*) são obrigatórios para prosseguir com o cadastro" data-placement="auto"></span>
                    </div>
                </div>
                <%--Esconder--%>
                <div id="locationFail">
                    <div class="form-group">
                        <h2 class="no-warning">Sistema Indisponível para esta região</h2>
                        <hr />
                        <div class="row">
                            <div class="col-sm-6">
                                <p>O sistema BellaWeb ainda não está disponível para sua região?</p>
                                <p>
                                    <asp:LinkButton ID="lkbContatar" runat="server" OnClick="btnContatar_Click">Contate-nos</asp:LinkButton>
                                    para viabilizarmos a disponibilidade!
                                </p>
                            </div>
                            <div class="col-sm-6">
                                <asp:LinkButton ID="btnContatar" runat="server" CssClass="btn btn-default btn-purple pull-right" Text="Contatar" OnClick="btnContatar_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                 <%--Esconder--%>
                <div id="locationError">
                    <div class="form-group">
                        <h2 class="no-warning">CEP Inválido</h2>
                        <hr />
                        <div class="row">
                            <div class="col-sm-6">
                                <p>CEP digitado é inesistente, digite um CEP válido!</p>
                                </div>
                        </div>
                    </div>
                </div>
            </fieldset>
            <%---------------Step 2---------------%>

            <fieldset>
                <h2 class="text-left">Informações de acesso</h2>
                <hr />
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-6">
                            <label class="control-label required-warn">E-mail</label>
                            <p id="emailResponse" class="label"></p>
                            <asp:TextBox name="txbEmail" ID="txbEmail" ClientIDMode="Static" runat="server" CssClass="form-control required-warn" placeholder="Digite seu email" TextMode="Email"></asp:TextBox>

                        </div>
                        <div class="col-sm-6">
                            <br />
                            <p class="label-informacoes">O seu endereço de e-mail será usado para validar sua entrada no sistema ou caso você solicite recuperação de senha, sua senha sera enviada para esse endereço.</p>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-6">
                            <label class="control-label required-warn">Confirme seu E-mail</label>
                            <asp:TextBox ID="txbConfirmaEmail" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Redigite seu email" TextMode="Email"></asp:TextBox>
                            <p id="emailEquals" class="label"></p>
                        </div>
                    </div>
                </div>

                <hr />

                <div class="form-group">
                    <div class="row" id="pwd-container">
                        <div class="col-sm-6">
                            <label class="control-label required-warn">Escolha uma senha</label>
                            <asp:TextBox ID="txbSenha" ClientIDMode="Static" runat="server" CssClass="form-control" TextMode="Password" placeholder="Digite sua Senha" MaxLength="16"></asp:TextBox>
                            <br />
                            <label class="control-label required-warn">Digite novamente sua senha</label>
                            <asp:TextBox ID="txbConfirmaSenha" ClientIDMode="Static" runat="server" CssClass="form-control" TextMode="Password" placeholder="Digite sua Senha Novamente"></asp:TextBox>

                        </div>
                        <div class="col-sm-6">
                            <br />
                            <p class="label-informacoes">Regras para a criação da senha:</p>
                            <p class="label-informacoes">- Deve conter entre 8 e 16 caracteres.</p>
                            <p class="label-informacoes">- Deve conter um caracter maíusculo.</p>
                            <p class="label-informacoes">- Deve conter um caracter especial(!@#?%&*).</p>
                            <p class="label-informacoes">- Deve conter números.</p>
                            <div id="progressbar"></div>
                        </div>
                    </div>
                </div>
                <hr />

                <div class="form-group ">
                    <input type="button" name="prev" class="prev acao btn btn-default" value="Anterior" />
                    <input type="button" name="next" id="btnSecond" class="next acao btn btn-default pull-right" value="Próximo" />
                    <span class="glyphicon glyphicon-question-sign pull-right questions" data-toggle="tooltip" title="Campos com (*) são obrigatórios para prosseguir com o cadastro" data-placement="auto"></span>
                </div>
            </fieldset>



            <%---------------Step 3---------------%>

            <fieldset>
                <h2>Informações para contato</h2>
                <hr />
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-6">
                            <label class="control-label required-warn">Nome do Responsável</label>
                            <asp:TextBox ID="txbResponsavel" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Digite o nome para contato"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label class="control-label">Telefone</label>
                            <asp:TextBox ID="txbTelefone" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Opcional"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label class="control-label">Celular</label>
                            <asp:TextBox ID="txbCelular" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Opcional"></asp:TextBox>
                        </div>
                    </div>

                    <hr />

                    <div class="row">
                        <div class="col-sm-12">
                            <div class="form-inline" role="form">
                                <div class="checkbox">
                                    <label>
                                        Declaro que li e estou de acordo com os <a href="TermosDeUso.aspx" target="_blank">Termos de Uso</a> e as <a href="PoliticaDePrivacidade.aspx" target="_blank">Políticas de Privacidade</a>.
                                <asp:CheckBox ID="cbTermosDeUso" ClientIDMode="Static" CssClass="checkbox-inline" runat="server" />
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>


                    <input type="button" name="prev" class="prev acao btn btn-default" value="Anterior" />

                    <asp:Button Text="Enviar" CommandName="next" ID="btnEnviar" ClientIDMode="Static"
                        CssClass="acao btn btn-default pull-right" OnClick="btnEnviar_Click"
                        runat="server" />
                </div>
            </fieldset>
        </div>
        <hr />
    </div>


</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
    <script src="../assets/libs/jquery-pwstrength-bootstrap/pwstrength-bootstrap-1.2.10.js"></script>
    <script src="<%=ResolveUrl("~/assets/js/cadastroEstabelecimento.js") %>"></script>
    <script src="../assets/js/Mascaras.js"></script>
    <script src="../assets/js/Validacao.js"></script>
    <script src="../assets/js/ReadOnly.js"></script>
</asp:Content>

