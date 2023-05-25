using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters_RenaudYeansenne
{
    public class Dice               // Création de la classe "Dé"
    {
        private Random rnd;         // Créer la classe Random sous "rnd" pour pouvoir l'utiliser

        public Dice()
        {
            rnd = new Random();     // Construire l'objet Dé sous base d'un Random
        }


        // Créer une méthode pour lancer un dé et qui nous donnera un résultat entre 1 et 4
        public int Lanced4() => rnd.Next(1, 5);

        // Créer une méthode pour lancer un dé et qui nous donnera un résultat entre 1 et 6
        public int Lanced6() => rnd.Next(1, 7);
        // Créer une méthode pour lancer 4 dés 6 faces et nous donner la somme des 3 meilleurs
        public int Lance4d6_Recup3()
        {
            // Faire une liste contenant le jet de 4 dés
            List<int> résultats = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                int résultat = Lanced6();
                résultats.Add(résultat);
            }

            // Trier les résultats dans l'ordre décroissant
            résultats.Sort();
            résultats.Reverse();

            // Calculer la somme des 3 meilleurs dés
            int sommeMeilleurs = résultats[0] + résultats[1] + résultats[2];

            return sommeMeilleurs;
        }
    }
}
