using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Bellaweb.App_Code.Functions
{
    public class Utils
    {
        public static object TipoPaiCodigoOuNull(TipoServico tipoServico)
        {
            if (tipoServico.isSubtipo())
                return tipoServico.TipoPai.Codigo;
            return DBNull.Value;
        }

        public static object AdmIdOrNull(Usuario usuario)
        {
            if (usuario.Administrador == null)
                return DBNull.Value;
            return usuario.Administrador.Codigo;
        }

        public static object EstabelecimentoIdOrNull(Usuario usuario)
        {
            if (usuario.Estabelecimento == null)
                return DBNull.Value;
            return usuario.Estabelecimento.Codigo;
        }

        public static string AlertScript(string message)
        {
            return TextScript("alert('" + message + "');");
        }

        public static string LogScript(string message)
        {
            return TextScript("console.log('" + message + "');");
        }

        public static string TextScript(string text)
        {
            return "<script>" + text +"</script>";
        }
        public static void CleanControls(Control control)
        {
            if (control != null)
            {
                foreach (Control c in control.Controls)
                {
                    if (c is TextBox)
                        CleanTextBox((TextBox)c);
                    if (c is DropDownList)
                        CleanDropdowList((DropDownList)c);
                    if (c is HtmlTextArea)
                        CleanTextArea((HtmlTextArea)c);

                    CleanControls(c);

                }
            }
        }

        public static void CleanTextBox(TextBox textBox)
        {
            textBox.Text = string.Empty;
        }
        public static void CleanDropdowList(DropDownList dropdownlist)
        {
            dropdownlist.SelectedIndex = 0;
        }
        public static void CleanTextArea(HtmlTextArea htmltTextArea)
        {
            htmltTextArea.InnerText = string.Empty;
        }

        public static bool IsValidType(string type)
        {
            return type == "image/jpeg" || type == "image/png";
        }
    }
}