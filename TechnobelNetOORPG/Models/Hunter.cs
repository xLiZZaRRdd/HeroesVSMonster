using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnobelNetOORPG.Interfaces;

namespace TechnobelNetOORPG.Models
{
    public class Hunter : Personnage, IRange, IMelee
    {
        public Hunter(string name, int hP, int attack) : base(name, hP, attack)
        {
        }

        public void MeleeAttack(Personnage ennemy)
        {
            ennemy.HP -= Attack;
            Console.WriteLine($"{Name} lance une attaque au corps a corps sur {ennemy.Name}"
                + $" lui infligeant {Attack} points de degat et le laissant à {ennemy.HP} points de vie.");
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
