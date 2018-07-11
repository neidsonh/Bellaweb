using Bellaweb.App_Code.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Usuario
    {
        private long codigo;
        private string email;
        private string senha;
        private bool ativo;
        private Estabelecimento estabelecimento;
        private Administrador administrador;

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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public virtual string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public bool Ativo
        {
            get
            {
                return ativo;
            }

            set
            {
                ativo = value;
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
                if (administrador != null)
                    throw new AtribuicaoDeObjetoExeption("Atributo administrador não é nulo");
                estabelecimento = value;
                administrador = null;
            }
        }

        public Administrador Administrador
        {
            get
            {
                return administrador;
            }

            set
            {
                if (estabelecimento != null)
                    throw new AtribuicaoDeObjetoExeption("Atributo estabelecimento não é nulo");
                administrador = value;
                estabelecimento = null;
            }
        }
    }
}