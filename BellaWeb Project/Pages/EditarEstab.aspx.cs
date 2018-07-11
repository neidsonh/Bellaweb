using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Persistence;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_EditarEstab : System.Web.UI.Page
{
    public string notify;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((HtmlHead)Master.FindControl("headMaster")).Title += " Editar Perfil";
        if (!Page.IsPostBack)
        {
            if (Session["ObjEst"] != null)
            {
                var EstabLogado = (Estabelecimento)Session["ObjEst"];

                txbEditCodEst.Text = EstabLogado.Codigo.ToString();
                txbEditFantasia.Text = EstabLogado.Fantasia;
                txbEditRazaoSocial.Text = EstabLogado.RazaoSocial;
                txbEditEnd.Text = EstabLogado.Endereco.Logradouro;
                txbEditNum.Text = EstabLogado.Endereco.Numero;
                txbEditBairro.Text = EstabLogado.Endereco.Bairro;
                txbEditCep.Text = EstabLogado.Endereco.Cep;
                txbEditCidade.Text = EstabLogado.Endereco.Cidade.Nome;
                txbEditUf.Text = EstabLogado.Endereco.Cidade.Estado.Nome;
                txbEditCnpj.Text = EstabLogado.Cnpj;
                txbEditNomeResponsavel.Text = EstabLogado.Responsavel;
                txbEditTel.Text = EstabLogado.Telefone;
                txbEditCel.Text = EstabLogado.Celular;
                txbImgUrl.Text = EstabLogado.ImagemUrl;

                liEditarPerfil.Attributes["class"] = "active";

                if (Page.RouteData.Values["opcao"] == null)
                {
                    mtvEditarEstab.SetActiveView(vEditarPerfil);
                }
                else
                {
                    View view = null;
                    string opcao = Page.RouteData.Values["opcao"] as string;
                    switch (opcao)
                    {
                        case "perfil":
                            view = vEditarPerfil;
                            liEditarPerfil.Attributes["class"] = "active";
                            liConta.Attributes["class"] = "";
                            liAddServicos.Attributes["class"] = "";
                            liMeusServicos.Attributes["class"] = "";
                            liPlus.Attributes["class"] = "";

                            break;
                        case "conta":
                            view = vConta;
                            liEditarPerfil.Attributes["class"] = "";
                            liConta.Attributes["class"] = "active";
                            liAddServicos.Attributes["class"] = "";
                            liMeusServicos.Attributes["class"] = "";
                            liPlus.Attributes["class"] = "";

                            break;
                        case "meusservicos":
                            view = vMeusServicos;
                            liEditarPerfil.Attributes["class"] = "";
                            liConta.Attributes["class"] = "";
                            liMeusServicos.Attributes["class"] = "active";
                            liAddServicos.Attributes["class"] = "";
                            liPlus.Attributes["class"] = "";

                            CarregarGridServicos();

                            break;
                        case "addservicos":
                            view = vAddServicos;
                            liEditarPerfil.Attributes["class"] = "";
                            liConta.Attributes["class"] = "";
                            liMeusServicos.Attributes["class"] = "";
                            liAddServicos.Attributes["class"] = "active";
                            liPlus.Attributes["class"] = "";

                            //dropdownlist do tiposerviço
                            DataSet ds = TipoServicoDB.SelectAll();
                            ddlTipoServico.DataSource = ds;
                            ddlTipoServico.DataTextField = "TPS_NOME"; // Nome da coluna do Banco de dados 
                            ddlTipoServico.DataValueField = "TPS_CODIGO"; // ID da coluna do Banco 
                            ddlTipoServico.DataBind();
                            ddlTipoServico.Items.Insert(0, "Selecione");
                            ddlSubTipoServico.Visible = false;
                            break;

                        case "plus":
                            view = vPlus;
                            liEditarPerfil.Attributes["class"] = "";
                            liConta.Attributes["class"] = "";
                            liMeusServicos.Attributes["class"] = "";
                            liAddServicos.Attributes["class"] = "";
                            liPlus.Attributes["class"] = "active";

                            break;

                        default:
                            Response.Redirect("/");
                            break;
                    }
                    verifyQueryString(Request.QueryString);
                    mtvEditarEstab.SetActiveView(view);
                }
            }
            else
            {
                Response.Redirect(ResolveUrl("/login"));
            }
        }

        if (Session["ObjEst"] == null)
            Response.Redirect(ResolveUrl("/login"));
    }

    protected void btnEditConfirmar_Click(object sender, EventArgs e)
    {
        Estabelecimento est = new Estabelecimento();
        est.Codigo = Convert.ToInt64(txbEditCodEst.Text);
        est.Cnpj = txbEditCnpj.Text;
        est.Fantasia = txbEditFantasia.Text;
        est.RazaoSocial = txbEditRazaoSocial.Text;
        est.Responsavel = txbEditNomeResponsavel.Text;
        est.Telefone = txbEditTel.Text;
        est.Celular = txbEditCel.Text;
        est.ImagemUrl = txbImgUrl.Text;

        Endereco end = new Endereco();
        end.Logradouro = txbEditEnd.Text;
        end.Numero = txbEditNum.Text;
        end.Bairro = txbEditBairro.Text;
        end.Cep = txbEditCep.Text;

        est.Endereco = end;

        if (EstabelecimentoDB.Update(est) == 0)
        {
            Response.Redirect("/estabelecimento/" + est.Codigo + "?n=a");
            Session["ObjEst"] = EstabelecimentoDB.Select(est.Codigo);

        }
        else
        {
            Response.Redirect("/editar/perfil?n=A");
        }



    }

    protected void btnEditCancelar_Click(object sender, EventArgs e)
    {
        Redirect();
    }

    private void Redirect()
    {
        if (Session["ObjEst"] == null)
        {
            Response.Redirect(ResolveUrl("/login"));
        }
        else { Response.Redirect("/estabelecimento/" + (Session["ObjEst"] as Estabelecimento).Codigo); }

    }

    protected void MudarView(object sender, EventArgs e)
    {
        LinkButton lkb = sender as LinkButton;

        if (lkb.ID == lkbEditarPerfil.ID)
        {
            Response.Redirect("/editar/perfil");
        }
        else if (lkb.ID == lkbConta.ID)
        {
            Response.Redirect("/editar/conta");
        }
        else if (lkb.ID == lkbAddServicos.ID)
        {
            Response.Redirect("/editar/addservicos");
        }
        else if (lkb.ID == lkbMeusServicos.ID)
        {
            Response.Redirect("/editar/meusservicos");
        }
        else if (lkb.ID == lkbPlus.ID)
        {
            Response.Redirect("/editar/plus");
        }
        else
        {
            return;
        }
    }

    protected void ddlTipoServico_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlTipoServico.SelectedValue) != "Selecione")
        {
            setDdlSubtipoContent(Convert.ToInt64(ddlTipoServico.SelectedValue));
            ddlSubTipoServico.Visible = true;
        }
        else
        {
            ddlSubTipoServico.Visible = false;
        }
    }

    private void setDdlSubtipoContent(long tpsTipopai)
    {
        ddlSubTipoServico.DataTextField = "tps_nome";
        ddlSubTipoServico.DataValueField = "tps_codigo";
        ddlSubTipoServico.DataSource = TipoServicoDB.SelectByTipoServicos(tpsTipopai);
        ddlSubTipoServico.DataBind();
    }

    protected void btnAdicionarServico_Click(object sender, EventArgs e)
    {
        try
        {
            Servico servico = new Servico();

            servico.TipoServico = TipoServicoDB.Select(Convert.ToInt64(ddlSubTipoServico.SelectedValue));
            if (Session["ObjEst"] != null)
                servico.Estabelecimento = (Estabelecimento)Session["ObjEst"];

            servico.Nome = txbNomeServico.Text;
            servico.Preco = Convert.ToDouble(txbValorServico.Text);

            if (ServicoDB.Insert(servico) == 0)
            {
                Session["ObjEst"] = EstabelecimentoDB.Select(servico.Estabelecimento.Codigo);

                txbValorServico.Text = "";
                txbNomeServico.Text = "";

                Response.Redirect("/editar/meusservicos?n=d");
            }
            else
            {
                Response.Redirect("/editar/meusservicos?n=D");
            }
        }
        catch (Exception exc) { }
    }

    public void CarregarGridServicos()
    {
        // CARREGAR GRID MEUS SERVIÇOS
        var EstabLogado = (Estabelecimento)Session["ObjEst"];
        DataSet ds = (ServicoDB.SelectByEstabelecimentoDS(EstabLogado));
        int qtd = ds.Tables[0].Rows.Count;
        if (qtd > 0)
        {
            gdvMeusServicos.DataSource = ds.Tables[0].DefaultView;
            gdvMeusServicos.DataBind();
            gdvMeusServicos.Visible = true;
            lblResultMeusServicos.Text = "Foram encontrados " + qtd + " de registros";
        }
        else
        {
            gdvMeusServicos.Visible = false;
            lblResultMeusServicos.Text = "Não foram encontrados serviços...</br>Adicione novos serviços no menu lateral.";

        }
    }

    protected void gdvMeusServicos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Excluir")
        {
            Servico servico = new Servico();
            servico.Codigo = Convert.ToInt64(e.CommandArgument.ToString());
            if (ServicoDB.Delete(servico) != -2)
            {
                Response.Redirect("/editar/meusservicos?n=z");
            }
            else
            {
                Response.Redirect("/editar/meusservicos?n=Z");
            }
            CarregarGridServicos();
        }
    }

    private void verifyQueryString(NameValueCollection QueryString)
    {
        if (QueryString.HasKeys() && QueryString.AllKeys.Any(k => k == "n"))
            notify = QueryString["n"];
        else
            notify = "";
    }

    protected void btnEditSenhaCancelar_Click(object sender, EventArgs e)
    {
        Redirect();
    }

    protected void btnEditSenhaConfirmar_Click(object sender, EventArgs e)
    {
        if (txbNovaSenha.Text != txbConfirmarSenha.Text)
        {
            lblErro.Text = "* Os campos Nova Senha e Digite Novamente devem ser iguais";
            return;
        }

        Usuario userValid = new Usuario();
        var EstabLogado = (Estabelecimento)Session["ObjEst"];
        userValid = UsuarioDB.SelectByEstabelecimento(EstabLogado);

        UsuarioCrypto user = new UsuarioCrypto();
        UsuarioCrypto userNewPassword = new UsuarioCrypto();
        user.Senha = txbSenha.Text;
        user.Codigo = userValid.Codigo;
        userNewPassword.Senha = txbNovaSenha.Text;

        if (!UsuarioDB.SenhaIsValid(user))
        {
            lblErro.Text = "* Campo Senha está incorreto";
            return;
        }        
        
        userValid.Senha = userNewPassword.Senha;

        if (UsuarioDB.UpdateSenha(userValid) != -2)
        {
            Response.Redirect("/estabelecimento/" + EstabLogado.Codigo + "?n=b");
        }
        else
        {
            Response.Redirect("/editar/conta?n=B");
        }


    }
}