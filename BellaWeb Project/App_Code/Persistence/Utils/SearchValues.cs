using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;


namespace Bellaweb.App_Code.Persistence
{
    /// <summary>
    /// Summary description for SearchValues
    /// </summary>
    public class SearchValues
    {
        private static string whereEstabelecimento = "est.est_fantasia LIKE ?name OR est.est_razaosocial LIKE ?name";
        private static string whereServico = "srv.srv_nome LIKE ?name OR tps.tps_nome LIKE ?name";
        private static string whereCidade = "cid.cid_nome = ?cidade_nome";
        private static string whereTipoServico = "tps.tps_codigo = ?tps_codigo";
        private static string wherePriceRange = "srv.srv_valor >= ?valor_min AND srv.srv_valor <= ?valor_max";

        private static string limitPaginations = "LIMIT ?page, ?amount";

        private static string countParams = "est.est_codigo";
        private static string columnsParams = @"
                est.est_codigo est_codigo,
                est.est_fantasia est_fantasia,
                est.est_imagemurl est_imagemurl,
                CONCAT(cid.cid_nome, ' - ', etd.etd_uf) est_endereco,
                est.est_telefone est_info,
                est.est_plus est_plus, 
                CONCAT('[', group_concat(concat('{ ""codigo"":', srv.srv_codigo, ', ""nome"": ""', srv.srv_nome, '"", ""preco"": ', srv.srv_valor) SEPARATOR '}, '), '}]') srv_servicos";

        private static string baseCount = "SELECT COUNT(*) count FROM ({0}) a;";
        private static string baseQuery = @"SELECT 
                {2}
            FROM est_estabelecimentos est 
            JOIN srv_servicos srv USING (est_codigo) 
            JOIN usr_usuarios usr USING (est_codigo)
            JOIN tps_tiposervicos tps USING (tps_codigo)
            JOIN cid_cidades cid USING (cid_codigo)
            JOIN etd_estados etd USING (etd_codigo)
            WHERE ({0}) AND (est.est_ativacaoestado = 'APROVADO' AND usr.usr_ativo = 1)
            GROUP BY est.est_codigo
            {1}";

        public const string TIPO_PESQUISA_ESTABELECIMENTO = "estabelecimento";
        public const string TIPO_PESQUISA_SERVICO = "servico";
        public const string TIPO_PESQUISA_TODOS = "";

        private SearchParams searchParams;
        private string query;
        private IDbDataParameter[] parameters;

        public SearchValues(SearchParams searchParams)
        {
            this.searchParams = searchParams;
            query = generateQuery();
            parameters = generateParameters();
        }

        private string generateQuery()
        {
            string withLimit, noLimit, whereGenerated;

            whereGenerated = generateWhere();
            withLimit = string.Format(baseQuery, whereGenerated, limitPaginations, columnsParams);
            noLimit = string.Format(baseCount, string.Format(baseQuery, whereGenerated, "", countParams));

            Console.WriteLine(noLimit);

            return string.Format("{0};{1}", withLimit, noLimit);
        }

        private string generateWhere()
        {
            StringBuilder baseWhere = new StringBuilder("(");
            if (searchParams.TipoPesquisa == TIPO_PESQUISA_ESTABELECIMENTO)
            {
                baseWhere.Append(whereEstabelecimento);
            }
            else if (searchParams.TipoPesquisa == TIPO_PESQUISA_SERVICO)
            {
                baseWhere.Append(whereServico);
            }
            else
            {
                baseWhere.Append(whereEstabelecimento).Append(" OR ").Append(whereServico);
            }

            baseWhere.Append(")");

            if (searchParams.Cidade != string.Empty && searchParams.Cidade != "-1")
                baseWhere.Append(" AND ").Append(whereCidade);

            if (searchParams.TipoServico > 0)
                baseWhere.Append(" AND ").Append(whereTipoServico);

            if (searchParams.PriceRange.isValid())
                baseWhere.Append(" AND ").Append(wherePriceRange);


            return baseWhere.ToString();
        }

        private IDbDataParameter[] generateParameters()
        {
            List<IDbDataParameter> parameterList = new List<IDbDataParameter>();
            parameterList.Add(Mapped.Parameter("?name", "%" + searchParams.Termo + "%"));
            parameterList.Add(Mapped.Parameter("?cidade_nome", searchParams.Cidade));
            parameterList.Add(Mapped.Parameter("?tps_codigo", searchParams.TipoServico));
            parameterList.Add(Mapped.Parameter("?valor_min", searchParams.PriceRange.MenorValor));
            parameterList.Add(Mapped.Parameter("?valor_max", searchParams.PriceRange.MaiorValor));
            parameterList.Add(Mapped.Parameter("?page", searchParams.Paginacao.IndiceDaPagina()));
            parameterList.Add(Mapped.Parameter("?amount", searchParams.Paginacao.LimitePorPagina));

            return parameterList.ToArray();
        }

        public string Query
        {
            get
            {
                return query;
            }
        }

        public IDbDataParameter[] Parameters
        {
            get
            {
                return parameters;
            }
        }
    }
}