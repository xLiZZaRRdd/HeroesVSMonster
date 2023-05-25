using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters_RenaudYeansenne.Models.Monstres
{
    internal class Orc : Personnage
    {
        Dice dice = new Dice();                         // Créer un joli dé
        public Orc()                                    // Attribuer les caractéristiques de l'Orc
        {
            BaseEndurance = dice.Lance4d6_Recup3();
            BaseForce = dice.Lance4d6_Recup3();

            Endurance = BaseEndurance;                  // Respecte la contrainte 3 et donne force en plus car Orc
            Force = BaseForce + 1;

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
