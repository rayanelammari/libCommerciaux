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
    public class Nuite : NoteFrais
    {
        private string categorie;
        private double facture;
        private int region;


        public Nuite (DateTime dateNoteFrais, Commercial leCommercial, double facture,int region)
        :base(dateNoteFrais, leCommercial)    
        {
            this.categorie = leCommercial.CatProfessionnelle;
            this.facture = facture;
            this.region= region;
        }

        public override double calculMontantARembourser()
        {
            double montantARembourser;
            double coef;
            if(this.region ==1)
            {
                coef = 0.9;
            }
            else if(this.region==2) 
            { 
                coef = 1; 
            }
            else
            {
                coef = 1.15;
            }
            if (this.facture < 50)
            {
                montantARembourser = this.facture;
            }
            else
            {
                if(this.categorie=="A")
                {
                    montantARembourser = coef * 65;
                }
                else if(this.categorie== "B") 
                {

                    montantARembourser = coef * 55;
                }
                else
                {
                    montantARembourser = coef * 50;
                }
            }
            return montantARembourser;

        }



        public override string ToString()
        {
            return $"{base.ToString()}, Facture : {facture}";
        }
    }
}
