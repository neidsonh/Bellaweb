using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class DestaqueDB
    {
        public static int Insert(Destaque destaque)
        {
            int resultStatus = 0;
            string query = "INSERT INTO des_destaques (des_titulo, des_url, des_imgurl, adm_codigo) VALUES (?titulo, ?url, ?imgurl, ?adm);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?titulo", destaque.Titulo);
                dbHelper.AddParameter("?url", destaque.Url);
                dbHelper.AddParameter("?imgurl", destaque.ImgUrl);
                dbHelper.AddParameter("?adm", destaque.Administrador.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch (Exception e)
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(Destaque destaque)
        {
            int resultStatus = 0;
            string query = "UPDATE des_destaques SET des_titulo = ?titulo, des_url = ?url, des_imgurl = ?imgurl WHERE des_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?titulo", destaque.Titulo);
                dbHelper.AddParameter("?url", destaque.Url);
                dbHelper.AddParameter("?imgurl", destaque.ImgUrl);
                dbHelper.AddParameter("?codigo", destaque.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Destaque destaque)
        {
            return Delete(destaque.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM des_destaques WHERE des_codigo = ?codigo;";

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

        public static Destaque Select(long codigo)
        {
            Destaque destaque;
            string query = "SELECT * FROM des_destaques WHERE des_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                destaque = new Destaque();
                while (dataReader.Read())
                {
                    destaque.Codigo = Convert.ToInt64(dataReader["des_codigo"]);
                    destaque.Titulo = Convert.ToString(dataReader["des_titulo"]);
                    destaque.Url = Convert.ToString(dataReader["des_url"]);
                    destaque.ImgUrl = Convert.ToString(dataReader["des_imgurl"]);
                    destaque.Administrador = AdministradorDB.Select(Convert.ToInt64(dataReader["adm_codigo"]));
                }
                dbHelper.Dispose();
            }
            catch
            {
                destaque = null;
            }

            return destaque;
        }

        public static DataSet SelectLastItems()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT des_titulo, des_url, des_imgurl FROM des_destaques ORDER BY des_codigo DESC LIMIT 4";

            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                adapter = dbHelper.Adapter;
                adapter.Fill(dataSet);
                dbHelper.Dispose();
            }
            catch (Exception e)
            {
                throw;
            }

            return dataSet;
        }

        public static DataSet SelectAll()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM des_destaques JOIN adm_administradores using(adm_codigo);";

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