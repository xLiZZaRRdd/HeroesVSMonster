using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnobelNetOORPG.Interfaces;

namespace TechnobelNetOORPG.Models
{
    public class Warrior : Personnage, IMelee, ITank
    {
        public Warrior(string name, int hP, int attack) : base(name, hP, attack)
        {
        }

        public double ResistanceBuff { get ; set ; }

        public void MeleeAttack(Personnage ennemy)
        {
            
            ennemy.HP -= Attack;
            Console.WriteLine($"{Name} lance une attaque au corps a corps sur {ennemy.Name}"
                + $" lui infligeant {Attack} points de degat et le laissant à {ennemy.HP} points de vie.");
        }

        public void Resist()
        {
            ResistanceBuff += 0.05;
        }
    }
}
