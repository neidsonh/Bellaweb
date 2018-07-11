using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class AdministradorDB
    {
        public static int Insert(Administrador administrador)
        {
            int resultStatus = 0;
            string query = "INSERT INTO adm_administradores (adm_nome) VALUES (?nome);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", administrador.Nome);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(Administrador adm)
        {
            int resultStatus = 0;
            string query = "UPDATE adm_administradores SET adm_nome = ?nome WHERE adm_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", adm.Codigo);
                dbHelper.AddParameter("?nome", adm.Nome);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Administrador adm)
        {
            return Delete(adm.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM adm_administradores WHERE adm_codigo = ?codigo;";

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

        public static Administrador Select(long codigo)
        {
            Administrador adm;
            string query = "SELECT * FROM adm_administradores WHERE adm_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                adm = new Administrador();
                while (dataReader.Read())
                {
                    adm.Codigo = Convert.ToInt64(dataReader["adm_codigo"]);
                    adm.Nome = Convert.ToString(dataReader["adm_nome"]);
                }
                dbHelper.Dispose();
            }
            catch
            {
                adm = null;
            }

            return adm;
        }

        public static DataSet SelectAll()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM adm_administradores;";

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