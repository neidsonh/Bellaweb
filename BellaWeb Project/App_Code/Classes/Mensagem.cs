using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Mensagem
    {
        private long codigo;
        private string assunto;
        private string texto;
        private string autorEmail;
        private string autorNome;
        private Estabelecimento estabelecimento;

        public long Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Assunto
        {
            get
            {
                return assunto;
            }

            set
            {
                assunto = value;
            }
        }

        public string Texto
        {
            get
            {
                return texto;
            }

            set
            {
                texto = value;
            }
        }

        public string AutorEmail
        {
            get
            {
                return autorEmail;
            }

            set
            {
                autorEmail = value;
            }
        }

        public string AutorNome
        {
            get
            {
                return autorNome;
            }

            set
            {
                autorNome = value;
            }
        }

        public Estabelecimento Estabelecimento
        {
            get
            {
                return estabelecimento;
            }

            set
            {
                estabelecimento = value;
            }
        }
    }
}