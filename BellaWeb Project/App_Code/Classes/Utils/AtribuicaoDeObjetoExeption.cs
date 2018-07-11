using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Bellaweb.App_Code.Classes
{
    [Serializable]
    public class AtribuicaoDeObjetoExeption : Exception
    {
        public AtribuicaoDeObjetoExeption(string message) : base(message) { }
        public AtribuicaoDeObjetoExeption(string message, Exception inner) : base(message, inner) { }
        protected AtribuicaoDeObjetoExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

    }
}