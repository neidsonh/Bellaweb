using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{

    /// <summary>
    /// Classe responsável pela pesquisa
    /// </summary>
    public class PesquisaDB
    {

        public static DataSet Pesquisar(SearchParams searchParams)
        {
            DataSet ds;
            DBHelper dbHelper;
            IDataAdapter adapter;

            SearchValues searchValues;

            try
            {
                searchValues = new SearchValues(searchParams);
                dbHelper = new DBHelper(searchValues.Query);
                dbHelper.AddRangeParameter(searchValues.Parameters);
                adapter = dbHelper.Adapter;
                ds = new DataSet();
                adapter.Fill(ds);
                dbHelper.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao pesquisa", e);
            }

            return ds;

        }
    }
}