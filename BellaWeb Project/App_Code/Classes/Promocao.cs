using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Promocao
    {
        private long codigo;
        private double novoPreco;
        private DateTime dataInicio;
        private DateTime dataFinal;
        private Servico servico;

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

        public double NovoPreco
        {
            get
            {
                return novoPreco;
            }

            set
            {
                novoPreco = value;
            }
        }

        public DateTime DataInicio
        {
            get
            {
                return dataInicio;
            }

            set
            {
                dataInicio = value;
            }
        }

        public DateTime DataFinal
        {
            get
            {
                return dataFinal;
            }

            set
            {
                dataFinal = value;
            }
        }

        public Servico Servico
        {
            get
            {
                return servico;
            }

            set
            {
                servico = value;
            }
        }
    }
}