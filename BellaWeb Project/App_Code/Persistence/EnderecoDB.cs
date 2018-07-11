using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence {

    /// <summary>
    /// Retorna consultas relacionadas aos endereços em banco de dados
    /// </summary>
    public class EnderecoDB
    {
        public static bool EstadoCidadeIsValid(string cidade, string estado)
        {
            bool isValid = false;
            string query = "SELECT count(*) n FROM etd_estados etd JOIN cid_cidades cid USING (etd_codigo) WHERE etd.etd_uf = ?estado AND cid_nome = ?cidade;";

            DBHelper dbHelper;
            IDataReader reader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?cidade", cidade);
                dbHelper.AddParameter("?estado", estado);
                reader = dbHelper.Command.ExecuteReader();

                reader.Read();
                isValid = Convert.ToInt32(reader["n"]) == 1;
            }
            catch (Exception e)
            {
                throw;
            }

            return isValid;
        }
    }
}