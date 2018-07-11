using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Destaque
    {
        private long codigo;
        private string titulo;
        private string url;
        private string imgUrl;
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

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string ImgUrl
        {
            get
            {
                return imgUrl;
            }

            set
            {
                imgUrl = value;
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
                administrador = value;
            }
        }
    }
}