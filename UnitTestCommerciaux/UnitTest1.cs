using libCommerciaux;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace UnitTestCommerciaux
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestajouterNoteFrais()
        {
            //Arranger:
            Commercial c = new Commercial("Jean", "Dupond", "A", 25);
            c.LesNoteFrais = new List<NoteFrais>();
            NoteFrais f0, f1;

            //Agir:
             f0 = new NoteFrais(new DateTime(2022, 11, 12), c);
             f1 = new NoteFrais(new DateTime(2022, 11, 15), c);
           


            //Auditer:
            Assert.AreEqual(2, c.getMesNoteFrais().Count);

        }
        [TestMethod]

        public void nbFraisNonRemboursesTest()
        {   
            //Arranger
            ServiceCommercial sc = new ServiceCommercial();
            NoteFrais f0, f1, f2, f3, f4;
            Commercial c0 = new Commercial("Dupont","Jean","A",8);
            Commercial c1 = new Commercial("Duval", "Rene", "A", 6);

            sc.ajouterCommercial(c0);
            sc.ajouterCommercial(c1);

             f0 = new NoteFrais(new DateTime(2022, 11, 12), c0);
             f1 = new NoteFrais(new DateTime(2022, 11, 15), c0);
             f2 = new NoteFrais(new DateTime(2022, 11, 18), c1);
             f3 = new NoteFrais(new DateTime(2022, 11, 21), c1);
             f4 = new NoteFrais(new DateTime(2022, 11, 25), c1);
     

            //Agir
            f1.setRembourse();
            f3.setRembourse();
            f4.setRembourse();

            //Auditer 

            Assert.AreEqual(2, sc.nbFraisNonRembourses());
            


        }

        [TestMethod]
        public void calculMontantARembourserTest()
        {
            //Arranger
            Commercial c;
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A",8);
            //Agir
             f0 = new FraisTransport(new DateTime(2022, 11, 12), c,250);
            //Auditer
            Assert.AreEqual(50, f0.calculMontantARembourser());
        }

        [TestMethod]
        public void TestToString()
        {
            Commercial c;
            c = new Commercial("Jean", "Dupond","A",8);
            NoteFrais T0;
            T0 = new FraisTransport(new DateTime(2013, 11, 12), c, 250);
            Console.WriteLine(T0.ToString());
        }

        [TestMethod]
        public void calculMontantARembourserTestRepasMidi1()
        {
            //Arranger
            Commercial c;
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
             f0 = new RepasMidi(new DateTime(2022, 11, 12), c,35);
            //Auditer
            Assert.AreEqual(25, f0.calculMontantARembourser());
        }


        [TestMethod]
        public void calculMontantARembourserTestRepasMidi2()
        {
            //Arranger
            Commercial c;
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            f0 = new RepasMidi(new DateTime(2022, 11, 12), c, 15);
            //Auditer
            Assert.AreEqual(15, f0.calculMontantARembourser());
        }


        [TestMethod]
        public void calculMontantARembourserNuite1Test()
        {
            //Arranger
            Commercial c;
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            f0 = new Nuite(new DateTime(2022, 11, 12), c, 46,1);
            //Auditer
            Assert.AreEqual(46, f0.calculMontantARembourser());
        }

        [TestMethod]
        public void calculMontantARembourserNuite2Test()
        {
            //Arranger
            Commercial c;
            NoteFrais f0;
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            f0 = new Nuite(new DateTime(2022, 11, 12), c, 80, 3);
            //Auditer
            Assert.AreEqual(74.75, f0.calculMontantARembourser());
        }

        [TestMethod]
        public void nbFraisNonRemboursesSCTest()
        {
            //Arranger
            Commercial c;
            ServiceCommercial sc = new ServiceCommercial();
            c = new Commercial("Jean", "Dupond", "A", 8);
            //Agir
            sc.ajouterCommercial(c);
            sc.ajouterNote(c, new DateTime(2013, 11, 15), 100);      // ajoute un frais de transport 
            sc.ajouterNote(c, new DateTime(2013, 11, 21), 15.5);     // ajoute une note de repas 
            //Auditer
            Assert.AreEqual(2, sc.nbFraisNonRembourses());

        }

        //[TestMethod]
        //public void serializationCommerciauxTest()
        //{
        //    Commercial c1 = new Commercial("Jean", "Dupond", "A", 8);

        //    // Act
        //    PersisteCommercial.Sauve(c1);

        //    Commercial dc1 = new Commercial("Jean", "Dupond", "A", 8);
        //    PersisteCommercial.Charge(dc1);

        //    // Assert
        //    Assert.AreEqual("Jean", dc1.Nom);
        //}






    }
}