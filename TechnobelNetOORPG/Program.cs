
using TechnobelNetOORPG.Interfaces;
using TechnobelNetOORPG.Models;

Warrior Thanos = new Warrior("Tanos", 2000, 450);

Thanos.Resist();
Thanos.Resist();
Thanos.Resist();

List<Personnage> personnages = new List<Personnage>{
    new Mage("gandoulf", 120, 12),

    new Mage("saroumane", 130, 10),

    new Hunter("sabrina", 20, 4),

    new Warrior("IronMan", 50, 12)

};

foreach (var personnage in personnages)
{
    if (personnage is IRange)
    {
        IRange rangePerso = (IRange)personnage;
        rangePerso.RangeAttack(Thanos);
        Console.WriteLine(Thanos);
    }
}

foreach (var personnage in personnages)
{
    if (personnage is IHeal)
    {
        IHeal healPerso = (IHeal)personnage;
        healPerso.heal(Thanos);
        Console.WriteLine(Thanos);
    }
}