using Bellaweb.App_Code.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes.Utils
{
    public class TipoServicoComparer : IEqualityComparer<TipoServico>
    {
        public bool Equals(TipoServico x, TipoServico y)
        {
            return x.Codigo == y.Codigo;
        }

        public int GetHashCode(TipoServico obj)
        {
            return Convert.ToInt32(obj.Codigo);
        }
    }
}