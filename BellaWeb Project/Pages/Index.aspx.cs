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

public partial class Pages_Index : System.Web.UI.Page
{
    public string notify;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((HtmlHead)Master.FindControl("headMaster")).Title += " Home";
        if (!Page.IsPostBack)
        {

            DataSet ds = DestaqueDB.SelectLastItems();
            CarouselDestaques cd = new CarouselDestaques();
            destaquesContainer.Controls.Add(cd);
            cd.DataSource = ds;
            cd.DataBind();

            verifyQueryString(Request.QueryString);
        }
    }

    private void verifyQueryString(NameValueCollection QueryString)
    {
        if (QueryString.HasKeys() && QueryString.AllKeys.Any(k => k == "n"))
            notify = QueryString["n"];
        else
            notify = "";
    }

    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("/pesquisa?p=" + ddlPesquisa.SelectedValue + "&q=" + txbPesquisa.Text);
    }
}