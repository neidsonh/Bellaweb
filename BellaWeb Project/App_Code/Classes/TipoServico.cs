using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class TipoServico : IEquatable<TipoServico>
    {
        private long codigo;
        private string descricao;
        private TipoServico tipoPai;

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

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        public TipoServico TipoPai
        {
            get
            {
                return tipoPai;
            }

            set
            {
                tipoPai = value;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TipoServico);
        }

        public bool Equals(TipoServico other)
        {
            return this.Codigo == other.Codigo;
        }

        public override int GetHashCode()
        {
            return unchecked((int)codigo) ^ ((int)(codigo >> 32));
        }

        public bool isSubtipo()
        {
            return (tipoPai != null);
        }
    }
}