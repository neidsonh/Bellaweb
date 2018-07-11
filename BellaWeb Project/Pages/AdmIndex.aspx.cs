using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Functions;
using Bellaweb.App_Code.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_AdmIndex : System.Web.UI.Page
{
    public string notify;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            ((HtmlHead)Master.FindControl("headMaster")).Title += " Adm";
            if (Session["ObjAdm"] == null)
                Response.Redirect("/login");

            if (Page.RouteData.Values["opcao"] == null)
                Response.Redirect("/admin/cadastros");

            bindAllDdls();
            CarregarGrids();
            CarregarGridDestaques();

            View view = null;
            string opcao = Page.RouteData.Values["opcao"] as string;
            switch (opcao)
            {
                case "cadastros":
                    view = vCadastros;
                    liCadastros.Attributes["class"] = "active";
                    liServicos.Attributes["class"] = "";
                    liCidades.Attributes["class"] = "";
                    liDestaques.Attributes["class"] = "";
                    break;
                case "servicos":
                    view = vServicos;
                    liCadastros.Attributes["class"] = "";
                    liServicos.Attributes["class"] = "active";
                    liCidades.Attributes["class"] = "";
                    liDestaques.Attributes["class"] = "";
                    break;
                case "cidades":
                    view = vCidades;
                    liCadastros.Attributes["class"] = "";
                    liServicos.Attributes["class"] = "";
                    liCidades.Attributes["class"] = "active";
                    liDestaques.Attributes["class"] = "";                    
                    break;

                case "destaques":
                    view = vDestaques;
                    liCadastros.Attributes["class"] = "";
                    liServicos.Attributes["class"] = "";
                    liCidades.Attributes["class"] = "";
                    liDestaques.Attributes["class"] = "active";
                    break;

                default:
                    Response.Redirect("/");
                    break;
            }
            verifyQueryString(Request.QueryString);
            mtvAdm.SetActiveView(view);
        }
    }

    private void verifyQueryString(NameValueCollection QueryString)
    {
        if (QueryString.HasKeys() && QueryString.AllKeys.Any(k => k == "n"))
            notify = QueryString["n"];
        else
            notify = "";
    }

    protected void MudarView(object sender, EventArgs e)
    {
        LinkButton lkb = sender as LinkButton;
        if (lkb.ID == lkbEstabelecimentos.ID)
        {
            Response.Redirect("/admin/cadastros");
        }
        else if (lkb.ID == lkbServicos.ID)
        {
            Response.Redirect("/admin/servicos");
        }
        else if (lkb.ID == lkbCidades.ID)
        {
            Response.Redirect("/admin/cidades");
        }
        else if (lkb.ID == lkbDestaques.ID)
        {
            Response.Redirect("/admin/destaques");
        }
        else
        {
            return;
        }
    }

    public void CarregarGrids()
    {
        DataSet ds = EstabelecimentoDB.SelectByEstadoAtivacao(ddlEstadoAtivacao.SelectedValue);
        int qtd = ds.Tables[0].Rows.Count;

        string mensagem;

        if (qtd > 0)
        {
            gdvEstabelecimentos.DataSource = ds.Tables[0].DefaultView;
            gdvEstabelecimentos.DataBind();
            mensagem = "Foram encontrados " + qtd + " registros";
        }
        else
        {
            mensagem = "Não há estabelecimentos que correspondam à filtragem";
        }
        gdvEstabelecimentos.Visible = (qtd > 0);
        lblResultEstAtivos.Text = mensagem;
    }

    public void CarregarGridDestaques()
    {
        DataSet ds = DestaqueDB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;

        string mensagem;

        if (qtd > 0)
        {
            gdvDestaques.DataSource = ds.Tables[0].DefaultView;
            gdvDestaques.DataBind();
            mensagem = "Foram encontrados " + qtd + " registros";
        }
        else
        {
            mensagem = "Não há destaques cadastrados.";
        }
        gdvEstabelecimentos.Visible = (qtd > 0);
        lblResultDestaques.Text = mensagem;
    }

    protected void bindAllDdls()
    {
        bindDdlServicoContent();
        bindDdlExcluirServico();
        bindDdlSelectExcluirServico();
        bindDdlExcluirSubTipoServico();
        bindDdlUf();
        bindDdlUf2();
        bindDdlCidades();
        bindDdlUf3();
    }

    protected void ddlEstadoAtivacao_SelectedIndexChanged(object sender, EventArgs e)
    {
        CarregarGrids();
    }

    protected void gdvEstabelecimentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editar")
            Response.Redirect("/analise-cadastro/" + e.CommandArgument.ToString());
        else if (e.CommandName == "Plus")
            Response.Redirect("/plus/" + e.CommandArgument.ToString());
    }

    protected void btnAddServico_Click(object sender, EventArgs e)
    {
        if (txbAddServico.Text == "")
        {
            Response.Redirect("/admin/servicos?n=X");
            return;
        }
        TipoServico servico = new TipoServico();

        servico.Descricao = txbAddServico.Text;

        long codigo;
        if (TipoServicoDB.NomeIsValid(servico.Descricao) == true)
        {
            if ((codigo = TipoServicoDB.Insert(servico)) != -2)
            {
                servico.Codigo = codigo;
                txbAddServico.Text = "";

                bindDdlServicoContent();
                Response.Redirect("/admin/servicos?n=s");
            }
            else
            {
                Response.Redirect("/admin/servicos?n=S");
                return;
            }
        }
        else
        {
            Response.Redirect("/admin/servicos?n=X");
            return;
        }
    }

    private void bindDdlServicoContent()
    {
        ddlServico.DataTextField = "tps_nome";
        ddlServico.DataValueField = "tps_codigo";
        ddlServico.DataSource = TipoServicoDB.SelectAll();
        ddlServico.DataBind();
    }

    private void bindDdlUf()
    {
        ddlUf.DataTextField = "etd_uf";
        ddlUf.DataValueField = "etd_codigo";
        ddlUf.DataSource = EstadoDB.SelectAll();
        ddlUf.DataBind();
    }

    private void bindDdlUf2()
    {
        ddlUf2.DataTextField = "etd_uf";
        ddlUf2.DataValueField = "etd_codigo";
        ddlUf2.DataSource = EstadoDB.SelectAll();
        ddlUf2.DataBind();
    }

    private void bindDdlUf3()
    {
        ddlUf3.DataTextField = "etd_uf";
        ddlUf3.DataValueField = "etd_codigo";
        ddlUf3.DataSource = EstadoDB.SelectAll();
        ddlUf3.DataBind();

        try
        {
            Estado est = new Estado();
            est = EstadoDB.Select(Convert.ToInt64(ddlUf3.SelectedValue));

            lblExcluirUf.Text = est.Nome;
        }
        catch (Exception e)
        {

        }

    }

    private void bindDdlCidades()
    {
        ddlCidade.DataTextField = "nome";
        ddlCidade.DataValueField = "codigo";
        ddlCidade.DataSource = CidadeDB.SelectByUF(Convert.ToInt64(ddlUf2.SelectedValue));
        ddlCidade.DataBind();
    }

    private void bindDdlExcluirServico()
    {
        ddlExcluirServico.DataTextField = "tps_nome";
        ddlExcluirServico.DataValueField = "tps_codigo";
        ddlExcluirServico.DataSource = TipoServicoDB.SelectAll();
        ddlExcluirServico.DataBind();
    }

    private void bindDdlSelectExcluirServico()
    {
        ddlSelectExcluirServico.DataTextField = "tps_nome";
        ddlSelectExcluirServico.DataValueField = "tps_codigo";
        ddlSelectExcluirServico.DataSource = TipoServicoDB.SelectAll();
        ddlSelectExcluirServico.DataBind();
    }

    private void bindDdlExcluirSubTipoServico()
    {

        ddlExcluirSubTipo.DataTextField = "tps_nome";
        ddlExcluirSubTipo.DataValueField = "tps_codigo";
        ddlExcluirSubTipo.DataSource = TipoServicoDB.SelectByTipoServicos(Convert.ToInt64(ddlSelectExcluirServico.SelectedValue));
        ddlExcluirSubTipo.DataBind();
    }

    protected void btnAddTipoServico_Click(object sender, EventArgs e)
    {
        if (txbAddTipoServico.Text == "")
        {
            Response.Redirect("/admin/servicos?n=X");
            return;
        }

        TipoServico tipoServico = new TipoServico();
        TipoServico tipoServicoPai = new TipoServico();

        tipoServicoPai = TipoServicoDB.Select(Convert.ToInt32(ddlServico.SelectedValue));

        tipoServico.Descricao = txbAddTipoServico.Text;
        tipoServico.TipoPai = tipoServicoPai;
        long codigo;
        if (TipoServicoDB.NomeIsValid(tipoServico.Descricao) == true)
        {
            if ((codigo = TipoServicoDB.Insert(tipoServico)) != -2)
            {
                tipoServico.Codigo = codigo;
                txbAddServico.Text = "";

                bindDdlServicoContent();
                Response.Redirect("/admin/servicos?n=j");
            }
            else
            {
                Response.Redirect("/admin/servicos?n=J");
                return;
            }
        }
        else
        {
            Response.Redirect("/admin/servicos?n=X");
            return;
        }

    }

    protected void btnExcluirTipoServico_Click(object sender, EventArgs e)
    {
        if (TipoServicoDB.Delete(Convert.ToInt64(ddlExcluirServico.SelectedValue)) != -2)
        {
            Response.Redirect("/admin/servicos?n=k"); // DEU BOM
        }
        else
        {
            Response.Redirect("/admin/servicos?n=K");
        }
    }

    protected void btnExcluirSubTipo_Click(object sender, EventArgs e)
    {
        if (TipoServicoDB.Delete(Convert.ToInt64(ddlExcluirSubTipo.SelectedValue)) != -2)
        {
            Response.Redirect("/admin/servicos?n=k"); // DEU BOM
        }
        else
        {
            Response.Redirect("/admin/servicos?n=K");
        }
    }

    protected void ddlSelectExcluirServico_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDdlExcluirSubTipoServico();
    }

    protected void ddlUf3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Estado est = new Estado();
        est = EstadoDB.Select(Convert.ToInt64(ddlUf3.SelectedValue));

        lblExcluirUf.Text = est.Nome;
    }

    protected void ddlUf2_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDdlCidades();
    }

    protected void btnAddCidade_Click(object sender, EventArgs e)
    {
        if (txbAddCidade.Text == "")
            return;

        Cidade cid = new Cidade();
        Estado uf = new Estado();
        uf = EstadoDB.Select(Convert.ToInt64(ddlUf.SelectedValue));
        cid.Estado = uf;
        cid.Nome = txbAddCidade.Text;

        if (!CidadeDB.NomeIsValid(cid.Nome, cid.Estado.Codigo))
        {
            Response.Redirect("/admin/cidades?n=P");
            return;
        }
        if (CidadeDB.Insert(cid) != -2)
        {
            txbAddCidade.Text = "";
            Response.Redirect("/admin/cidades?n=p");
            bindAllDdls();
        }
        else
        {
            Response.Redirect("/admin/cidades?n=P");
        }
    }

    protected void btnExcluirCidade_Click(object sender, EventArgs e)
    {
        Cidade cid = new Cidade();
        cid.Codigo = Convert.ToInt64(ddlCidade.SelectedValue);
        if (CidadeDB.Delete(cid) != -2)
        {
            bindAllDdls();
            Response.Redirect("/admin/cidades?n=l");
        }
        else
        {
            Response.Redirect("/admin/cidades?n=L");
        }
    }

    protected void btnAddUf_Click(object sender, EventArgs e)
    {
        if ((txbAddUfSigla.Text == "") | (txbAddUfNome.Text == ""))
            Response.Redirect("/admin/cidades?n=O");

        Estado uf = new Estado();
        uf.Nome = txbAddUfNome.Text;
        uf.Uf = txbAddUfSigla.Text;

        if (EstadoDB.Insert(uf) != -2)
        {
            txbAddUfSigla.Text = "";
            txbAddUfNome.Text = "";

            bindAllDdls();
            Response.Redirect("/admin/cidades?n=o");
        }
        else
        {
            Response.Redirect("/admin/cidades?n=O");
        }


    }

    protected void btnExcluirUf_Click(object sender, EventArgs e)
    {
        Estado uf = new Estado();
        uf.Codigo = Convert.ToInt64(ddlUf3.SelectedValue);
        if (EstadoDB.Delete(uf) != -2)
        {
            Response.Redirect("/admin/cidades?n=m");
            bindAllDdls();
        }
        else
        {
            Response.Redirect("/admin/cidades?n=M");
        }
    }

    protected void btnCadastrarDestaque_Click(object sender, EventArgs e)
    {
        if ((txbUrlDestaque.Text == "") | (txbUrlImagem.Text == "") | ( txbTitulo.Text == ""))
            Response.Redirect("/admin/destaques?n=U");

        Destaque destaque = new Destaque();

        destaque.Url = txbUrlDestaque.Text;
        destaque.ImgUrl = txbUrlImagem.Text;
        destaque.Titulo = txbTitulo.Text;
        destaque.Administrador = Session["ObjAdm"] as Administrador;

        if (DestaqueDB.Insert(destaque) != -2)
        {
            txbUrlDestaque.Text = "";
            txbUrlImagem.Text = "";
            txbTitulo.Text = "";
            Response.Redirect("/admin/destaques?n=u");
        }
        else
        {
            Response.Redirect("/admin/destaques?n=U");
        }
    }

    protected void gdvDestaques_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Excluir")
        {
            Destaque destaque = new Destaque();
            destaque.Codigo = Convert.ToInt64(e.CommandArgument.ToString());
            if (DestaqueDB.Delete(destaque) != -2)
            {
                Response.Redirect("/admin/destaques?n=y");
            }
            else
            {
                Response.Redirect("/admin/destaques?n=Y");
            }
            CarregarGridDestaques();
        }
    }
}