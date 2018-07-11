<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/About.master" AutoEventWireup="true" CodeFile="FaleConosco.aspx.cs" Inherits="Pages_FaleConosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">

    <div class="container">
        <div class="well well-lg margin">
            <h3><strong>Bem vindo a área Fale Conosco</strong></h3>
            <p>Para esclarecer dúvidas, enviar sugestões, críticas ou solicitar cancelamentos,</p>
            <p>preencha os campos abaixo.</p>
        </div>
        <fieldset>
            <h2 class="text-left">Preencha o formulário</h2>
            <hr />
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
                    <div class="row">
                        <div id="dpmenu">
                            <label class="control-label required-warn">Assunto</label>
                            <asp:DropDownList ID="dpdAssunto" ClientIDMode="Static" CssClass="form-control select" runat="server" AutoPostBack="false" OnSelectedIndexChanged="dpdAssunto_SelectedIndexChanged">
                                <asp:ListItem Value="0" >Selecionar Opção</asp:ListItem>
                                <asp:ListItem Value="1" Text="Solicitação"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Dúvidas"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Sugestões"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Críticas"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Cancelamento"></asp:ListItem>
                                <asp:ListItem Value="6" Text="Outros"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="row">
                            <label for="mensagem" class="control-label required-warn">Mensagem</label>
                            <textarea id="txbMensagem" ClientIDMode="Static" class="form-control textarea no-resize" name="mensagem" runat="server"></textarea>
                        </div>
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
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
    <script src="../assets/js/Mascaras.js"></script>
    <script src="../assets/js/ValidacaoMensagem.js"></script>
</asp:Content>

