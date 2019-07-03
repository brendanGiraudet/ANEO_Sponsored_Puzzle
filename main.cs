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
        var fires = new List<Fire>();
        for (int i = 0; i < lightCount; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            var fire = new Fire
            {
                Distance = int.Parse(inputs[0]),
                Duration = int.Parse(inputs[1])
            };
            
            for (int speed = maxSpeed; speed >= 0; speed--)
            {
                if (CanCross(fire, speed))
                {
                    fire.Speeds.Add(speed);
                }
            }
            fires.Add(fire);
        }
        fires.ForEach(f => { Console.Error.WriteLine(f); });
        
        Console.WriteLine("answer");
    }

    static bool CanCross(Fire feu, int speed)
    {
        return true;
    }
}
class Fire
{
    public int Distance { get; set; } // en mettre
    public int Duration { get; set; } // en secondes
    public List<int> Speeds { get; set; } = new List<int>();

    public override string ToString()
    {
        return "Dist : " + Distance + "m Dur : " + Duration + "s Speed : " + string.Join(',', Speeds) ;
    }
}