<%@ Page Title="" Language="C#" MasterPageFile="~/MastersPages/Index.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="styles" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBody" runat="Server">
    <div class="container padding-top-bot">
        <div class="row">
            <asp:Panel runat="server" DefaultButton="btnEntrar">
                <fieldset>
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <img src="../assets/img/IconeLogo.png" class="img-responsive center-block" width="80" />
                            <p class="text-login text-center">Login</p>

                        </div>
                        <div class="inputs-login">
                            <div class="form-group div-login-email">
                                <asp:TextBox ID="txbUserEmail" ClientIDMode="Static" TabIndex="1" runat="server" type="email" class="form-control input-lg text-center" placeholder="E-mail"></asp:TextBox>
                            </div>
                            <div class="form-group div-login-senha">
                                <asp:TextBox ID="txbUserSenha" ClientIDMode="Static" TabIndex="2" runat="server" type="password" class="form-control input-lg text-center" placeholder="Senha"></asp:TextBox>
                            </div>
                        </div>
                        <%--<div class="form-group">
                            <asp:CheckBox ID="cbLembrar" TabIndex="4" runat="server" />
                            Lembrar-me.
                            <br />
                        </div>--%>
                        <div class="form-group">
                            <div class="btn-group-justified">
                                <asp:LinkButton CssClass="button" ID="btnEntrar" TabIndex="3" ClientIDMode="Static" OnClick="btnEntrar_Click" runat="server"><span>Entrar </span></asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">

                            <a href="#" class="center-block" style="text-align: center;">Esqueci minha senha</a>
                            <asp:Label ID="lblMsgErro" runat="server" Text="" CssClass="text-danger"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-4"></div>
                </fieldset>
            </asp:Panel>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="beforeEndBody" runat="Server">
    <script> 
        //Erro Login
        //erro
        function erroNotifyLogin() {
            new PNotify({
                title: 'Erro ao logar!',
                text: 'Verifique seu Usuário e Senha',
                type: 'error'
            });
        }
        var erroLogin = <%= ErroLogin %>;
         if(erroLogin) {
             erroNotifyLogin();
         };
        //erro preencha campos vazios
        function erroNotifyLogin2() {
            new PNotify({
                title: 'Erro ao logar!',
                text: 'Preencha os campos Usuário e Senha',
                type: 'error'
            });
        }
        var erroLogin2 = <%= ErroLogin2 %>;
         if(erroLogin2) {
             erroNotifyLogin2();
         };

    </script>
</asp:Content>

