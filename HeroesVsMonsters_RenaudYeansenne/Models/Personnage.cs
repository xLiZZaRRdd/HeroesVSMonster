using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters_RenaudYeansenne.Models
{
    public class Personnage
    {
        public int Endurance { get; set; }
        public int Force { get; set; }
        public int BaseEndurance { get; set; }
        public int BaseForce { get; set; }
        public int HpActuel;
        public int MaxHp;

        //private bool EstMort()
        //{
        //    return HpActuel <= 0;
        //}


        public void Frappe(Personnage cible)
        {
            //if (EstMort())
            //{
            //    Console.WriteLine("Il est mort, impossible d'attaquer.");
            //    return;
            //}

            Dice dice = new Dice();

            int Degats;

            switch (Force)
            {
                case < 5:
                    Degats = dice.Lanced4();
                    Console.WriteLine("Résulat du jet de dé : " + (Degats));
                    Console.WriteLine("Et après bonus donne : " + (Degats - 1));
                    cible.SubirDegats(Degats - 1);
                    break;

                case < 10:
                    Degats = dice.Lanced4();
                    Console.WriteLine("Résulat du jet de dé : " + (Degats));
                    Console.WriteLine("Et après bonus donne : " + (Degats + 0));
                    cible.SubirDegats(Degats + 0);
                    break;

                case < 15:
                    Degats = dice.Lanced4();
                    Console.WriteLine("Résulat du jet de dé : " + (Degats));
                    Console.WriteLine("Et après bonus donne : " + (Degats + 1));
                    cible.SubirDegats(Degats + 1);
                    break;

                default:
                    Degats = dice.Lanced4() + 2;
                    Console.WriteLine("Résulat du jet de dé : " + (Degats + 2));
                    Console.WriteLine("Et après bonus donne : " + (Degats));
                    cible.SubirDegats(Degats);
                    break;
            }
        }

        void SubirDegats(int Degats)
        {
            HpActuel -= Degats;
            if (HpActuel < 0)
            {
                HpActuel = 0;
            }
        }
    }
}
