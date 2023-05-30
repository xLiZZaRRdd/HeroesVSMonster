using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters_RenaudYeansenne.Models.Heros
{
    internal class Humain : Personnage                  // Créer la classe Humain qui hérite de Personnage
    {
        Dice dice = new Dice();                         // Créer un joli dé

        public Humain(string name) : base(name)         // Attribuer les caractéristiques de l'Humain
        {
            BaseEndurance = dice.Lance4d6_Recup3();
            BaseForce = dice.Lance4d6_Recup3();

            Endurance = BaseEndurance + 1;              // Respecte la contrainte 3 et donne +1 car Humain
            Force = BaseForce + 1;

            nbCuir = 0;
            nbOr = 0;

            // Ajouter ou retirer de la vie en fonction de l'endurance
            switch (Endurance)
            {
                case < 5:
                    MaxHp = Endurance - 1;
                    HpActuel = MaxHp;
                break;

                case < 10:
                    MaxHp = Endurance + 0;
                    HpActuel = MaxHp;
                    break;

                case < 15:
                    MaxHp = Endurance + 1;
                    HpActuel = MaxHp;
                    break;

                default:
                    MaxHp = Endurance + 2;
                    HpActuel = MaxHp;
                    break;
            }
        }
    }
}
