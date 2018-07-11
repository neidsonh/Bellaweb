using Bellaweb.App_Code.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_FaleConosco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((HtmlHead)Master.FindControl("headMaster")).Title += " Fale Conosco";
    }

    protected void dpdAssunto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        string assunto = dpdAssunto.SelectedItem.Text;
        string email = txbEmail.Text;
        string nome = txbNome.Text;
        string telefone = txbTelefone.Text;
        string texto = txbMensagem.Value;

        int retorno = Email.EnviarEmail(assunto, texto, nome, email, telefone);
        if(retorno == 1)
        {
            //Utils.CleanControls(Page);
            Response.Redirect("/?n=y");
        }else
        {
            Response.Redirect("/?n=Y");
        }
    }
}