using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_MenuTipoServico : System.Web.UI.UserControl
{

    MenuTipoServicos menu;

    public Controls_MenuTipoServico()
    {
        menu = new MenuTipoServicos();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Controls.Add(menu);
    }

    public DataSet DataSource {
        get {
            return menu.DataSource;
        }

        set {
            menu.DataSource = value;
        }
    }

    public override void DataBind()
    {
        menu.DataBind();
    }
}