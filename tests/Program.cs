using System;

//string[,] terrain = new string[15, 15];

//string tab = "";

//for (int i = 0; i < terrain.GetLength(0); i++)
//{
//    for (int j = 0; j < terrain.GetLength(1); j++)
//    {
//        tab += "[ ]";
//    }
//    tab += "\n";
//}
//Console.WriteLine(tab);


string[,] terrain = new string[15, 15];

for (int i = 0; i < terrain.GetLength(0); i++)
{
    for (int j = 0; j < terrain.GetLength(1); j++)
    {
        Console.Write("[ ]");
    }
    Console.WriteLine();
}