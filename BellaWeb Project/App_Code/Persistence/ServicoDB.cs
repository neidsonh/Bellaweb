using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Classes.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class ServicoDB
    {
        public static int Insert(Servico servico)
        {
            int resultStatus = 0;
            string query = "INSERT INTO srv_servicos (srv_nome, srv_valor, tps_codigo, est_codigo) VALUES (?nome, ?valor, ?tps, ?est);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?nome", servico.Nome);
                dbHelper.AddParameter("?valor", servico.Preco);
                dbHelper.AddParameter("?tps", servico.TipoServico.Codigo);
                dbHelper.AddParameter("?est", servico.Estabelecimento.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(Servico servico)
        {
            int resultStatus = 0;
            string query = "UPDATE srv_servicos SET srv_nome = ?nome, srv_valor = ?valor WHERE srv_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", servico.Codigo);
                dbHelper.AddParameter("?nome", servico.Nome);
                dbHelper.AddParameter("?valor", servico.Preco);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Servico servico)
        {
            return Delete(servico.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM srv_servicos WHERE srv_codigo = ?codigo;";

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

        public static Servico Select(long codigo)
        {
            Servico servico;
            string query = "SELECT * FROM srv_servicos WHERE srv_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                servico = new Servico();
                while (dataReader.Read())
                {
                    servico.Codigo = Convert.ToInt64(dataReader["srv_codigo"]);
                    servico.Nome = Convert.ToString(dataReader["srv_nome"]);
                    servico.Preco = Convert.ToDouble(dataReader["srv_valor"]);
                    servico.Estabelecimento = EstabelecimentoDB.Select(Convert.ToInt64(dataReader["est_codigo"]));
                    servico.TipoServico = TipoServicoDB.Select(Convert.ToInt64(dataReader["tps_codigo"]));
                }
                dbHelper.Dispose();
            }
            catch
            {
                servico = null;
            }

            return servico;
        }

        public static List<Servico> SelectByEstabelecimento(Estabelecimento estabelecimento)
        {
            string query = "SELECT * FROM srv_servicos WHERE est_codigo = ?estabelecimento;";
            List<Servico> servicos = new List<Servico>();
            DBHelper dbHelper;
            IDataReader reader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?estabelecimento", estabelecimento.Codigo);
                reader = dbHelper.Command.ExecuteReader();

                while (reader.Read())
                {
                    servicos.Add(new Servico()
                    {
                        Codigo = Convert.ToInt64(reader["srv_codigo"]),
                        Nome = Convert.ToString(reader["srv_nome"]),
                        Preco = Convert.ToDouble(reader["srv_valor"]),
                        Estabelecimento = EstabelecimentoDB.Select(Convert.ToInt64(reader["est_codigo"])),
                        TipoServico = TipoServicoDB.Select(Convert.ToInt64(reader["tps_codigo"]))
                    });
                }
                dbHelper.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return servicos;
        }

        public static DataSet SelectByEstabelecimentoDS(Estabelecimento estabelecimento)
        {
            DataSet dataSet = new DataSet();
            string query = "select srv.srv_nome as nome, srv.est_codigo, srv.srv_codigo as codigo, srv.srv_valor as valor, tps.tps_nome as tipo_servico, tpai.tps_nome as tipo_pai from srv_servicos as srv join tps_tiposervicos as tps using(tps_codigo) join tps_tiposervicos as tpai on tps.tps_tipopai = tpai.tps_codigo join est_estabelecimentos as est using(est_codigo) WHERE srv.est_codigo = ?estabelecimento;";

            DBHelper dbHelper;
            IDataAdapter adapter;
            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?estabelecimento", estabelecimento.Codigo);
                adapter = dbHelper.Adapter;
                adapter.Fill(dataSet);
                dbHelper.Dispose();

            }
            catch { dataSet = null; }

            return dataSet;
        }

        public static Dictionary<TipoServico, List<Servico>> MapTipoServicoByEstabelecimento(Estabelecimento estabelecimento)
        {
            List<Servico> servicos = SelectByEstabelecimento(estabelecimento);
            Dictionary<TipoServico, List<Servico>> map = new Dictionary<TipoServico, List<Servico>>();
            foreach (Servico servico in servicos)
            {
                if (!map.Keys.Contains(servico.TipoServico.TipoPai, new TipoServicoComparer()))
                    map.Add(servico.TipoServico.TipoPai, new List<Servico>());

                map[servico.TipoServico.TipoPai].Add(servico);
            }
            return map;
        }

        public static DataSet SelectAll()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM srv_servicos;";

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