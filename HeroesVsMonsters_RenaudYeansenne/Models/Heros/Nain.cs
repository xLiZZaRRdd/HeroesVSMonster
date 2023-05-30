using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters_RenaudYeansenne.Models.Heros
{
    internal class Nain : Personnage
    {
        Dice dice = new Dice();                         // Créer un autre joli dé
        public Nain(string name) : base(name)           // Attribuer les caractéristiques du Nain
        {
            BaseEndurance = dice.Lance4d6_Recup3();
            BaseForce = dice.Lance4d6_Recup3();

            Endurance = BaseEndurance + 2;              // Respecte la contrainte 3 et donne +2 car Nain
            Force = BaseForce;

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
