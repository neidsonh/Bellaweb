using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bellaweb.App_Code.Classes
{
    public class Posicao
    {
        private double latitude;
        private double longitude;

        public Posicao()
        {

        }

        public Posicao(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }
    }
}