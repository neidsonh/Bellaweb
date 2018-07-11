using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class MensagemDB
    {
        public static int Insert(Mensagem msg)
        {
            int resultStatus = 0;
            string query = "INSERT INTO msg_mensagens (msg_assunto, msg_texto, msg_autoremail, msg_autornome, est_codigo) VALUES (?assunto, ?texto, ?autoremail, ?autornome, ?est);";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?assunto", msg.Assunto);
                dbHelper.AddParameter("?texto", msg.Texto);
                dbHelper.AddParameter("?autoremail", msg.AutorEmail);
                dbHelper.AddParameter("?autornome", msg.AutorNome);
                dbHelper.AddParameter("?est", msg.Estabelecimento.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Update(Mensagem msg)
        {
            int resultStatus = 0;
            string query = "UPDATE msg_mensagens SET msg_assunto = ?assunto, msg_texto = ?texto, msg_autoremail = ?autoremail, msg_autornome = ?autornome WHERE msg_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?assunto", msg.Assunto);
                dbHelper.AddParameter("?texto", msg.Texto);
                dbHelper.AddParameter("?autoremail", msg.AutorEmail);
                dbHelper.AddParameter("?autornome", msg.AutorNome);
                dbHelper.AddParameter("?codigo", msg.Codigo);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Mensagem msg)
        {
            return Delete(msg.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM msg_mensagens WHERE msg_codigo = ?codigo;";

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

        public static Mensagem Select(long codigo)
        {
            Mensagem msg;
            string query = "SELECT * FROM msg_mensagens WHERE msg_codigo = ?codigo;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                msg = new Mensagem();
                while (dataReader.Read())
                {
                    msg.Codigo = Convert.ToInt64(dataReader["msg_codigo"]);
                    msg.Assunto = Convert.ToString(dataReader["msg_assunto"]);
                    msg.Texto = Convert.ToString(dataReader["msg_texto"]);
                    msg.AutorEmail = Convert.ToString(dataReader["msg_autoremail"]);
                    msg.AutorNome = Convert.ToString(dataReader["msg_autornome"]);
                    msg.Estabelecimento = EstabelecimentoDB.Select(Convert.ToInt64(dataReader["est_codigo"]));
                }
                dbHelper.Dispose();
            }
            catch
            {
                msg = null;
            }

            return msg;
        }

        public static DataSet SelectAll()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM msg_mensagens;";

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