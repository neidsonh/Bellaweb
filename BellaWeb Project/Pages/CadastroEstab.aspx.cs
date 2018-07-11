using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Functions;
using Bellaweb.App_Code.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_CadastroEstab : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((HtmlHead)Master.FindControl("headMaster")).Title += " Cadastro de Estabelecimento";
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {

        Estabelecimento estab = new Estabelecimento();
        estab.Fantasia = txbFantasia.Text;
        estab.RazaoSocial = txbRazaoSocial.Text;
        estab.Cnpj = txbCnpj.Text.Replace("-", "").Replace(".", "").Replace("/", "");

        Endereco endereco = new Endereco();
        endereco.Logradouro = txbLogradouro.Text;
        endereco.Numero = txbNumero.Text;
        endereco.Cep = txbCep.Text.Replace("-", "");
        endereco.Bairro = txbBairro.Text;
        estab.Endereco = endereco;

        Cidade cidade = new Cidade();
        cidade.Nome = txbCidade.Text;
        estab.Endereco.Cidade = CidadeDB.Select(cidade);

        estab.Responsavel = txbResponsavel.Text;
        estab.Telefone = txbTelefone.Text;
        estab.Celular = txbCelular.Text;

        long codigo;
        if ((codigo = EstabelecimentoDB.Insert(estab)) != -2)
        {
            estab.Codigo = codigo;
        }
        else
        {
            Response.Redirect("/?n=Q");
            return;
        }

        Usuario usuario = new UsuarioCrypto();
        usuario.Email = txbEmail.Text;
        usuario.Senha = txbSenha.Text;
        usuario.Estabelecimento = estab;
        //USUARIO está sendo inserido como ativo, mediante a testes.
        //usuario.Ativo = false;


        if (UsuarioDB.Insert(usuario) != -2)
        {
            txbBairro.Text = "";
            txbCep.Text = "";
            txbCnpj.Text = "";
            txbConfirmaEmail.Text = "";
            txbEmail.Text = "";
            txbFantasia.Text = "";
            txbLogradouro.Text = "";
            txbNumero.Text = "";
            txbRazaoSocial.Text = "";

            Response.Redirect("/?n=q");            
        }
        else
        {
            Response.Redirect("/?n=Q");
        }

        

    }

    [System.Web.Services.WebMethod]
    public static bool CheckEmail(string email)
    {
        return UsuarioDB.EmailExists(email);
    }

    [System.Web.Services.WebMethod]
    public static bool CheckEndereco(string cidade, string estado)
    {
        return EnderecoDB.EstadoCidadeIsValid(cidade, estado);
    }

    protected void btnContatar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/fale-conosco");
    }
}