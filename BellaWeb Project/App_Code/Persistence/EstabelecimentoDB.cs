using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class EstabelecimentoDB
    {
        public static long Insert(Estabelecimento estabelecimento)
        {
            long codigo = 0;
            string query = "INSERT INTO est_estabelecimentos " +
                "(est_fantasia, est_razaosocial, est_cnpj, est_endendereco, est_endnumero, est_endbairro, est_endcep, est_cxmensagemestado, est_posicaolat, est_posicaolong, est_telefone, est_celular, est_nomeresponsavel, cid_codigo) VALUES" +
                "(?fantasia, ?razaosocial, ?cnpj, ?endereco, ?numero, ?bairro, ?cep, ?mensagemestado, ?latitude, ?longitude, ?telefone, ?celular, ?responsavel, ?cidade_codigo); SELECT LAST_INSERT_ID();";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?fantasia", estabelecimento.Fantasia);
                dbHelper.AddParameter("?razaosocial", estabelecimento.RazaoSocial);
                dbHelper.AddParameter("?cnpj", estabelecimento.Cnpj);
                dbHelper.AddParameter("?endereco", estabelecimento.Endereco.Logradouro);
                dbHelper.AddParameter("?numero", estabelecimento.Endereco.Numero);
                dbHelper.AddParameter("?bairro", estabelecimento.Endereco.Bairro);
                dbHelper.AddParameter("?cep", estabelecimento.Endereco.Cep);
                dbHelper.AddParameter("?ativacaoestado", estabelecimento.StatusAtivacao);
                dbHelper.AddParameter("?mensagemestado", (estabelecimento.RecebeMensagem) ? "SIM" : "NAO");
                dbHelper.AddParameter("?latitude", estabelecimento.Posicao.Latitude);
                dbHelper.AddParameter("?longitude", estabelecimento.Posicao.Longitude);
                dbHelper.AddParameter("?telefone", estabelecimento.Telefone);
                dbHelper.AddParameter("?celular", estabelecimento.Celular);
                dbHelper.AddParameter("?responsavel", estabelecimento.Responsavel);
                dbHelper.AddParameter("?cidade_codigo", estabelecimento.Endereco.Cidade.Codigo);
                codigo = Convert.ToInt64(dbHelper.Command.ExecuteScalar());
                dbHelper.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                codigo = -2;
            }

            return codigo;
        }

        public static int Update(Estabelecimento estabelecimento)
        {
            int resultStatus = 0;
            string query = "UPDATE est_estabelecimentos SET " +
                            "est_fantasia = ?fantasia, " +
                            "est_razaosocial = ?razaosocial, " +
                            "est_cnpj = ?cnpj, " +
                            "est_endcep = ?cep, " +
                            "est_endendereco = ?endereco, " +
                            "est_endnumero = ?numero, " +
                            "est_endbairro = ?bairro, " +
                            "est_cxmensagemestado = ?mensagemestado, " +
                            "est_posicaolat = ?latitude, " +
                            "est_posicaolong = ?longitude, " +
                            "est_telefone = ?telefone, " +
                            "est_celular = ?celular, " +
                            "est_nomeresponsavel = ?responsavel, " +
                            "est_imagemurl = ?imagemurl " +
                            "WHERE est_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", estabelecimento.Codigo);
                dbHelper.AddParameter("?fantasia", estabelecimento.Fantasia);
                dbHelper.AddParameter("?razaosocial", estabelecimento.RazaoSocial);
                dbHelper.AddParameter("?cnpj", estabelecimento.Cnpj);
                dbHelper.AddParameter("?cep", estabelecimento.Endereco.Cep);
                dbHelper.AddParameter("?endereco", estabelecimento.Endereco.Logradouro);
                dbHelper.AddParameter("?numero", estabelecimento.Endereco.Numero);
                dbHelper.AddParameter("?bairro", estabelecimento.Endereco.Bairro);
                dbHelper.AddParameter("?mensagemestado", (estabelecimento.RecebeMensagem) ? "SIM" : "NAO");
                dbHelper.AddParameter("?latitude", estabelecimento.Posicao.Latitude);
                dbHelper.AddParameter("?longitude", estabelecimento.Posicao.Longitude);
                dbHelper.AddParameter("?telefone", estabelecimento.Telefone);
                dbHelper.AddParameter("?responsavel", estabelecimento.Responsavel);
                dbHelper.AddParameter("?celular", estabelecimento.Celular);
                dbHelper.AddParameter("?imagemurl", estabelecimento.ImagemUrl);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int UpdateStatusNegado(Estabelecimento estabelecimento)
        {
            int resultStatus = 0;
            string query = "UPDATE est_estabelecimentos SET est_ativacaoestado = ?ativacaoestado WHERE est_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", estabelecimento.Codigo);
                dbHelper.AddParameter("?ativacaoestado", "NEGADO");
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int UpdateStatusAprovado(Estabelecimento estabelecimento)
        {
            int resultStatus = 0;
            string query = "UPDATE est_estabelecimentos SET est_ativacaoestado = ?ativacaoestado WHERE est_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", estabelecimento.Codigo);
                dbHelper.AddParameter("?ativacaoestado", "APROVADO");
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int UpdateStatusAguardando(Estabelecimento estabelecimento)
        {
            int resultStatus = 0;
            string query = "UPDATE est_estabelecimentos SET est_ativacaoestado = ?ativacaoestado WHERE est_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", estabelecimento.Codigo);
                dbHelper.AddParameter("?ativacaoestado", "AGUARDANDO");
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Estabelecimento estabelecimento)
        {
            return Delete(estabelecimento.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM est_estabelecimentos WHERE est_codigo = ?codigo;";

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

        public static Estabelecimento Select(long codigo)
        {
            Estabelecimento estabelecimento = null;
            string query = "SELECT * FROM est_estabelecimentos WHERE est_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                while (dataReader.Read())
                {
                    estabelecimento = new Estabelecimento();
                    estabelecimento.Codigo = Convert.ToInt64(dataReader["est_codigo"]);
                    estabelecimento.Fantasia = Convert.ToString(dataReader["est_fantasia"]);
                    estabelecimento.RazaoSocial = Convert.ToString(dataReader["est_razaosocial"]);
                    estabelecimento.Cnpj = Convert.ToString(dataReader["est_cnpj"]);


                    Endereco end = new Endereco();
                    end.Logradouro = Convert.ToString(dataReader["est_endendereco"]);
                    end.Numero = Convert.ToString(dataReader["est_endnumero"]);
                    end.Bairro = Convert.ToString(dataReader["est_endbairro"]);
                    end.Cep = Convert.ToString(dataReader["est_endcep"]);
                    long cidCod = Convert.ToInt64(dataReader["cid_codigo"]);

                    end.Cidade = CidadeDB.Select(cidCod);

                    estabelecimento.Endereco = end;

                    estabelecimento.StatusAtivacao = Convert.ToString(dataReader["est_ativacaoestado"]);
                    estabelecimento.RecebeMensagem = (Convert.ToString(dataReader["est_cxmensagemestado"]) == "SIM");

                    Posicao pos = new Posicao();
                    pos.Latitude = Convert.ToDouble(dataReader["est_posicaolat"]);
                    pos.Longitude = Convert.ToDouble(dataReader["est_posicaolong"]);
                    estabelecimento.Posicao = pos;

                    estabelecimento.Responsavel = Convert.ToString(dataReader["est_nomeresponsavel"]);
                    estabelecimento.Telefone = Convert.ToString(dataReader["est_telefone"]);
                    estabelecimento.Celular = Convert.ToString(dataReader["est_celular"]);

                    estabelecimento.ImagemUrl = Convert.ToString(dataReader["est_imagemurl"]);

                    estabelecimento.Plus = (Convert.ToInt32(dataReader["est_plus"]) == 1);
                }
                dbHelper.Dispose();
            }
            catch (Exception ex)
            {
                estabelecimento = null;
            }

            return estabelecimento;
        }

        public static DataSet SelectAll()
        {
            DataSet dataset = new DataSet();
            string query = "SELECT * FROM est_estabelecimentos;";

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

        public static DataSet SelectAllAtivo()
        {
            DataSet dataset = new DataSet();
            string query = "SELECT * FROM est_estabelecimentos WHERE est_ativacaoestado = 'APROVADO';";

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

        public static DataSet SelectByEstadoAtivacao(string estadoAtivacao)
        {
            DataSet dataset = new DataSet();
            string query = (estadoAtivacao.Equals(string.Empty))
                ? "SELECT * FROM est_estabelecimentos;"
                : "SELECT * FROM est_estabelecimentos WHERE est_ativacaoestado = ?estado_ativacao;";



            DBHelper dbHelper;
            IDataAdapter adapter;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?estado_ativacao", estadoAtivacao);
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

        public static DataSet SelectAllAguardando()
        {
            DataSet dataset = new DataSet();
            string query = "SELECT * FROM est_estabelecimentos WHERE est_ativacaoestado = 'AGUARDANDO';";

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

        public static DataSet SelectAllNegado()
        {
            DataSet dataset = new DataSet();
            string query = "SELECT * FROM est_estabelecimentos WHERE est_ativacaoestado = 'NEGADO';";

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

        public static int UpdateAtivarPlus(Estabelecimento estabelecimento)
        {
            int resultStatus = 0;
            string query = "UPDATE est_estabelecimentos SET est_plus = ?plus WHERE est_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", estabelecimento.Codigo);
                if (estabelecimento.Plus == false)
                    dbHelper.AddParameter("?plus", 1);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int UpdateDesativarPlus(Estabelecimento estabelecimento)
        {
            int resultStatus = 0;
            string query = "UPDATE est_estabelecimentos SET est_plus = ?plus WHERE est_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", estabelecimento.Codigo);
                if (estabelecimento.Plus == true)
                    dbHelper.AddParameter("?plus", 0);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }
    }
}