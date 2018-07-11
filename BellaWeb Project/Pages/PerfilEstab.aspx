<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="PerfilEstab.aspx.cs" Inherits="Pages_PerfilEstab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../assets/css/Gallery/blueimp-gallery.min.css" rel="stylesheet" />
    <link href="../assets/css/Gallery/bootstrap-image-gallery.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <fieldset>
                    <div class="support" onmouseover="showLink(this)" onmouseout="hideLink(this)">
                        <img src="<%= ImagemUrl %>" id="profile-img" class="img-thumbnail img-responsive" title="Foto Perfil" />
                        <div id="editarFoto" class="img-responsive img-profile-edit">
                            <h5 class="text-edit" id="enviarFoto" runat="server" visible="false">
                                <a href="#" id="photo" data-toggle="modal" data-target=".editarFoto" title="Editar Foto de Perfil">
                                    <span class="glyphicon glyphicon-camera"></span>&nbsp Editar Foto</a></h5>
                        </div>
                    </div>

                    <table class="table table-responsive table-padding">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblEstFantasia" runat="server" Text="" CssClass="label-est-fantasia  text-center"></asp:Label>
                                <br />
                                <asp:Label ID="lblRazaoSocial" runat="server" Text="" CssClass="label-est-razaosocial text-center"></asp:Label>

                                <div class="row">
                                    <div class="col-sm-6">
                                        <asp:Label ID="lblStatusFixo" runat="server" Text="Status" CssClass="label-est-fantasia" Visible="false"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label ID="lblPlusFixo" runat="server" Text="Plus" CssClass="label-est-fantasia" Visible="false"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblPlus" runat="server" Text="" Visible="false"></asp:Label>
                                    </div>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">Endereço: </p>
                            </td>
                            <td>
                                <asp:Label ID="lblEndereco" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">Nº:</p>
                            </td>
                            <td>
                                <asp:Label ID="lblEndNum" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">Bairro: </p>
                            </td>
                            <td>
                                <asp:Label ID="lblBairro" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">Cidade: </p>
                            </td>
                            <td>
                                <asp:Label ID="lblCidade" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">CEP: </p>
                            </td>
                            <td>
                                <asp:Label ID="lblCep" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">UF: </p>
                            </td>
                            <td>
                                <asp:Label ID="lblUf" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">Telefone: </p>
                            </td>
                            <td>
                                <asp:Label ID="lblTelefone" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p class="label-est-atributos">Celular: </p>
                            </td>
                            <td>
                                <asp:Label ID="lblCelular" runat="server" Text="" CssClass="label-est-detalhes"></asp:Label>
                            </td>
                        </tr>
                    </table>

                </fieldset>
            </div>


            <div class="col-sm-8">
                <fieldset>
                    <%--Serviços--%>
                    <div class="service" id="servicos">
                        <p class="label-est-fantasia">
                            <span class="glyphicon glyphicon-scissors icon-profile"></span> Serviços <a class="glyphicon-purple-bellaweb" href="/editar/meusservicos" id="linkAdicionaServico" visible="false" runat="server" title="Adicionar serviços"><span class="glyphicon glyphicon-pencil"></span></a>
                        </p>
                        <p class="">Veja abaixo os serviços oferecidos pela nossa equipe.</p>
                        <asp:Panel ID="servicosContainer" runat="server"></asp:Panel>
                    </div>

                    <%--Galeria--%>
                    <hr />
                    <div class="service">
                        <p class="label-est-fantasia">
                            <span class="glyphicon glyphicon-picture icon-profile"></span> Galeria <a class="glyphicon-purple-bellaweb" href="#" id="linkAdicionaGaleria" visible="false" runat="server" data-toggle="modal" data-target=".adicionaGallery" title="Adicionar foto a galeria"><span class="glyphicon glyphicon-plus-sign"></span></a>
                        </p>
                        <p class="">Confira imagens de nossos serviços.</p>

                        <div class="container-fluid" id="links">
                                <div class="responsive">
                                    <div class="img">
                                        <a href="../assets/img/img1 (2).jpg" title="Banana" data-gallery="">
                                            <img src="../assets/img/img1 (2).jpg" alt="Banana"/>
                                        </a>
                                        <div class="desc">Beautiful Mountains</div>
                                    </div>
                                </div>
                                <div class="responsive">
                                    <div class="img">
                                        <a href="../assets/img/img1 (2).jpg" title="Banana" data-gallery="">
                                            <img src="../assets/img/img1 (2).jpg" alt="Banana"/>
                                        </a>
                                        <div class="desc">Beautiful Mountains</div>
                                    </div>
                                </div>
                                <div class="responsive">
                                    <div class="img">
                                        <a href="../assets/img/img1 (2).jpg" title="Banana" data-gallery="">
                                            <img src="../assets/img/img1 (2).jpg" alt="Banana"/>
                                        </a>
                                    <div class="desc">Beautiful Mountains</div>
                                    </div>
                                </div>
                            </div>

                    </div>

                    <%--Mensagem-- Cliente Estabelecimento--%>
                    <hr />
                    <div id="divMensagem" runat="server" visible="true">
                        <div class="service">
                            <p class="label-est-fantasia">
                                <span class="glyphicon glyphicon-envelope icon-profile"></span> Entrar em Contato
                            </p>
                            <p>Para entrar em contato, esclarecer dúvidas, enviar sugestões e críticas <strong>preencha os campos abaixo.</strong></p>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <label class="control-label required-warn">Nome</label>
                                            <asp:TextBox ID="txbNome" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <label class="control-label required-warn">E-mail</label>
                                            <asp:TextBox ID="txbEmail" ClientIDMode="Static" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-8">
                                            <label class="control-label">Telefone</label>
                                            <asp:TextBox ID="txbTelefone" ClientIDMode="Static" runat="server" CssClass="form-control tel" Placeholder="Opcional"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">

                                <div id="dpmenu">
                                    <label class="control-label required-warn">Assunto</label>
                                    <asp:DropDownList ID="dpdAssunto" ClientIDMode="Static" CssClass="form-control select" runat="server" AutoPostBack="false">
                                        <asp:ListItem Value="0">Selecionar Opção</asp:ListItem>
                                        <asp:ListItem Value="1" Text="Dúvidas"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Críticas"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Sugestões"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Outros"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <br />
                                <div class="form-group">

                                    <label for="mensagem" class="control-label required-warn">Mensagem</label>
                                    <textarea id="txbMensagem" clientidmode="Static" class="form-control textarea no-resize" name="mensagem" runat="server"></textarea>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6"></div>
                            <div class="col-sm-6">
                                <div class="form-group ">
                                    <asp:Button ID="btnEnviar" ClientIDMode="Static" CssClass="next acao btn btn-default pull-right" Text="Enviar" OnClick="btnEnviar_Click" runat="server" />
                                    <span class="glyphicon glyphicon-question-sign pull-right questions" data-toggle="tooltip" title="Campos com (*) são obrigatórios para prosseguir com o cadastro" data-placement="auto"></span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%--Link voltar ao topo--%>
                    <div class="row">
                        <div class="col-sm-2">
                        </div>
                        <div class="col-sm-7">
                        </div>
                        <div class="col-sm-3">
                            <a href="#topo" class="backTop" title="Entrar em Contado"><span class="glyphicon glyphicon-arrow-up backTop"></span>&nbsp Voltar ao topo</a>
                        </div>
                    </div>

                </fieldset>
            </div>
        </div>
    </div>



    <%--MODAIS--%>

    <%--Modal editar foto de perfil--%>

    <div id="myModal" class="modal fade editarFoto modal-text" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel">Editar Foto de Perfil</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group btn btn-default">
                        <asp:FileUpload ID="fupImagem" runat="server" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <asp:Button CssClass="btn btn-purple" ID="btnEnviarImagem" Text="Enviar" OnClick="btnEnviarImagem_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <!-- Modal exibi foto da galeria -->
    <div id="blueimp-gallery" class="blueimp-gallery" >
        <!-- The container for the modal slides -->
        <div class="slides"></div>
        <!-- Controls for the borderless lightbox -->
        <h3 class="title"></h3>
        <a class="prev">‹</a>
        <a class="next">›</a>
        <a class="close">×</a>
        <a class="play-pause"></a>
        <ol class="indicator"></ol>
        <!-- The modal dialog, which will be used to wrap the lightbox content -->
        <div class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body next"></div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default pull-left prev">
                            <i class="glyphicon glyphicon-chevron-left"></i>
                            Previous
                        </button>
                        <button type="button" class="btn btn-primary next">
                            Next
                        <i class="glyphicon glyphicon-chevron-right"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>        
    </div>


    <!-- Modal envia imagens para a galeria-->

    <div id="modalAdicionaGallery" class="modal fade adicionaGallery modal-text" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Adicionar fotos na galeria</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="btn btn-default" AllowMultiple="true" />
                            </div>
                            <div class="col-sm-6">
                                <span class="glyphicon glyphicon-question-sign"></span>
                                <p class="label label-default">Dica: Para selecionar varias fotos ao mesmo tempo,</p>
                                <p class="label label-default">pressione a tecla Ctrl e clique nas fotos desejadas.</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <asp:Button CssClass="btn btn-purple" ID="btnAdicionaGallery" Text="Enviar" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
    <script src="../assets/js/Mascaras.js"></script>
    <script src="../assets/js/Galeria.js"></script>
    <script src="../assets/js/ValidacaoMensagem.js"></script>
    <script src="<%= ResolveUrl("~/assets/js/ServicoNotify.js") %>"></script>
    <script>
        run('<%= notify %>');
    </script>
    <script src="../assets/js/Gallery/jquery.blueimp-gallery.min.js"></script>
    <script src="../assets/js/Gallery/bootstrap-image-gallery.min.js"></script>
</asp:Content>

