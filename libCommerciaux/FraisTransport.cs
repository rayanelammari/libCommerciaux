using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace libCommerciaux
{
    [System.Serializable]
    public class FraisTransport : NoteFrais
    {
        private int km;
        private int chevaux;
        public FraisTransport(DateTime dateFrais, Commercial leCommercial, int km)
           :base(dateFrais,leCommercial)
        {
            this.km = km;
            this.chevaux = leCommercial.PuissanceVoiture;
        }

        public override double calculMontantARembourser()
        { double n;
            if(chevaux<=5)
            {
                n = 0.1 * km; 
            }
            else if(chevaux>=5 && chevaux<=10) 
            {
                n = 0.2 * km;
            }
            else
            {
                n = 0.3 * km;
            }
            return n;
        }

        public override string ToString()
        {
         
            return $"{ base.ToString()}, Kilomètre : {this.km} km";
        }
    }
}
