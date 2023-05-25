using HeroesVsMonsters_RenaudYeansenne;
using HeroesVsMonsters_RenaudYeansenne.Models;
using HeroesVsMonsters_RenaudYeansenne.Models.Heros;
using HeroesVsMonsters_RenaudYeansenne.Models.Monstres;

//PresentationJeu();

Dice Dice = new Dice();

Console.WriteLine("Lancement d'un dé 4 random :");
Console.WriteLine(Dice.Lanced4());
//Console.WriteLine("Lancement d'un dé 6 random :");
//Console.WriteLine(Dice.Lanced6());


//Console.WriteLine("Lancement de 4D6 et récupérer la somme des 3 best :");
//Console.WriteLine(Dice.Lance4d6_Recup3());

//Humain Michel = new Humain();

//Console.WriteLine("Endurance TOTALE de Michel :");
//Console.WriteLine(Michel.Endurance);
//Console.WriteLine("Force TOTALE de Michel :");
//Console.WriteLine(Michel.Force);
//Console.WriteLine("Vie de Michel :");
//Console.WriteLine(Michel.MaxHp);

Nain Motet = new Nain();

Console.WriteLine("Endurance de Motet :");
Console.WriteLine(Motet.Endurance);
Console.WriteLine("Force de Motet :");
Console.WriteLine(Motet.Force);
Console.WriteLine("Vie de Motet :");
Console.WriteLine(Motet.MaxHp);

//Dragonnet CamilleDragonne = new Dragonnet();

//Console.WriteLine("Endurance de CamilleDragonne :");
//Console.WriteLine(CamilleDragonne.Endurance);
//Console.WriteLine("Force de CamilleDragonne :");
//Console.WriteLine(CamilleDragonne.Force);
//Console.WriteLine("Vie de CamilleDragonne :");
//Console.WriteLine(CamilleDragonne.MaxHp);

Loup LizaMaLouve = new Loup();

Console.WriteLine("Endurance de LizaMaLouve :");
Console.WriteLine(LizaMaLouve.Endurance);
Console.WriteLine("Force de LizaMaLouve :");
Console.WriteLine(LizaMaLouve.Force);
Console.WriteLine("Vie de LizaMaLouve :");
Console.WriteLine(LizaMaLouve.MaxHp);

//Orc MustDieLOL = new Orc();

//Console.WriteLine("Endurance de MustDieLOL :");
//Console.WriteLine(MustDieLOL.Endurance);
//Console.WriteLine("Force de MustDieLOL :");
//Console.WriteLine(MustDieLOL.Force);
//Console.WriteLine("Vie de MustDieLOL :");
//Console.WriteLine(MustDieLOL.MaxHp);

Motet.Frappe(LizaMaLouve);
Console.WriteLine("Motet frappe Liza !");
Console.WriteLine("Vie actuelle de Liza : " + LizaMaLouve.HpActuel + "/" + LizaMaLouve.MaxHp);
Console.WriteLine("Vie de Liza après coup  : " + LizaMaLouve.HpActuel + "/" + LizaMaLouve.MaxHp);

void PresentationJeu()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Bienvenue dans la forêt enchantée de Shorewood, du pays de Stormwall.");
    Console.WriteLine("Dans cette forêt se livre un combat acharné entre les héros et les monstres.");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Prêt pour la bagarre ?");
    Console.ResetColor();
    Console.ReadLine();

    return;
}