using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class PromocaoDB
    {
        public static int Insert(Promocao promocao)
        {
            int resultStatus = 0;
            string query = "INSERT INTO pro_promocoes (pro_novovalor, pro_datainicio, pro_dataexpiracao) VALUES (?novovalor, ?datainicio, ?dataexpiracao);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?novovalor", promocao.NovoPreco);
                dbHelper.AddParameter("?datainicio", promocao.DataInicio);
                dbHelper.AddParameter("?dataexpiracao", promocao.DataFinal);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(Promocao promocao)
        {
            int resultStatus = 0;
            string query = "UPDATE pro_promocoes SET pro_novovalor = ?novovalor, pro_datainicio = ?datainicio, pro_dataexpiracao = ?dataexpiracao WHERE pro_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", promocao.Codigo);
                dbHelper.AddParameter("?novovalor", promocao.NovoPreco);
                dbHelper.AddParameter("?datainicio", promocao.DataInicio);
                dbHelper.AddParameter("?dataexpiracao", promocao.DataFinal);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Promocao promocao)
        {
            return Delete(promocao.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM pro_promocoes WHERE pro_codigo = ?codigo;";

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

        public static Promocao Select(long codigo)
        {
            Promocao promocao;
            string query = "SELECT * FROM pro_promocoes WHERE pro_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                promocao = new Promocao();
                while (dataReader.Read())
                {
                    promocao.Codigo = Convert.ToInt64(dataReader["srv_codigo"]);
                    promocao.NovoPreco = Convert.ToDouble(dataReader["pro_novovalor"]);
                    promocao.DataInicio = Convert.ToDateTime(dataReader["pro_datainicio"]);
                    promocao.DataFinal = Convert.ToDateTime(dataReader["pro_dataexpiracao"]);
                    promocao.Servico = ServicoDB.Select(Convert.ToInt64(dataReader["srv_codigo"]));
                }
                dbHelper.Dispose();
            }
            catch
            {
                promocao = null;
            }

            return promocao;
        }

        public static DataSet SelectAll()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM pro_promocoes;";

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