using Bellaweb.App_Code.Classes;
using Bellaweb.App_Code.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Persistence
{
    public class UsuarioDB
    {
        public static long Insert(Usuario usuario)
        {
            long resultStatus = 0;
            string query = "INSERT INTO usr_usuarios (usr_email, usr_senha, usr_ativo, est_codigo, adm_codigo) VALUES (?email, ?senha, ?ativo, ?estabelecimento, ?administrador); SELECT LAST_INSERT_ID();";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?email", usuario.Email);
                dbHelper.AddParameter("?senha", usuario.Senha);
                dbHelper.AddParameter("?ativo", (usuario.Ativo) ? 0 : 1);
                dbHelper.AddParameter("?estabelecimento", Utils.EstabelecimentoIdOrNull(usuario));
                dbHelper.AddParameter("?administrador", Utils.AdmIdOrNull(usuario));
                resultStatus = Convert.ToInt64(dbHelper.Command.ExecuteScalar());
                dbHelper.Dispose();
            }
            catch (Exception e)
            {
                resultStatus = -2;
                Console.Write(e.Message);
            }

            return resultStatus;
        }

        public static int Update(Usuario usuario)
        {
            int resultStatus = 0;
            string query = "UPDATE usr_usuarios SET usr_email = ?email, usr_senha = ?senha WHERE usr_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", usuario.Codigo);
                dbHelper.AddParameter("?email", usuario.Email);
                dbHelper.AddParameter("?senha", usuario.Senha);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int UpdateSenha(Usuario usuario)
        {
            int resultStatus = 0;
            string query = "UPDATE usr_usuarios SET usr_senha = ?senha WHERE usr_codigo = ?codigo;";

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", usuario.Codigo);
                dbHelper.AddParameter("?senha", usuario.Senha);
                dbHelper.Command.ExecuteNonQuery();
                dbHelper.Dispose();
            }
            catch{
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static int Delete(Usuario usuario)
        {
            return Delete(usuario.Codigo);
        }

        public static int Delete(long codigo)
        {
            int resultStatus = 0;
            string query = "DELETE FROM usr_usuarios WHERE usr_codigo = ?codigo;";

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

        public static Usuario Select(Usuario usuario)
        {
            string query = "SELECT * FROM usr_usuarios WHERE usr_email = ?email AND usr_senha = ?senha AND usr_ativo = 1;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?email", usuario.Email);
                dbHelper.AddParameter("?senha", usuario.Senha);
                dataReader = dbHelper.Command.ExecuteReader();
                while (dataReader.Read())
                {
                    usuario.Codigo = Convert.ToInt64(dataReader["usr_codigo"]);
                    usuario.Ativo = Convert.ToInt32(dataReader["usr_ativo"]) != 0;

                    if (Convert.IsDBNull(dataReader["adm_codigo"]))
                    {
                        usuario.Estabelecimento = EstabelecimentoDB.Select(Convert.ToInt64(dataReader["est_codigo"]));
                    }
                    else if(Convert.IsDBNull(dataReader["est_codigo"]))
                    {
                        usuario.Administrador = AdministradorDB.Select(Convert.ToInt64(dataReader["adm_codigo"]));
                    }
                }
                dbHelper.Dispose();
                dataReader.Dispose();
            }
            catch
            {
                usuario = null;
            }


            return usuario;
        }

        public static Usuario Select(long codigo)
        {
            Usuario usuario;
            string query = "SELECT * FROM usr_usuarios WHERE usr_codigo = ?codigo AND usr_ativo = 1;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                usuario = new Usuario();
                while (dataReader.Read())
                {
                    usuario.Codigo = Convert.ToInt64(dataReader["usr_codigo"]);
                    usuario.Email = Convert.ToString(dataReader["usr_email"]);
                    usuario.Senha = Convert.ToString(dataReader["usr_senha"]);
                    usuario.Ativo = Convert.ToInt32(dataReader["usr_ativo"]) != 0;

                    if (Convert.IsDBNull(dataReader["adm_codigo"]))
                    {
                        usuario.Estabelecimento = EstabelecimentoDB.Select(Convert.ToInt64(dataReader["est_codigo"]));
                        usuario.Administrador = null;
                    }
                    else
                    {
                        usuario.Administrador = AdministradorDB.Select(Convert.ToInt64(dataReader["adm_codigo"]));
                        usuario.Estabelecimento = null;
                    }
                }
                dbHelper.Dispose();
            }
            catch
            {
                usuario = null;
            }

            return usuario;
        }

        public static Usuario SelectByEstabelecimento(Estabelecimento estabelecimento)
        {
            return SelectByEstabelecimento(estabelecimento.Codigo);
        }

        public static Usuario SelectByEstabelecimento(long codigo)
        {
            Usuario usuario;
            string query = "SELECT * FROM usr_usuarios WHERE est_codigo = ?codigo AND usr_ativo = 1;";

            DBHelper dbHelper;
            IDataReader dataReader;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", codigo);
                dataReader = dbHelper.Command.ExecuteReader();

                usuario = new Usuario();
                while (dataReader.Read())
                {
                    usuario.Codigo = Convert.ToInt64(dataReader["usr_codigo"]);
                    usuario.Email = Convert.ToString(dataReader["usr_email"]);
                    usuario.Senha = Convert.ToString(dataReader["usr_senha"]);
                    usuario.Ativo = Convert.ToInt32(dataReader["usr_ativo"]) != 0;

                    if (Convert.IsDBNull(dataReader["adm_codigo"]))
                    {
                        usuario.Estabelecimento = EstabelecimentoDB.Select(Convert.ToInt64(dataReader["est_codigo"]));
                       
                    }
                    else if (Convert.IsDBNull(dataReader["est_codigo"]))
                    {
                        usuario.Administrador = AdministradorDB.Select(Convert.ToInt64(dataReader["adm_codigo"]));
                        
                    }
                }
                dbHelper.Dispose();
            }
            catch
            {
                usuario = null;
            }

            return usuario;
        }

        public static long SelectEmail(string email)
        {
            string query = "SELECT COUNT(*) FROM usr_usuarios WHERE usr_email = ?email;";
            long resultStatus = 0;

            DBHelper dbHelper;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?email", email);
                resultStatus = Convert.ToInt64(dbHelper.Command.ExecuteScalar());
                dbHelper.Dispose();
            }
            catch
            {
                resultStatus = -2;
            }

            return resultStatus;
        }

        public static DataSet SelectAll()
        {
            DataSet dataSet = new DataSet();
            string query = "SELECT * FROM usr_usuarios;";

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

        public static bool IsValid(Usuario usuario)
        {

            string query = "SELECT count(*) FROM usr_usuarios WHERE usr_email = ?email AND usr_senha = ?senha AND usr_ativo = 1;";

            DBHelper dbHelper;
            int count = 0;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?email", usuario.Email);
                dbHelper.AddParameter("?senha", usuario.Senha);
                count = Convert.ToInt32(dbHelper.Command.ExecuteScalar());
                dbHelper.Dispose();
            }
            catch
            {
                count = 0;
            }

            return count == 1;
        }

        public static bool SenhaIsValid(Usuario usuario)
        {

            string query = "SELECT count(*) FROM usr_usuarios WHERE usr_senha = ?senha AND usr_codigo = ?codigo;";

            DBHelper dbHelper;
            int count = 0;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?codigo", usuario.Codigo);
                dbHelper.AddParameter("?senha", usuario.Senha);
                count = Convert.ToInt32(dbHelper.Command.ExecuteScalar());
                dbHelper.Dispose();
            }
            catch
            {
                count = 0;
            }

            return count == 1;
        }

        public static bool EmailExists(string email)
        {
            string query = "SELECT count(*) FROM usr_usuarios WHERE usr_email = ?email;";
            DBHelper dbHelper;
            int count = 0;

            try
            {
                dbHelper = new DBHelper(query);
                dbHelper.AddParameter("?email", email);
                count = Convert.ToInt32(dbHelper.Command.ExecuteScalar());
                dbHelper.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar existência de e-mail", e);
            }

            return count > 0;
        }

    }
}