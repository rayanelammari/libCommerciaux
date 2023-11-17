// See https://aka.ms/new-console-template for more information
using libCommerciaux;
using System.Net.NetworkInformation;

Console.WriteLine("---------------Commercial-----------------------");
Commercial commercial = new Commercial("Jean", "Dupond", "A",25);
Console.WriteLine(commercial.ToString());
NoteFrais f0 = new NoteFrais(new DateTime(2022, 11, 12), commercial);
Console.WriteLine(f0.ToString());
Console.WriteLine("-----------------Service Commercial---------------------");
ServiceCommercial sc = new ServiceCommercial();
Console.WriteLine(sc.nbFraisNonRembourses());
Commercial c1 = new Commercial("Dupond", "Jean","B",7);
sc.ajouterCommercial(c1);
sc.ajouterNote(c1, new DateTime(2013, 11, 15), 100);      // ajoute un frais de transport 
sc.ajouterNote(c1, new DateTime(2013, 11, 21), 15.5);     // ajoute une note de repas 
sc.ajouterNote(c1, new DateTime(2013, 11, 25), 105, 2);  // ajoute une nuité 
Console.WriteLine($"il y a {sc.nbFraisNonRembourses()} frais non remboursés");
Console.WriteLine("-----------------Sauve/Charge---------------------");

PersisteCommercial.Sauve(sc);
PersisteCommercial.Charge(sc);

//Console.WriteLine("--------------------------------------");
//FraisTransport ft = new FraisTransport(new DateTime(2022, 11, 12), commercial,250);
//Console.WriteLine(ft.ToString());
//Console.WriteLine("------------------Montant à Rembourser NoteFrais--------------------");
//Console.WriteLine(c1.cumulNoteFraisRembourser(2022));


