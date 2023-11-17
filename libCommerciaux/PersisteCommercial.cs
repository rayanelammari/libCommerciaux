using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace libCommerciaux
{
    [System.Serializable]

    public class PersisteCommercial
    {
        
        public static void Sauve(ServiceCommercial s)
        {
            FileStream file = new FileStream("serviceBin.sr", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(file, s);
            file.Close();
        }
        
        public static void Charge(ServiceCommercial s) 
        {
            // Récupération du fichier
            FileStream file = new FileStream("serviceBin.sr", FileMode.Open);
            // Création d'un formatteur
            BinaryFormatter bf = new BinaryFormatter();
            // Appel de la désérialisation
            s = (ServiceCommercial)
            bf.Deserialize(file);
            file.Close();
        }
    }
}
