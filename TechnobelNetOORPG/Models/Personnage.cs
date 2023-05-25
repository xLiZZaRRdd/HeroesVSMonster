using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnobelNetOORPG.Interfaces;

namespace TechnobelNetOORPG.Models
{
    public class Personnage
    {
        protected Personnage(string name, int hP, int attack)
        {
            MaxHp = hP;
            Name = name;
            _hp = hP;
            Attack = attack;
            
        }

        public string Name { get; set; }

        private int MaxHp { get; }

        private int _hp;
        public int HP { 
            get 
            {
                return _hp;
            } 
            set
            {
                int newHP = value;

                if(this is ITank && value < _hp)
                {
                    ITank perso = (ITank)this;
                    newHP = (int)((double)value / (1 + perso.ResistanceBuff));
                    Console.WriteLine($"Le tank absorbe {(int)(perso.ResistanceBuff * 100)} % Des dommages");
                }

                if (newHP <= 0)
                {
                    Console.WriteLine($"Oh bah {Name} est mort...");
                    _hp = 0;
                }
                else if(newHP > MaxHp){
                    Console.WriteLine($"La vie de {Name} est restauré au maximum");
                    _hp = MaxHp;
                }
                else
                {
                    _hp = newHP;
                }

                
            }
        }

        public int Attack { get; set; }

        public override string ToString()
        {
            return $"Nom : {Name} - Heal : {HP}";
        }
    }
}
