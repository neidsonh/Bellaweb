using Bellaweb.App_Code.Persistence;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for SearchResult
/// </summary>
public class SearchResult : Panel
{
    private static string baseHtml = @"
        <div class='borderResult'>
            <div class='row'>
                <div class='col-sm-2'>
                    <div class='img-profile-search'>
                        <img src='{0}' class='img-responsive img-thumbnail' title='Perfil' />
                    </div>
                    {1}
                </div>
                <div class='col-sm-10'>
                    <p class='conteudoSearch text-result' >{2}</p>
                    <div class='row'>
                        <div class='col-sm-12'>
                            <p class='text-result-sub'>{3}</p>
                        </div>
                    </div>
                    <div class='row'>
                        <div class='col-sm-4'>
                            <p class='text-result-sub'><span class='glyphicon glyphicon-phone-alt text-blue'></span> {4}</p>
                        </div>
                    </div>
                </div> 
            </div> 
            <div class='row'>
                <div class='col-sm-12'>
                    <div class='panel'>
                        <div class='panel-heading'>
                            <p class='text-result-servicos'>Serviços</p>
                        </div>
                        <div class='panel-body text-result-itens-servico'>
                            {5}
                        </div>
                    </div>
                </div>
            </div>     
        </div>";

    private DataSet dataSource;
    private int count;
    private SearchParams searchParams;

    public SearchResult(SearchParams searchParams)
    {
        this.SearchParams = searchParams;
        count = 0;
    }

    public SearchParams SearchParams
    {
        get
        {
            return searchParams;
        }

        set
        {
            searchParams = value;
            dataSource = PesquisaDB.Pesquisar(searchParams);
        }
    }

    public DataSet DataSource
    {
        get
        {
            return dataSource;
        }
    }

    public int Count
    {
        get
        {
            return count;
        }
    }

    public Paginacao Paginacao
    {
        get
        {
            return searchParams.Paginacao;
        }
    }

    public override void DataBind()
    {
        DataTable resultTable = dataSource.Tables[0];
        count = Convert.ToInt32(dataSource.Tables[1].Rows[0]["count"]);

        ClearChild();
        Controls.Add(DisplaySize(Count));

        foreach (DataRow row in resultTable.Rows)
        {
            ItemPesquisa itemPesquisa = ToItemPesquisa(row);
            Controls.Add(Div(itemPesquisa));
        }

        Controls.Add(PageNav(searchParams, Count));

    }

    public void ClearChild()
    {
        foreach (Control control in Controls)
        {
            Controls.Remove(control);
        }
    }

    private static ItemPesquisa ToItemPesquisa(DataRow Row)
    {
        long codigo = Convert.ToInt64(Row["est_codigo"]);
        string fantasia = Convert.ToString(Row["est_fantasia"]);
        string imgurl = Convert.ToString(Row["est_imagemurl"]);
        string end = Convert.ToString(Row["est_endereco"]);
        string info = Convert.ToString(Row["est_info"]);
        bool plus = Convert.ToInt32(Row["est_plus"]) == 1;
        string servicos = Convert.ToString(Row["srv_servicos"]);
        return new ItemPesquisa()
        {
            EstCodigo = codigo,
            EstFantasia = fantasia,
            ImagemUrl = imgurl,
            Endereco = end,
            Info = info,
            Plus = plus,
            Servicos = servicos
        };
    }

    private static Control Div(ItemPesquisa itemPesquisa)
    {
        string finalHtml = String.Format(baseHtml,
                                        itemPesquisa.ImagemUrl,
                                        PlusPlanText(itemPesquisa.Plus),
                                        itemPesquisa.EstFantasia,
                                        itemPesquisa.Endereco,
                                        itemPesquisa.Info,
                                        ServicosLiteral(itemPesquisa.ServicosJSON, itemPesquisa.EstCodigo));
        return new LiteralControl(finalHtml);
    }

    private static string PlusPlanText(bool plus)
    {
        if (!plus)
            return "";

        return @"
            <div class='img-bellawebplus'>
                <img src='../assets/img/BWPlus.png' class='img-responsive' title='Perfil' />
            </div>";
    }

    private static string ServicosLiteral(JArray Servicos, long codigo)
    {
        StringBuilder sbServicos = new StringBuilder();
        for (int i = 0; i < Math.Min(Servicos.Count, 8); i++)
        {
            JToken servico = Servicos[i];
            sbServicos.Append("<div class='list-group col-xs-12 col-sm-6 col-md-4'>");
            sbServicos.Append(servico["nome"]).Append("&nbsp- R$&nbsp").Append(Convert.ToDouble(servico["preco"]).ToString("N2"));
            sbServicos.Append("</div>");
        }
        sbServicos.Append("<div class='list-group col-xs-12 col-sm-6 col-md-4'>")
            .Append("<a class='text-result-link' href='/estabelecimento/").Append(codigo).Append("'><span class='glyphicon glyphicon-plus-sign'></span> Ver mais</a>")
            .Append("</div>");

        return sbServicos.ToString();
    }

    private static Control DisplaySize(int Size)
    {
        string html = @"
            <div class='border-filter'>
                <div class='row'>
                    <div class='col-sm-12'>
                        <p class='text-result-sub'>{0} aos paramêtros da pesquisa</p>
                    </div>
                </div>
            </div>";

        string text = GeneratePhraseBySize(Size);
        return new LiteralControl(string.Format(html, text));
    }

    private static string GeneratePhraseBySize(int Size)
    {
        string phrase;

        if (Size == 0)
        {
            phrase = "Nenhum estabelecimento corresponde";
        }
        else if (Size == 1)
        {
            phrase = "1 estabelecimento corresponde";
        }
        else
        {
            phrase = string.Format("{0} estabelecimentos correspondem", Size);
        }

        return phrase;
    }

    private static Control PageNav(SearchParams sp, int count)
    {
        string baseUl = @"
        <div class='row'>
            <div class='col-md-6 col-md-offset-3'>
                <ul class='pagination'>{0}</ul>
            </div>
        </div>";
        StringBuilder liBuilder = new StringBuilder();

        for(int i = 0; i < Math.Ceiling((double) count / sp.Paginacao.LimitePorPagina); i++)
        {
            liBuilder.Append("<li");

            if (i == sp.Paginacao.NumeroDaPagina - 1)
                liBuilder.Append(" class='active'");

            liBuilder.Append("><a href='/pesquisa").Append(sp.ToPlainQueryString(i + 1)).Append("'>")
                   .Append(i + 1).Append("</a>");
            liBuilder.Append("</li>");
        }

        return new LiteralControl(string.Format(baseUl, liBuilder.ToString()));
    }
}