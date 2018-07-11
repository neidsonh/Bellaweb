using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Persistence;
using System;

public partial class Pages_AnaliseEstab : System.Web.UI.Page
{
    private Usuario usuario;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            lblEmail.Text = usuario.Email;
            lblNomeResponsavel.Text = usuario.Estabelecimento.Responsavel;
            lblTelefone.Text = usuario.Estabelecimento.Telefone;
            lblCelular.Text = usuario.Estabelecimento.Celular;
            lblNomeFantasia.Text = usuario.Estabelecimento.Fantasia;
            lblRazaoSocial.Text = usuario.Estabelecimento.RazaoSocial;
            lblCnpj.Text = usuario.Estabelecimento.Cnpj;
            lblCep.Text = usuario.Estabelecimento.Endereco.Cep;
            lblLogradouro.Text = usuario.Estabelecimento.Endereco.Logradouro;
            lblNumero.Text = usuario.Estabelecimento.Endereco.Numero;
            lblBairro.Text = usuario.Estabelecimento.Endereco.Bairro;
            lblCidade.Text = usuario.Estabelecimento.Endereco.Cidade.Nome;
            lblEstado.Text = usuario.Estabelecimento.Endereco.Cidade.Estado.Nome;
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

    protected void btnNegar_Click(object sender, EventArgs e)
    {
        EstabelecimentoDB.UpdateStatusNegado(usuario.Estabelecimento);
        Response.Redirect("/admin/cadastros?n=h");
    }

    protected void btnAprovar_Click(object sender, EventArgs e)
    { 
        EstabelecimentoDB.UpdateStatusAprovado(usuario.Estabelecimento);
        Response.Redirect("/admin/cadastros?n=H");
    }

    protected void btnAguardar_Click(object sender, EventArgs e)
    {
        EstabelecimentoDB.UpdateStatusAguardando(usuario.Estabelecimento);
        Response.Redirect("/admin/cadastros?n=g");
    }
}