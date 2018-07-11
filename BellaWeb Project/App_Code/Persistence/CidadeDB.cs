using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Bellaweb.App_Code.Classes;

namespace Bellaweb.App_Code.Persistence
{
    public class CidadeDB
    {
        public static int Insert(Cidade cidade)
        {
            int resultStatus = 0;
            string query = "INSERT INTO cid_cidades (cid_codigo, cid_nome, etd_codigo) VALUES (0, ?nome, ?estado_codigo);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", cidade.Nome);
                dbHelper.AddParameter("?estado_codigo", cidade.Estado.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(Cidade cidade)
        {
            int resultStatus = 0;
            string query = "UPDATE cid_cidades SET cid_nome = ?nome WHERE cid_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", cidade.Nome);
                dbHelper.AddParameter("?codigo", cidade.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Cidade cidade)
        {
            return Delete(cidade.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM cid_cidades WHERE cid_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static Cidade Select(long codigo)
        {
            Cidade cidade;
            string query = "SELECT * FROM cid_cidades WHERE cid_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                cidade = new Cidade();
                while (dataReader.Read())
                {
                    cidade.Codigo = Convert.ToInt64(dataReader["cid_codigo"]);
                    cidade.Nome = Convert.ToString(dataReader["cid_nome"]);
                    long ufCod = Convert.ToInt64(Convert.ToInt64(dataReader["etd_codigo"]));
                    cidade.Estado = EstadoDB.Select(ufCod);
                }
                dbHelper.Dispose();
            }
            catch
            {
                cidade = null;
            }

            return cidade;
        }

        public static Cidade Select(Cidade cidade)
        {

            string query = "SELECT * FROM cid_cidades WHERE cid_nome = ?nome;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", cidade.Nome);
                dataReader = dbHelper.Command.ExecuteReader();

                cidade = new Cidade();
                while (dataReader.Read())
                {
                    cidade.Codigo = Convert.ToInt64(dataReader["cid_codigo"]);
                    cidade.Nome = Convert.ToString(dataReader["cid_nome"]);
                    cidade.Estado = EstadoDB.Select(Convert.ToInt64(dataReader["etd_codigo"]));
                }
                dbHelper.Dispose();
            }
            catch
            {
                cidade = null;
            }

            return cidade;
        }

        public static DataSet SelectByUF(long ufCodigo)
        {
            DataSet dataset = new DataSet();
            string query = "SELECT cid_codigo codigo, cid_nome nome FROM cid_cidades WHERE etd_codigo = ?codigo ORDER BY cid_nome ASC;";

            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", ufCodigo);
                adapter = dbHelper.Adapter;
                adapter.Fill(dataset);
                dbHelper.Dispose();
            }
            catch
            {
                dataset = null;
            }

            return dataset;
        }

        public static DataSet SelectAll()
        {
            DataSet dataset = new DataSet();
            string query = "SELECT * FROM cid_cidades;";

            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                adapter = dbHelper.Adapter;
                adapter.Fill(dataset);
                dbHelper.Dispose();
            }
            catch
            {
                dataset = null;
            }

            return dataset;
        }

        public static bool NomeIsValid(string cid_nome, long etd_codigo)
        {
            string query = "SELECT * FROM cid_cidades WHERE cid_nome = ?cid_nome and etd_codigo =?etd_codigo;";

            bool retorno = true;
            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?cid_nome", cid_nome);
                dbHelper.AddParameter("?etd_codigo", etd_codigo);
                dataReader = dbHelper.Command.ExecuteReader();
                while (dataReader.Read())
                {
                    retorno = false;
                }
                dbHelper.Dispose();
            }
            catch
            {
                return retorno = false;
            }


            return retorno;
        }
    }
}