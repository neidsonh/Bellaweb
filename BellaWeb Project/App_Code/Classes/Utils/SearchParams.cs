using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SearchParams
/// </summary>
public class SearchParams
{
    private string termo;
    private string tipo;
    private string cidade;
    private long tipoServico;
    private Paginacao paginacao;
    private PriceRange priceRange;

    private SearchParams()
    {

    }

    public string Termo
    {
        get
        {
            return termo;
        }

        set
        {
            termo = value;
        }
    }

    public string TipoPesquisa
    {
        get
        {
            return tipo;
        }

        set
        {
            tipo = value;
        }
    }

    public Paginacao Paginacao
    {
        get
        {
            return paginacao;
        }

        set
        {
            paginacao = value;
        }
    }

    public string Cidade
    {
        get
        {
            return cidade;
        }

        set
        {
            cidade = value;
        }
    }

    public long TipoServico
    {
        get
        {
            return tipoServico;
        }

        set
        {
            tipoServico = value;
        }
    }

    public PriceRange PriceRange
    {
        get
        {
            return priceRange;
        }

        set
        {
            priceRange = value;
        }
    }

    public string ToPlainQueryString()
    {
        return ToPlainQueryString(Paginacao.NumeroDaPagina);
    }

    public string ToPlainQueryString(int pagina)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("?p=").Append(Termo).Append("&q=").Append(TipoPesquisa);

        if ((pagina != 1) && Paginacao != null)
            sb.Append("&pagina=").Append(pagina);

        if (PriceRange.isValid())
            sb.Append("&min=").Append(PriceRange.MenorValor).Append("&max=").Append(PriceRange.MaiorValor);

        if (TipoServico != 0)
            sb.Append("&t=").Append(TipoServico);

        if (Cidade != string.Empty)
            sb.Append("&cidade=").Append(Cidade);

        return sb.ToString();
    }

    public class Builder
    {
        private string termo;
        private string tipoDeBusca;
        private string cidade;
        private long codigoTipoServico;
        private Paginacao paginacao;
        private PriceRange priceRange;

        private Builder()
        {
            paginacao = new Paginacao()
            {
                NumeroDaPagina = 1
            };
            cidade = "";
            codigoTipoServico = 0;
        }

        private Builder buildTermo(string termo)
        {
            this.termo = termo;
            return this;
        }

        private Builder buildTipoDePesquisa(string tipo)
        {
            this.tipoDeBusca = tipo;
            return this;
        }

        private Builder buildCidade(Cidade cidade)
        {
            return buildCidade(cidade.Nome);
        }

        private Builder buildCidade(string cidade)
        {
            this.cidade = cidade;
            return this;
        }

        private Builder buildTipoServico(TipoServico tipoServico)
        {
            return buildTipoServico(tipoServico.Codigo);
        }

        private Builder buildTipoServico(long codigo)
        {
            codigoTipoServico = codigo;
            return this;
        }

        private Builder buildPaginacao(int numeroDaPagina)
        {
            paginacao.NumeroDaPagina = numeroDaPagina;
            return this;
        }

        private Builder buildPriceRange(double menor, double maior)
        {
            priceRange = new PriceRange(menor, maior);
            return this;
        }

        private SearchParams build()
        {
            SearchParams searchParams = new SearchParams()
            {
                Termo = termo,
                TipoPesquisa = tipoDeBusca,
                Cidade = cidade,
                TipoServico = codigoTipoServico,
                PriceRange = priceRange,
                Paginacao = paginacao
            };

            return searchParams;
        }

        public static SearchParams buildFromQueryString(NameValueCollection queryString)
        {
            if (!hasAllMinimumRequiredParams(queryString))
                throw new ArgumentException("Não há os parametros minimos para uma pesquisa");

            Builder builder = new Builder();
            builder
                .buildTermo(Convert.ToString(queryString["q"]))
                .buildTipoDePesquisa(Convert.ToString(queryString["p"]));

            if (queryString.AllKeys.Contains("cidade"))
                builder.buildCidade(Convert.ToString(queryString["cidade"]));

            if (queryString.AllKeys.Contains("min") && queryString.AllKeys.Contains("max"))
            {
                try
                {
                    builder.buildPriceRange(Convert.ToDouble(queryString["min"]), Convert.ToDouble(queryString["max"]));
                }
                catch (Exception e)
                {
                    builder.buildPriceRange(0, 0);
                }
            }
            else
            {
                builder.buildPriceRange(0, 0);
            }

            if (queryString.AllKeys.Contains("t"))
                builder.buildTipoServico(Convert.ToInt64(queryString["t"]));

            if (queryString.AllKeys.Contains("pagina"))
                builder.buildPaginacao(Convert.ToInt32(queryString["pagina"]));
            else
                builder.buildPaginacao(1);

            return builder.build();
        }
    }

    public static bool hasAllMinimumRequiredParams(NameValueCollection queryString)
    {
        string[] minimumQueryParams = { "p", "q" };
        bool hasAllParams = queryString.HasKeys();

        foreach (string param in minimumQueryParams)
        {
            if (!(hasAllParams = (queryString[param] != null)))
                break;
        }

        return hasAllParams;
    }
}