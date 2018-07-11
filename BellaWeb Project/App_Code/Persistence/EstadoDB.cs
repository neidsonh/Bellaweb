using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Bellaweb.App_Code.Classes;

namespace Bellaweb.App_Code.Persistence
{
    public class EstadoDB
    {
        public static int Insert(Estado estado)
        {
            int resultStatus = 0;
            string query = "INSERT INTO etd_estados (etd_codigo, etd_nome, etd_uf) VALUES (0, ?nome, ?uf);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", estado.Nome);
                dbHelper.AddParameter("?uf", estado.Uf);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(Estado estado)
        {
            int resultStatus = 0;
            string query = "UPDATE FROM etd_estados SET etd_nome = ?nome, etd_uf = ?uf WHERE etd_codigo = ?codigo";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", estado.Nome);
                dbHelper.AddParameter("?uf", estado.Uf);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Estado estado)
        {
            return Delete(estado.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM etd_estados WHERE etd_codigo = ?codigo";

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

        public static Estado Select(long codigo)
        {
            Estado estado;
            string query = "SELECT * FROM etd_estados WHERE etd_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                estado = new Estado();
                while (dataReader.Read())
                {
                    estado.Codigo = Convert.ToInt64(dataReader["etd_codigo"]);
                    estado.Nome = Convert.ToString(dataReader["etd_nome"]);
                    estado.Uf = Convert.ToString(dataReader["etd_uf"]);
                }
                dbHelper.Dispose();
            }
            catch
            {
                estado = null;
            }

            return estado;
        }

        public static Estado Select(Estado uf)
        {
            Estado estado;
            string query = "SELECT * FROM etd_estados WHERE etd_uf = ?uf;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?uf", uf.Uf);
                dataReader = dbHelper.Command.ExecuteReader();

                estado = new Estado();
                while (dataReader.Read())
                {
                    estado.Codigo = Convert.ToInt64(dataReader["etd_codigo"]);
                    estado.Nome = Convert.ToString(dataReader["etd_nome"]);
                    estado.Uf = Convert.ToString(dataReader["etd_uf"]);
                }
                dbHelper.Dispose();
            }
            catch
            {
                estado = null;
            }

            return estado;
        }

        public static DataSet SelectAll()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT etd_codigo, etd_uf FROM etd_estados ORDER BY etd_uf ASC;";

            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                adapter = dbHelper.Adapter;
                adapter.Fill(dataSet);
                dbHelper.Dispose();
            }
            catch
            {
                dataSet = null;
            }

            return dataSet;
        }
    }
}