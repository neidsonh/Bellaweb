using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Functions;
using Bellaweb.App_Code.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_Login : System.Web.UI.Page
{
    public string ErroLogin { get; set; }
    public string ErroLogin2 { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        txbUserEmail.Focus();
        if (!Page.IsPostBack)
        {
            ErroLogin = (Request.QueryString.AllKeys.Any(k => k == "L")) ? "true" : "false";
            ErroLogin2 = (Request.QueryString.AllKeys.Any(k => k == "l")) ? "true" : "false";

            ((HtmlHead)Master.FindControl("headMaster")).Title += " Login";

            if (Session["ObjEst"] != null)
            {
                Response.Redirect("/estabelecimento/" + (Session["ObjEst"] as Estabelecimento).Codigo);
            }
            else if (Session["ObjAdm"] != null)
            {
                Response.Redirect("/admin");
            }

        }
    }

    //metodo copiado da modal login
    protected void btnEntrar_Click(object sender, EventArgs e)
    {

        string email = txbUserEmail.Text.ToString();
        string senha = txbUserSenha.Text.ToString();

        if (!IsValidUserFields(email, senha))
        {
            Response.Redirect("/login/?l=");
            return;
        }

        Usuario usuario = new UsuarioCrypto()
        {
            Email = email,
            Senha = senha
        };

        if (!UsuarioDB.IsValid(usuario))
        {
            Response.Redirect("/login/?L=");

            txbUserEmail.Text = "";
            txbUserSenha.Text = "";
            return;
        }

        usuario = UsuarioDB.Select(usuario);

        if (usuario == null)
        {
            AlertError("E-mail e/ou Senha Inválidos");
        }
        else
        {
            ResolveRedirect(usuario);
        }

    }

    protected void AlertError(string message)
    {
        Response.Write(Utils.AlertScript(message));
    }

    protected bool IsValidUserFields(string email, string password)
    {
        return !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password);
    }

    protected void ResolveRedirect(Usuario usuario)
    {
        string url;

        if (usuario.Estabelecimento != null)
        {
            Estabelecimento est = new Estabelecimento();
            est = usuario.Estabelecimento;
            Session["ObjEst"] = est;
            url = "/estabelecimento/" + est.Codigo;

        }
        else if (usuario.Administrador != null)
        {
            Administrador adm = new Administrador();
            adm = usuario.Administrador;
            Session["ObjAdm"] = adm;
            url = "/admin";
        }
        else
        {
            url = "/";
        }

        Response.Redirect(url);
    }
}