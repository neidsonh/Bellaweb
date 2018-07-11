using Bellaweb.App_Code.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class UsuarioCrypto : Usuario
    {

        public override string Senha
        {
            get
            {
                return base.Senha;
            }

            set
            {
                base.Senha = Crypto.EncryptSHA512(value);
            }
        }
    }
}