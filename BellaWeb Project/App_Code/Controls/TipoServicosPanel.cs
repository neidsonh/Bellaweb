using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bellaweb.UI.WebControls
{
    public class TipoServicosPanel : Panel
    {

        public TipoServicosPanel(Dictionary<TipoServico, List<Servico>> map)
        {
            
            this.Controls.Add(BuildAccordion(map));
        }

        private static Panel BuildAccordion(Dictionary<TipoServico, List<Servico>> map)
        {
            Panel accordion = new Panel()
            {
                CssClass = "panel-group",
                ID = "accordion",
                ClientIDMode = ClientIDMode.Static
            };
            for (int i = 0; i < map.Keys.Count; i++)
            {
                Control panel = new Panel()
                {
                    CssClass = "panel panel-default"
                };
                TipoServico tipoServico = map.Keys.ElementAt(i);

                panel.Controls.Add(PanelHeading(tipoServico, i + 1));
                panel.Controls.Add(PanelCollapse(map[tipoServico], i + 1));
                accordion.Controls.Add(panel);
            }
            return accordion;
        }

        private static LiteralControl PanelHeading(TipoServico tiposervico, int position)
        {
            return new LiteralControl(@"<div class='panel-heading'><h4 class='panel-title'>
                                <a data-toggle='collapse' data-parent='#accordion' href='#collapse" + position + @"' >
                                     " + tiposervico.Descricao + @"<span class='glyphicon glyphicon-chevron-down' style='float: right'></span></a>
                            </h4></div>");
        }

        private static LiteralControl PanelCollapse(List<Servico> servicos, int position)
        {

            string html = "<div id='collapse" + position + @"' class='panel-collapse collapse'>
                    <div class='panel-body'>
                        <div class='row'>
                            <div class='col-sm-12'>
                                <table class='table table-responsive'>
                                    {0}
                                </table>
                            </div>
                        </div>
                    </div>
                </div>";
            StringBuilder sb = new StringBuilder();
            foreach(Servico servico in servicos)
            {
                sb.Append("<tr class='row'>")
                  .Append("<td class='col-sm-6'>")
                  .Append(servico.Nome)
                  .Append(" (").Append(servico.TipoServico.Descricao).Append(")")
                  .Append("</td>")
                  .Append("<td class='col-sm-6'>R$ ")
                  .Append(servico.Preco.ToString("N2")).Append("</td>")
                  .Append("</tr>");
            }
            return new LiteralControl(String.Format(html, sb.ToString()));
        }
    }

}