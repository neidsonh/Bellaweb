<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotFound404.aspx.cs" Inherits="Pages_NotFound404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BellaWeb | 404</title>
    <link href="../assets/libs/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background-404">
            <div class="container">
                <div class="div-404">
                    <a href="/">
                        <img src="../assets/img/IconeLogo.png" class="center-block img-responsive" width="120" /></a>
                    <br />
                    <p class="title-404 text-center">Desculpe, a página que voce solicitou não pode ser encontrada.</p>
                    <p class="a-404 text-center">404</p>
                    <p class="a-404-sub text-center">Page not found</p>
                    <div class="row">
                        <div class="col-sm-5"></div>
                        <div id="hyperlinkHome" class="col-sm-2">
                            <asp:HyperLink NavigateUrl="/" runat="server" Text="Voltar a página inicial" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
