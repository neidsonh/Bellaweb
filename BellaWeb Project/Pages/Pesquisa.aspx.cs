using Bellaweb.App_Code.Persistence;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Pages_Pesquisa : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ((HtmlHead)Master.FindControl("headMaster")).Title += " Pesquisa";
            bindDdlCidadeContent();
            bindDdlTipoContent();
            bindDdlSubtipoContent(Convert.ToInt64(ddlTipo.SelectedValue));
            FillFormFields(Request.QueryString);
        }

        resolveSearch(Request.QueryString);
    }
    /// <summary>
    /// Drop cidade em pesquisa avançada
    /// </summary>
    private void bindDdlCidadeContent()
    {
        ddlCidade.DataTextField = "cid_nome";
        ddlCidade.DataValueField = "cid_codigo";
        ddlCidade.DataSource = CidadeDB.SelectAll();
        ddlCidade.DataBind();

        ListItem li = new ListItem("Pesquisar em todas as cidades", "-1");
        ddlCidade.Items.Add(li);

        ddlCidade.SelectedIndex = ddlCidade.Items.Count - 1;
    }

    /// <summary>
    /// Drop tipo serviço em pesquisa avançada
    /// </summary>
    private void bindDdlTipoContent()
    {
        ddlTipo.DataTextField = "tps_nome";
        ddlTipo.DataValueField = "tps_codigo";
        ddlTipo.DataSource = TipoServicoDB.SelectAll();
        ddlTipo.DataBind();

        ListItem li = new ListItem("Nenhum", "-1");
        ddlTipo.Items.Add(li);

        ddlTipo.SelectedIndex = ddlTipo.Items.Count - 1;

    }

    /// <summary>
    /// Drop subtipo serviço em pesquisa avançada
    /// </summary>
    private void bindDdlSubtipoContent(long tpsTipopai)
    {
        if (tpsTipopai == -1)
        {
            divSubtipo.Visible = false;
            return;
        }

        divSubtipo.Visible = true;

        ddlSubtipo.DataTextField = "tps_nome";
        ddlSubtipo.DataValueField = "tps_codigo";
        ddlSubtipo.DataSource = TipoServicoDB.SelectByTipoServicos(tpsTipopai);
        ddlSubtipo.DataBind();
    }

    private void resolveSearch(NameValueCollection queryString)
    {
        if (!SearchParams.hasAllMinimumRequiredParams(queryString))
            return;
        
        SearchResult sr = new SearchResult(SearchParams.Builder.buildFromQueryString(queryString));
        pHolder.Controls.Add(sr);
        sr.DataBind();
    }

    protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDdlSubtipoContent(Convert.ToInt64(ddlTipo.SelectedValue));
    }

    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        string url = BuildUrl();
        Response.Redirect(url);
    }

    private string BuildUrl()
    {
        StringBuilder sb = new StringBuilder("/pesquisa?");
        sb.Append("p=").Append(ddlPesquisa.SelectedValue);
        sb.Append("&q=").Append(txbPesquisa.Text);

        if (Convert.ToInt64(ddlCidade.SelectedValue) != -1)
            sb.Append("&cidade=").Append(ddlCidade.SelectedItem.Text);

        sb.Append("&min=").Append(min.Value);
        sb.Append("&max=").Append(max.Value);

        if (Convert.ToInt64(ddlTipo.SelectedValue) != -1)
            sb.Append("&t=").Append(ddlSubtipo.SelectedValue);

        return sb.ToString();
    }

    private void FillFormFields(NameValueCollection queryString)
    {
        if (queryString.AllKeys.Contains("q"))
            txbPesquisa.Text = queryString["q"].ToString();

        if (queryString.AllKeys.Contains("p"))
            ddlPesquisa.SelectedValue = queryString["p"];

        if (queryString.AllKeys.Contains("min") && queryString.AllKeys.Contains("max"))
        {
            min.Value = queryString["min"];
            max.Value = queryString["max"];
        }
    }
}