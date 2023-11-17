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
    public class NoteFrais
    {
        private int numeroNote;
        private DateTime dateFrais;
        private bool estRembourser;
        private double montantARembourser;
        private Commercial leCommercial;

        public NoteFrais() { }
        public NoteFrais(DateTime date,Commercial leCommercial)
        {   
            this.dateFrais = date;
            this.leCommercial= leCommercial;
            this.numeroNote=leCommercial.getMesNoteFrais().Count();
            this.leCommercial.ajouterFrais(this);
        }

        

        public DateTime DateFrais
        {
            get { return dateFrais; } 
            set { dateFrais = value; }
        }

        public double MontantARembourser
        {
            get { return montantARembourser; }
            set { montantARembourser = value; }
        }
        public Commercial getLeCommercial
        {
            get { return leCommercial; }
            set { leCommercial = value; }
        }

        public void setRembourse()
        {  
             estRembourser = true;
        }

        public bool getEstRembourser()
        {
            return estRembourser;
        }

        public double setMontantARembourser()
        {
           return  this.montantARembourser = calculMontantARembourser();

        }

        public virtual  double calculMontantARembourser()
        {
            return 0;
        }

      

        public override string ToString()
        {   
            if(getEstRembourser()==true)
            {
                Console.WriteLine("Remboursé ");

            }
            else
            {
                Console.WriteLine("Non Remboursé ");

            }
            this.montantARembourser = calculMontantARembourser();
            return $"Numéro : {this.numeroNote}, Date : {this.dateFrais}, montant à rembourser : {this.montantARembourser} euros, {estRembourser}";
        }

      
    }

   


}
