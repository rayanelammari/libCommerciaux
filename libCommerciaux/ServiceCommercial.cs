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

    public class ServiceCommercial
    {
        private List<Commercial> lstCommercials;
        
        public ServiceCommercial()
        {
            this.lstCommercials = new List<Commercial>();
        }


        public void ajouterCommercial(Commercial unCommercial)
        {
           lstCommercials.Add(unCommercial);
        }


        public void ajouterNote(Commercial leCommercial, DateTime dateFrais,int km)
        {   
            FraisTransport fraisTransport = new FraisTransport(dateFrais,leCommercial,km);
        }

        public void ajouterNote(Commercial leCommercial, DateTime dateFrais, double factureRepas)
        {
            RepasMidi repasMidi = new RepasMidi(dateFrais, leCommercial, factureRepas);
        }

        public void ajouterNote(Commercial leCommercial, DateTime dateFrais, double facture,int region)
        {
            Nuite nuit = new Nuite(dateFrais, leCommercial, facture,region);
        }


        public int nbFraisNonRembourses()
        { 
            int nb=0;
            foreach(Commercial commercial in  this.lstCommercials)
            {   
                foreach(NoteFrais note in commercial.getMesNoteFrais())
                {
                    if (note.getEstRembourser() == false)
                    {
                        nb++;
                    }
                }
              
            }

            return nb;
        }
    
}

 
}
