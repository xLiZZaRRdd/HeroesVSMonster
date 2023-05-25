using System;

public class Personnage
{
    private int pointsDeVie;
    private int pointsDeVieMax;

    public Personnage(int pointsDeVieMax)
    {
        this.pointsDeVieMax = pointsDeVieMax;
        pointsDeVie = pointsDeVieMax;
    }

    public void Attaque(Personnage cible)
    {
        if (EstMort())
        {
            Console.WriteLine("Le personnage est mort. Impossible d'attaquer.");
            return;
        }

        Console.WriteLine("Le personnage attaque !");
        // Effectuer les actions d'attaque ici
        cible.SubirDegats(4);

        if (EstMort())
        {
            Console.WriteLine("Le personnage est mort !");
            pointsDeVie = 0;
        }
    }

    public void SubirDegats(int degats)
    {
        pointsDeVie -= degats;
        if (pointsDeVie < 0)
        {
            pointsDeVie = 0;
        }
    }

    public int GetPointsDeVie()
    {
        return pointsDeVie;
    }

    public int GetPointsDeVieMax()
    {
        return pointsDeVieMax;
    }

    private bool EstMort()
    {
        return pointsDeVie <= 0;
    }
}

public class Program
{
    public static void Main()
    {
        Personnage personnage1 = new Personnage(50);
        Personnage personnage2 = new Personnage(50);

        personnage1.Attaque(personnage2);
        personnage2.Attaque(personnage1);

        Console.WriteLine("Personnage 1 : " + personnage1.GetPointsDeVie() + "/" + personnage1.GetPointsDeVieMax());
        Console.WriteLine("Personnage 2 : " + personnage2.GetPointsDeVie() + "/" + personnage2.GetPointsDeVieMax());
    }
}
