using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters_RenaudYeansenne.Loot
{
    public class Loot
    {
        public int nbOr;
        public int nbCuir;

        public void lootCuir()
        {
            nbCuir+=4;
        }

        public void lootOr()
        {
            nbOr+=2;
        }
    }
}
