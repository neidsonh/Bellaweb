using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Servico
    {
        private long codigo;
        private string nome;
        private double preco;
        private TipoServico tipoServico;
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

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public double Preco
        {
            get
            {
                return preco;
            }

            set
            {
                preco = value;
            }
        }

        public TipoServico TipoServico
        {
            get
            {
                return tipoServico;
            }

            set
            {
                if (!value.isSubtipo())
                    throw new AtribuicaoDeObjetoExeption("TipoServico deve ser um Subtipo");
                tipoServico = value;
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