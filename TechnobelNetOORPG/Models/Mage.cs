using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnobelNetOORPG.Interfaces;

namespace TechnobelNetOORPG.Models
{
    public class Mage : Personnage, IHeal, IRange
    {
        public Mage(string name, int hP, int attack) : base(name, hP, attack)
        {
        }

        public void heal(Personnage? allie = null)
        {
            if (allie is null)
            {
                Console.WriteLine($"{Name} se restaure 5% De vie.");
                HP = (int)((double)HP * 1.05);
            }
            else
            {
                Console.WriteLine($"{Name} restaure à {allie.Name} 5% De vie.");
                allie.HP = (int)((double)allie.HP * 1.05);
            }
        }

        public void RangeAttack(Personnage ennemy)
        {
            Random rdn = new Random();
            if (rdn.Next(1, 21) == 1)
            {
                Console.WriteLine($"{Name} à loupé son attaque a distance.");
            }
            else
            {
                ennemy.HP -= Attack;
                Console.WriteLine($"{Name} lance une attaque a distance sur {ennemy.Name}"
                + $" lui infligeant {Attack} points de degat et le laissant à {ennemy.HP} points de vie.");
            }



        }
    }
}
