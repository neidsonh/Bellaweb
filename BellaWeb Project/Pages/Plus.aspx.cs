using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_Plus : System.Web.UI.Page
{

    private Usuario usuario;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((HtmlHead)Master.FindControl("headMaster")).Title += " Plus";

        if (Session["ObjAdm"] == null)
            Response.Redirect("/");

        if (Page.RouteData.Values["id"] == null)
            Response.Redirect("/404");

        long id = 0;
        try
        {
            id = Convert.ToInt64(Page.RouteData.Values["id"]);
        }
        catch
        {
            Response.Redirect("/404");
        }

        Estabelecimento estabelecimento = EstabelecimentoDB.Select(id);

        if (estabelecimento == null)
            Response.Redirect("/404");

        usuario = UsuarioDB.SelectByEstabelecimento(estabelecimento);

        if (usuario != null)
        {
            lblNomeResponsavel.Text = usuario.Estabelecimento.Responsavel;
            lblTelefone.Text = usuario.Estabelecimento.Telefone;
            lblCelular.Text = usuario.Estabelecimento.Celular;
            lblNomeFantasia.Text = usuario.Estabelecimento.Fantasia;
        }
        else
        {
            Response.Redirect("/404");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/cadastros");
    }

    protected void btnPlusAtivar_Click(object sender, EventArgs e)
    {
        EstabelecimentoDB.UpdateAtivarPlus(usuario.Estabelecimento);
        Response.Redirect("/admin/cadastros?n=c");
    }

    protected void btnPlusDesativar_Click(object sender, EventArgs e)
    {
        EstabelecimentoDB.UpdateDesativarPlus(usuario.Estabelecimento);
        Response.Redirect("/admin/cadastros?n=C");
    }
}