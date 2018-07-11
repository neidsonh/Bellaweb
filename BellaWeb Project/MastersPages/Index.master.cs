using Bellaweb.App_Code.Classes;
using System;
using Bellaweb.App_Code.Persistence;

public partial class MastersPages_Index : System.Web.UI.MasterPage
{
    public long Codigo { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        Codigo = 0;
        if (Session["ObjEst"] != null)
        {
            var obj = (Estabelecimento)Session["ObjEst"];
            lblUsuarioLogado.Text = obj.Fantasia;            
            Codigo = obj.Codigo;
            ulSettingsEst.Visible = true;
            ulSettingsAdm.Visible = false;

        }
        else if (Session["ObjAdm"] != null)
        {
            var obj = (Administrador)Session["ObjAdm"];
            lblUsuarioLogadoAdm.Text = obj.Nome;
            ulSettingsEst.Visible = false;
            ulSettingsAdm.Visible = true;
        }
        else
        {
            ulSettingsEst.Visible = false;
            ulSettingsAdm.Visible = false;
            divAcesso.Visible = true;
        }

        menu.DataSource = TipoServicoDB.SelectTipoSubTipo();
        menu.DataBind();
    }

   

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/");
    }

    protected void btnProsseguir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/");
    }

   
}
