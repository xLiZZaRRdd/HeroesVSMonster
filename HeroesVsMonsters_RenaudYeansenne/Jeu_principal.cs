using HeroesVsMonsters_RenaudYeansenne;
using HeroesVsMonsters_RenaudYeansenne.Models;
using HeroesVsMonsters_RenaudYeansenne.Models.Heros;
using HeroesVsMonsters_RenaudYeansenne.Models.Monstres;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;


bool play = true;

// Le jeu recommence tant que l'utilisateur le décide (requête plus tard)
while (play == true)
{
    play = HeroesVsMonster();
}



bool HeroesVsMonster()
{
    if (play == false)
    {
        return false;
    }

    // Présentation et Lore
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
        if (DebutJeu() == false)
        {
            return false;
        }
        // Si la réponse est positive par rapport à la demande de jeu, début de la méthode DebutJeu() plus bas
        DebutJeu();
    }
    else
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Tant pis, merci quand même ! ♥");
        Console.ResetColor();
        return false;
    }

    return true;
}

bool DebutJeu()
{
    // Créer un Dé
    Dice Dice = new Dice();

    // Créer une liste de Héros et une liste de Monstres (pour l'instant c'est du 1-1)
    List<Personnage> Hero = CreerHeros();
    List<Personnage> Monstres = new List<Personnage>();

    CreerMonstres(Monstres);

    // Petit Lore et afficher caractéristiques du Héro
    Console.WriteLine($"Bienvenue à toi, {Hero[0]}.");
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine($"Dans ce monde, tu possèdes {Hero[0].Force} de Force et {Hero[0].MaxHp} PDV");
    System.Threading.Thread.Sleep(3000);
    Console.WriteLine("Et étant donné que tu es cupide ET débile, tu vas te battre jusqu'à en mourir.");
    System.Threading.Thread.Sleep(4000);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Voyons voir ce que tu peux ramasser cette run !");
    Console.ResetColor();
    System.Threading.Thread.Sleep(3000);

    // La méthode bagarre plus bas affiche juste du CW
    Bagarre(Monstres);

    // Voir si le combat est possible en fonction de la vie du héros
    bool CombatPossible = LancementCombat();
    while ((CombatPossible == true) && (!Hero[0].IsDead))
    {
        CreerMonstres(Monstres);
        Bagarre(Monstres);
        CombatPossible = LancementCombat();
    }

    if (CombatPossible == false)
    {
        return false;
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

    bool LancementCombat()
    {
        // Tant que l'un des deux n'est pas mort, ils se tappent
        while ((!Hero[0].IsDead) && (!Monstres[0].IsDead))
        {
            // Si le héros n'est pas mort :
            if (!Hero[0].IsDead)
            {
                // Le héros frappe le monstre
                Hero[0].Frappe(Monstres[0]);
                // Si le monstre est mort :
                if (Monstres[0].IsDead)
                {
                    // Félicitations + loot
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine($"Félicitations {Hero[0]} ! Tu as vaincu ce monstre : {Monstres[0]} ");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Tu loot ce montre et récupère {Monstres[0].nbCuir} Cuir et {Monstres[0].nbOr} d'Or !");
                    Console.ResetColor();
                    Hero[0].nbCuir = Hero[0].nbCuir + Monstres[0].nbCuir;
                    Hero[0].nbOr = Hero[0].nbOr + Monstres[0].nbOr;

                    // Récupérer de la vie et prochain combat
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine($"Tu te reposes et reprends des forces, tu récupères {(Hero[0].MaxHp - Hero[0].HpActuel) - 1} PDV !");
                    System.Threading.Thread.Sleep(2000);
                    
                    // Retirer 1 pv Max après chaque combat pour éviter que ça dure 5 plombes
                    Hero[0].MaxHp = Hero[0].MaxHp - 1;
                    Hero[0].HpActuel = Hero[0].MaxHp;
                    Console.WriteLine($"Ce combat t'a épuisé et tu perds 1 PDV définitivement, il te reste {Hero[0].MaxHp} PDV Max");

                    System.Threading.Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Le prochain combat débutera dans ...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("3...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("2...");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("1...");
                    System.Threading.Thread.Sleep(1000);
                    Console.ResetColor();


                    // Retirer le monstre mort de la liste de Monstres et en créer un nouveau
                    Monstres.Remove(Monstres[0]);
                    CreerMonstres(Monstres);

                    Bagarre(Monstres);

                    // Recommencer un combat jusqu'à arriver dans la partie où le héro meurt
                    LancementCombat();
                }
            }
            // Si le héro n'est pas mort et qu'il a plus de 0 PDV :
            if ((!Monstres[0].IsDead) && (Hero[0].HpActuel > 0 ))
            {
                // Le monstre frappe le héro
                Monstres[0].Frappe(Hero[0]);

                // Si le héro est mort :
                if (Hero[0].IsDead)
                {
                    // Oh mince tu es mort + loot final
                    System.Threading.Thread.Sleep(3000);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Désolé {Hero[0]} ! Tu as été tué par ce monstre : {Monstres[0]} ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine($"Tu as récupéré au total : {Hero[0].nbCuir} Cuir et {Hero[0].nbOr} d'Or ! ");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine($"Score final : {(Hero[0].nbCuir * 10) + (Hero[0].nbOr * 20)}");
                    Console.ForegroundColor = ConsoleColor.Magenta;

                    // Rejouabilité
                    Console.WriteLine("Une autre partie ? :D (Réponds par 'y' ou par 'n')");
                    Console.ResetColor();
                    string userRep;
                    userRep = Console.ReadLine();
                
                    while (userRep != "y" && userRep != "n")
                    {
                        Console.WriteLine("Mauvaise entrée, réponds seulement par 'y' ou par 'n'");
                        userRep = Console.ReadLine();
                    }
                    if (userRep == "y")
                    {
                        // Si oui, on rappelle la toute première méthode qui est le jeu, simplement
                        Console.Clear();
                        HeroesVsMonster();
                    }

                    else
                    {
                        // Si non, on tue le monstre pour sortir des conditions et arrêter le jeu
                        Monstres[0].HpActuel = 0;
                        Console.Clear();
                        return false;
                    }
                }
            }
        }
        return true;
    }

    // La méthode CrerHeros permet de créer un Héro en fonction de la classe choisir par l'utilisateur ainsi que son nom
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

    // La méthode CreerMonstres permet d'ajouter un monstre à la liste des monstres, avec un random pour voir quel monstre on ajoute
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

    return false;
}