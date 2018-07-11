using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Bellaweb.App_Code.Functions
{

    public class Crypto
    {
        private static byte[] MEMORIA_AUXILIAR = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };


        /// <summary>
        /// Criptografa o texto utilizando determinado Hash
        /// </summary>
        /// <param name="texto">Texto para ser criptografado</param>
        /// <param name="hash">Hash escolhido</param>
        /// <returns>Texto criptografado com o hash escolhido</returns>
        public static string Encrypt(string texto, string hash)
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hash);

            if (hashAlgorithm == null)
            {
                throw new ArgumentException("Descricao do hash estava incorreto");
            }

            byte[] hashByte = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(texto));

            return Convert.ToBase64String(hashByte);

        }

        /// <summary>
        /// Criptografa o texto utilizando SHA512
        /// </summary>
        /// <param name="texto">Texto para ser criptografado</param>
        /// <returns>Textp criptografado com SHA512</returns>
        public static string EncryptSHA512(string texto)
        {
            return Encrypt(texto, "SHA512");
        }

        /// <summary>
        /// Codifica uma string utilizando criptografia AES
        /// </summary>
        /// <param name="textoLimpo">Texto a ser codificado</param>
        /// <returns>Texto codificado</returns>
        public static string AESDecode(string textoLimpo)
        {
            string fraseDeSeguranca = ConfigurationManager.AppSettings["secretKey"];
            byte[] vetorTextoLimpo = Encoding.Unicode.GetBytes(textoLimpo);
            
            using (Aes encryptor = Aes.Create())
            {
            
                byte[] enderecoAuxiliarDeMemoria = MEMORIA_AUXILIAR;
                Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(fraseDeSeguranca, enderecoAuxiliarDeMemoria);
                encryptor.Key = rdb.GetBytes(32);
                encryptor.IV = rdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(vetorTextoLimpo, 0, vetorTextoLimpo.Length);
                        cs.Close();
                    }
                    textoLimpo = Convert.ToBase64String(ms.ToArray());
                }
            }

            return textoLimpo;

        }

        /// <summary>
        /// Decodifica um texto codificado com algoritmo AES
        /// </summary>
        /// <param name="textoCodificado"></param>
        /// <returns></returns>
        public static string AESEncode(string textoCodificado)
        {
            string fraseDeSeguranca = ConfigurationManager.AppSettings["secretKey"];
            byte[] textoCodificadoArray = Convert.FromBase64String(textoCodificado);

            string textoDecodificado;

            try
            {
                using (Aes decryptor = Aes.Create())
                {
                    byte[] memoriaAuxiliar = MEMORIA_AUXILIAR;
                    Rfc2898DeriveBytes rdb = new Rfc2898DeriveBytes(fraseDeSeguranca, memoriaAuxiliar);

                    decryptor.Key = rdb.GetBytes(32);
                    decryptor.IV = rdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(textoCodificadoArray, 0, textoCodificadoArray.Length);
                            cs.Close();
                        }
                        textoDecodificado = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao decodificar texto: " + e.Message);
            }
            return textoDecodificado;
        }
    }
}