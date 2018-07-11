using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Functions;
using Bellaweb.App_Code.Persistence;
using Bellaweb.UI.WebControls;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_PerfilEstab : System.Web.UI.Page
{
    public string notify;
    public string ImagemUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((HtmlHead)Master.FindControl("headMaster")).Title += " Perfil";
        if (!Page.IsPostBack)
        {
            if (Page.RouteData.Values["codigo"] == null)
                Response.Redirect("/");

            long id = Convert.ToInt64(Page.RouteData.Values["codigo"]);
            Estabelecimento estab = EstabelecimentoDB.Select(id);
            if (estab == null)
                Response.Redirect("/404");

            SetPageInfo(estab);
            verifyQueryString(Request.QueryString);
            if (Session["ObjEst"] != null)
            {
                Estabelecimento estabLogado = Session["ObjEst"] as Estabelecimento;
                linkAdicionaServico.Visible = estabLogado.Equals(estab);
                linkAdicionaGaleria.Visible = estabLogado.Equals(estab);
                enviarFoto.Visible = estabLogado.Equals(estab);
                lblStatus.Visible = estabLogado.Equals(estab);
                lblStatusFixo.Visible = estabLogado.Equals(estab);
                lblPlus.Visible = estabLogado.Equals(estab);
                lblPlusFixo.Visible = estabLogado.Equals(estab);

                divMensagem.Visible = !estabLogado.Equals(estab);
            }

        }

        if (ViewState["ImagemUrl"] != null)
            ImagemUrl = ViewState["ImagemUrl"] as string;

        
    }

    private void verifyQueryString(NameValueCollection QueryString)
    {
        if (QueryString.HasKeys() && QueryString.AllKeys.Any(k => k == "n"))
            notify = QueryString["n"];
        else
            notify = "";
    }

    private void SetPageInfo(Estabelecimento estabelecimento)
    {
        

        lblEstFantasia.Text = estabelecimento.Fantasia;
        lblRazaoSocial.Text = estabelecimento.RazaoSocial;
        lblEndereco.Text = estabelecimento.Endereco.Logradouro;
        lblEndNum.Text = estabelecimento.Endereco.Numero;
        lblBairro.Text = estabelecimento.Endereco.Bairro;
        lblCep.Text = estabelecimento.Endereco.Cep;
        lblCidade.Text = estabelecimento.Endereco.Cidade.Nome;
        lblUf.Text = estabelecimento.Endereco.Cidade.Estado.Nome;
        lblTelefone.Text = estabelecimento.Telefone;
        lblCelular.Text = estabelecimento.Celular;
        lblStatus.Text = estabelecimento.StatusAtivacao;
        

        if (estabelecimento.StatusAtivacao == "APROVADO")
        {
            lblStatus.CssClass = "label label-success";
        }
        else if (estabelecimento.StatusAtivacao == "NEGADO")
        {
            lblStatus.CssClass = "label label-danger";
        }
        else if (estabelecimento.StatusAtivacao == "AGUARDANDO")
        {
            lblStatus.CssClass = "label label-info";
        }

        if(estabelecimento.Plus == true)
        {
            lblPlus.CssClass = "label label-success";
            lblPlus.Text = "ATIVO";
        }
        else
        {
            lblPlus.CssClass = "label label-danger";
            lblPlus.Text = "DESATIVADO <a href='/editar/plus' class='text-center txt-sabermaisplus'>Saber mais!</a>";
        }

        ViewState["ImagemUrl"] = (estabelecimento.HasImagem()) ? estabelecimento.ImagemUrl : "../assets/img/profile.jpg";

        Dictionary<TipoServico, List<Servico>> map = ServicoDB.MapTipoServicoByEstabelecimento(estabelecimento);
        servicosContainer.Controls.Add(new TipoServicosPanel(map));
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        string assunto = dpdAssunto.SelectedItem.Text;
        string email = txbEmail.Text;
        string nome = txbNome.Text;
        string telefone = txbTelefone.Text;
        string texto = txbMensagem.Value;

        long id = Convert.ToInt64(Page.RouteData.Values["codigo"]);
        Usuario usuario = UsuarioDB.SelectByEstabelecimento(id);

        int retorno = Email.EnviarEmail(usuario.Email, assunto, texto, nome, email, telefone);
        if (retorno == 1)
        {
            //Utils.CleanControls(Page);
            Response.Redirect("/?y=");

        }
    }

    protected void btnEnviarImagem_Click(object sender, EventArgs e)
    {
        if (fupImagem.HasFile)
        {
            if (Utils.IsValidType(fupImagem.PostedFile.ContentType))
            {
                DirectoryInfo di = new DirectoryInfo(Request.PhysicalApplicationPath + "/Imagens/");
                di.FullName.Replace(" ", "_");
                if (!di.Exists)
                    di.Create();

                string fullName = di.FullName + "/" + fupImagem.FileName;
                fupImagem.SaveAs(fullName);
                UploadResult result = CloudinaryWrapper.UploadImage(fullName);
                File.Delete(fullName);
                string url = Convert.ToString(result.JsonObj["url"]);

                Estabelecimento estab = Session["ObjEst"] as Estabelecimento;
                estab.ImagemUrl = url;
                EstabelecimentoDB.Update(estab);
                Response.Redirect("/estabelecimento/" + estab.Codigo);
            }
        }
    }
}