﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Estado
    {
        private long codigo;
        private string nome;
        private string uf;

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

        public string Uf
        {
            get
            {
                return uf;
            }

            set
            {
                uf = value;
            }
        }

    }
}