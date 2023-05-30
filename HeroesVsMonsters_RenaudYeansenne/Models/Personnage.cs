using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters_RenaudYeansenne.Models
{
    public class Personnage
    {

        // Récupérer le nom du personnage (Héros notamment)
        public Personnage(string name)
        {
            Name = name;
        }

        // Créer les caractéristiques partagées entre tout les personnages
        public string Name { get; set; }
        public int Endurance { get; set; }
        public int Force { get; set; }
        public int BaseEndurance { get; set; }
        public int BaseForce { get; set; }
        public int HpActuel;
        public int MaxHp;
        public int nbCuir;
        public int nbOr;
        public bool IsDead { get
            {
                return HpActuel <= 0;
            }
        }

      
        // Méthode de Frappe
        public void Frappe(Personnage cible)
        {
            Dice dice = new();

            int Degats;
            Degats = 0;

            // Ajouter des dégâts en fonction de la force
            switch (Force)
            {
                case < 5:
                    Degats = dice.Lanced4();
                    cible.SubirDegats(Degats - 1, this);
                    break;

                case < 10:
                    Degats = dice.Lanced4();
                    cible.SubirDegats(Degats + 0, this);
                    break;

                case < 15:
                    Degats = dice.Lanced4();
                    cible.SubirDegats(Degats + 1, this);
                    break;

                default:
                    Degats = dice.Lanced4();
                    cible.SubirDegats(Degats + 2, this);
                    break;
            }
        }

        // Méthode SubirDegats pour pouvoir retirer de la vie en fonction des dégâts calculés précédemment
        void SubirDegats(int Degats, Personnage attaquant)
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine($"{attaquant.Name} frappe !");
            System.Threading.Thread.Sleep(500);
            HpActuel -= Degats;

            if (HpActuel > 0)
            {
                Console.WriteLine($"Vie actuelle de {Name} : " + HpActuel + "/" + MaxHp);
                System.Threading.Thread.Sleep(500);
            }
            
            if (HpActuel <= 0)
            {
                HpActuel = 0;
                Console.WriteLine($"{Name} est mort(e).");
            }
            Console.WriteLine("----------------------------");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
