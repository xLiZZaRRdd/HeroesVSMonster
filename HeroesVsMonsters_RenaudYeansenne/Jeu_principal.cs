using HeroesVsMonsters_RenaudYeansenne;
using HeroesVsMonsters_RenaudYeansenne.Loot;
using HeroesVsMonsters_RenaudYeansenne.Models;
using HeroesVsMonsters_RenaudYeansenne.Models.Heros;
using HeroesVsMonsters_RenaudYeansenne.Models.Monstres;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

bool play = HeroesVsMonster();
bool game = true;

while (game)
{
    while (play)
    {
        play = HeroesVsMonster();
    }
}
    



bool HeroesVsMonster()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Bienvenue dans la forêt enchantée de Shorewood, du pays de Stormwall.");
    Console.WriteLine("Dans cette forêt se livre un combat acharné entre les héros et les monstres.");


    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Prêt pour l'aventure ? (y / n)");
    Console.ResetColor();
    string userPlay;
    userPlay = Console.ReadLine();

    while ((userPlay != "y") && (userPlay != "n"))
    {
        Console.WriteLine("Mauvaise entrée, réponds donc par 'y' ou par 'n'");
        userPlay = Console.ReadLine();
    }

    if (userPlay == "y")
    {
        DebutJeu();
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Tant pis, merci quand même ! ♥");
        Console.ResetColor();
        return false;
    }

    return true;
}

void DebutJeu()
{
    Dice Dice = new Dice();

    List<Personnage> Hero = CreerHeros();
    List<Personnage> Monstres = new List<Personnage>();

    CreerMonstres(Monstres);

    Console.WriteLine($"Bienvenue à toi, {Hero[0]}.");
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine($"Dans ce monde, tu possèdes {Hero[0].Force} de Force et {Hero[0].MaxHp} PDV");
    //System.Threading.Thread.Sleep(3000);
    //Console.WriteLine("Et étant donné que tu es cupide ET débile, tu vas te battre jusqu'à en mourir.");
    //System.Threading.Thread.Sleep(4000);
    //Console.WriteLine("Voyons voir ce que tu peux ramasser cette run !");
    //System.Threading.Thread.Sleep(3000);

    Bagarre(Monstres);

    bool letsgo = LancementCombat();
    while (letsgo == true)
    {
        CreerMonstres(Monstres);
        Bagarre(Monstres);
        letsgo = LancementCombat(ref play);
    }

    void Bagarre(List<Personnage> Monstres)
    {
        Console.Clear();
        Console.WriteLine($"{Hero[0]}   VS  {Monstres[0]}");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("...");
        System.Threading.Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("FIGHT !!!!!");
        Console.ResetColor();
        System.Threading.Thread.Sleep(2000);
        Console.Clear();
    }
    bool LancementCombat(ref bool play)
    {
        while ((!Hero[0].IsDead) && (!Monstres[0].IsDead))
        {
            if (!Hero[0].IsDead)
            {
                Hero[0].Frappe(Monstres[0]);
                if (Monstres[0].IsDead)
                {
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Félicitations {Hero[0]} ! Tu as vaincu ce monstre : {Monstres[0]} ");

                    Monstres.Remove(Monstres[0]);
                    CreerMonstres(Monstres);

                    Bagarre(Monstres);
                    LancementCombat();

                    Console.ResetColor();
                    return true;
                }
            }
            if (!Monstres[0].IsDead)
            {
                Monstres[0].Frappe(Hero[0]);
                if (Hero[0].IsDead)
                {
                    Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Désolé {Hero[0]} ! Tu as été tué par ce monstre : {Monstres[0]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Une autre partie ? :D (Réponds par 'y' ou par 'n')");
                    Console.ResetColor();
                    string userRep;
                    userRep = Console.ReadLine();

                    if (userRep == "y")
                    {
                        return true;
                    }

                    if (userRep == "n")
                    {
                        play = false;
                        return false;
                    }
                }
            }
        }
        return true;
    }

    List<Personnage> CreerHeros()
{
    List<Personnage> Heros = new List<Personnage>();

    Console.Clear();
    Console.WriteLine("Quel héros choisiras-tu ? Humain (h) ou Nain (n) ?");
    string userRace = Console.ReadLine();

    while ((userRace != "h") && (userRace != "n"))
    {
        Console.WriteLine("Mauvaise entrée, réponds donc par 'h' ou par 'n'");
        userRace = Console.ReadLine();
    }

    Console.Clear();
    Console.WriteLine("Écris moi le nom de ton héros !");
    string userNom = Console.ReadLine();

    if (userRace == "h")
    {
        Heros.Add(new Humain($"{userNom}"));
    }

    if (userRace == "n")
    {
        Heros.Add(new Nain($"{userNom}"));
    }
        Console.Clear();
        return Heros;
}
   void CreerMonstres(List<Personnage> Monstres)
{

    Random rnd = new Random();
    int randomNumber = rnd.Next(1, 4);


    switch (randomNumber)
    {
        case 1:
            Monstres.Add(new Dragonnet("Dragonnet"));
            break;
        case 2:
            Monstres.Add(new Loup("Loup"));
            break;
        case 3:
            Monstres.Add(new Orc("Orc"));
            break;
        default:
            break;
    }
        Console.Clear();
}


}