using Bellaweb.App_Code.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DropDownTipoServicos
/// </summary>
public class MenuTipoServicos : Panel
{
    DataSet ds;

    public override void DataBind()
    {
        DataTable table = ds.Tables[0];
        StringBuilder sb = new StringBuilder("<ul class='nav navbar-nav menu'>");

        foreach (DataRow row in table.Rows)
        {
            sb.Append(HtmlListItem(row));
        }

        sb.Append("</ul>");
        Controls.Add(new LiteralControl(sb.ToString()));
    }
    
    private string HtmlListItem(DataRow row)
    {
        StringBuilder li = new StringBuilder("<li class='dropdown'>");

        string tipoServico = Convert.ToString(row["tps_tipopai"]);
        List<string> tipoServicos = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(row["tps_subtipos"]));

        li.Append(AnchorTipoPai(tipoServico));
        li.Append(HtmlSubListItem(tipoServicos));
        li.Append("</li>");

        return li.ToString();
    }

    private string HtmlSubListItem(List<string> tipoServicos)
    {
        StringBuilder ul = new StringBuilder("<ul class='dropdown-menu'>");

        for(int i = 0; i < tipoServicos.Count; i += 2) 
        {
            ul.Append(AchorSubTipo(tipoServicos[i], tipoServicos[i+1]));
        }

        ul.Append("</ul>");
        return ul.ToString();
    }

    private string AnchorTipoPai(string nomeTipoPai)
    {
        string baseAnchor = "<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false'>{0} <span class='caret'></span></a>";
        return String.Format(baseAnchor, nomeTipoPai);
    }

    private string AchorSubTipo(string subTipo, string codigo)
    {
        string baseAnchor = "<li><a href='/pesquisa?p=&q=&t={1}'>{0}</a></li>";
        return String.Format(baseAnchor, subTipo, codigo);
    }

    public DataSet DataSource
    {
        get
        {
            return ds;
        }

        set
        {
            ds = value;
        }
    }
}