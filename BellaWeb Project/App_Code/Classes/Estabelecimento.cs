using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Estabelecimento : IEquatable<Estabelecimento>
    {
        public const string APROVADO = "APROVADO";
        public const string AGUARDANDO = "AGUARDANDO";
        public const string NEGADO = "NEGADO";

        private long codigo;
        private string fantasia;
        private string razaoSocial;
        private string cnpj;
        private string statusAtivacao;
        private bool recebeMensagem;
        private Endereco endereco;
        private Posicao posicao;

        private string responsavel;
        private string telefone;
        private string celular;

        private string imagemUrl;

        private bool plus;

        public Estabelecimento()
        {
            StatusAtivacao = Estabelecimento.AGUARDANDO;
            RecebeMensagem = false;
            posicao = new Posicao(0.0, 0.0);
            Plus = false;
        }

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

        public string Fantasia
        {
            get
            {
                return fantasia;
            }

            set
            {
                fantasia = value;
            }
        }

        public string RazaoSocial
        {
            get
            {
                return razaoSocial;
            }

            set
            {
                razaoSocial = value;
            }
        }

        public string Cnpj
        {
            get
            {
                return cnpj;
            }

            set
            {
                cnpj = value;
            }
        }

        public string StatusAtivacao
        {
            get
            {
                return statusAtivacao;
            }

            set
            {
                statusAtivacao = value;
            }
        }

        public bool RecebeMensagem
        {
            get
            {
                return recebeMensagem;
            }

            set
            {
                recebeMensagem = value;
            }
        }

        public Endereco Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public Posicao Posicao
        {
            get
            {
                return posicao;
            }

            set
            {
                posicao = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string Responsavel
        {
            get
            {
                return responsavel;
            }

            set
            {
                responsavel = value;
            }
        }

        public bool Plus
        {
            get
            {
                return plus;
            }
            set
            {
                plus = value;
            }
        }

        public string ImagemUrl
        {
            get
            {
                return imagemUrl;
            }

            set
            {
                imagemUrl = value;
            }
        }

        public bool HasImagem()
        {
            return !imagemUrl.Equals(string.Empty);
        }

        public bool Equals(Estabelecimento other)
        {
            return Codigo == other.Codigo;
        }
    }
}