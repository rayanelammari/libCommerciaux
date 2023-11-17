using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace libCommerciaux
{
    [System.Serializable]
    public class RepasMidi : NoteFrais
    {
        private double factureRepas;
        private string cate;
        public RepasMidi(DateTime dateNoteFrais,Commercial leCommercial, double factureRepas)
            :base(dateNoteFrais, leCommercial)
        {
            this.factureRepas = factureRepas;
            this.cate = leCommercial.CatProfessionnelle;
        }

        public override double calculMontantARembourser()
        {
            double montantRembourser;
            if (cate == "A" && factureRepas >= 25)
            {
                montantRembourser = 25;
            }
            else if (cate == "B" && factureRepas >= 22)
            {
                montantRembourser = 22;
            }
            else if (cate == "C" && factureRepas >= 20)
            {
                montantRembourser = 20;
            }
            else
            {
                montantRembourser = factureRepas;
            }
            return montantRembourser;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Facture : {factureRepas}";
        }

    }
}
