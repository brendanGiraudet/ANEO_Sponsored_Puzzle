using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int maxSpeed = int.Parse(Console.ReadLine());// km/h
        int lightCount = int.Parse(Console.ReadLine());
        var Feux = new List<Feu>();
        for (int i = 0; i < lightCount; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            Feux.Add(new Feu
            {
                Distance = int.Parse(inputs[0]),
                Duration = int.Parse(inputs[1])
            });
        }
        Feux.ForEach(f => { Console.Error.WriteLine(f); });
        Console.WriteLine("answer");
    }
}
class Feu
{
    public int Distance { get; set; } // en mettre
    public int Duration { get; set; } // en secondes
    public List<int> Vitesse { get; set; } = new List<int>();

    public override string ToString()
    {
        return "Dist : " + Distance + "m Dur : " + Duration + "s";
    }
}