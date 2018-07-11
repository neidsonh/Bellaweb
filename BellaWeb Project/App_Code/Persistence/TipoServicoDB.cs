using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class TipoServicoDB
    {
        public static int Insert(TipoServico tipoServico)
        {
            int resultStatus = 0;
            string query = "INSERT INTO tps_tiposervicos (tps_codigo, tps_nome, tps_tipopai) VALUES(0, ?nome, ?tipopai);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", tipoServico.Descricao);
                dbHelper.AddParameter("?tipopai", Utils.TipoPaiCodigoOuNull(tipoServico));
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(TipoServico tiposervico)
        {
            int resultStatus = 0;
            string query = "UPDATE tps_tiposervicos SET tps_nome = ?nome, tps_tipopai = ?tipopai WHERE tps_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", tiposervico.Descricao);
                dbHelper.AddParameter("?tipopai", Utils.TipoPaiCodigoOuNull(tiposervico));
                dbHelper.AddParameter("?codigo", tiposervico.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(TipoServico tiposervico)
        {
            return Delete(tiposervico.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM tps_tiposervicos WHERE tps_codigo = ?codigo;";

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

        public static TipoServico Select(long codigo)
        {
            TipoServico tipoServico;
            string query = "SELECT * FROM tps_tiposervicos WHERE tps_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                tipoServico = new TipoServico();
                while (dataReader.Read())
                {
                    tipoServico.Codigo = Convert.ToInt64(dataReader["tps_codigo"]);
                    tipoServico.Descricao = Convert.ToString(dataReader["tps_nome"]);
                    if (dataReader["tps_tipopai"] == DBNull.Value)
                        tipoServico.TipoPai = null;
                    else
                        tipoServico.TipoPai = TipoServicoDB.Select(Convert.ToInt64(dataReader["tps_tipopai"]));
                }
                dbHelper.Dispose();
            }
            catch
            {
                tipoServico = null;
            }

            return tipoServico;
        }

        public static bool NomeIsValid(string tps_nome)
        {
            TipoServico tipoServico;
            string query = "SELECT * FROM tps_tiposervicos WHERE tps_nome = ?tps_nome;";

            bool retorno = true;
            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?tps_nome", tps_nome);
                dataReader = dbHelper.Command.ExecuteReader();

                tipoServico = new TipoServico();
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

        public static DataSet SelectByTipoServicos(long tpsTipopai)
        {
            DataSet dataset = new DataSet();
            string query = "SELECT * FROM tps_tiposervicos WHERE tps_tipopai = ?tipoPai;";

            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?tipoPai", tpsTipopai);
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
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM tps_tiposervicos WHERE tps_tipopai is null;";

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

        public static DataSet SelectTipoSubTipo()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT tpai.tps_nome tps_tipopai, CONCAT('[\"', GROUP_CONCAT(tsub.tps_nome, '\",\"', tsub.tps_codigo ORDER BY tsub.tps_nome ASC SEPARATOR '\",\"'), '\"]') tps_subtipos FROM tps_tiposervicos tpai JOIN tps_tiposervicos tsub ON tpai.tps_codigo = tsub.tps_tipopai WHERE tpai.tps_tipopai IS NULL GROUP BY tpai.tps_codigo ORDER BY tpai.tps_nome ASC;";

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
                throw e;
            }

            return dataSet;
        }

    }
}