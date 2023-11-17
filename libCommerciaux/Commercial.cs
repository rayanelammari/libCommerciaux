using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace libCommerciaux
{
    [System.Serializable]
    public class Commercial
    {
        private string nom;
        private string prenom;
        private string catProfessionnelle;
        private int puissanceVoiture;
        private List<NoteFrais> lesNoteFrais;

    

        public Commercial(string nom, string prenom,string catProfessionnelle,int puissanceVotiure) 
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.CatProfessionnelle= catProfessionnelle;
            this.PuissanceVoiture= puissanceVotiure;
            this.lesNoteFrais= new List<NoteFrais>();

        }

        

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string CatProfessionnelle { get => catProfessionnelle; set => catProfessionnelle = value; }
        public int PuissanceVoiture { get => puissanceVoiture; set => puissanceVoiture = value; }
        public List<NoteFrais> LesNoteFrais { get => lesNoteFrais; set => lesNoteFrais = value; }

        public void ajouterFrais(NoteFrais f)
        {
            this.LesNoteFrais.Add(f);
        }

        public void ajouterNote(FraisTransport ft)
        {
            this.LesNoteFrais.Add(ft);
        }
        public void ajouterNote(RepasMidi rp)
        {
            this.LesNoteFrais.Add(rp);

        }
        public void ajouterNote(Nuite n )
        {
            this.LesNoteFrais.Add(n);

        }


        public List<NoteFrais> getMesNoteFrais()
        {
            return LesNoteFrais;
        }

        public List<NoteFrais> GetLesNoteFrais()
        {
            return LesNoteFrais;
        }

        public double cumulNoteFraisRembourser(int annee)
        {
            double cumul=0;
            foreach(NoteFrais n in LesNoteFrais)
            {
                 if(n.DateFrais.Year==annee)
                {
                    cumul += n.MontantARembourser;
                }

            }
            return cumul;
        }

        public override string ToString()
        {
            return $"Nom : {this.Nom}, prenom : {this.Prenom}, Catégorie profesionnel : {this.CatProfessionnelle}, puissance voiture : {this.PuissanceVoiture}";
        }
    }
}