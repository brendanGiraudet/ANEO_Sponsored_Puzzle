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
                Duration = int.Parse(inputs[1]),
                DistanceAfterFire = (fires.Count > 0) ? int.Parse(inputs[0]) - fires[i - 1].Distance : 0
            };

            for (int speed = maxSpeed; speed > 0; speed--)
            {
                if (CanCross(fire, speed))
                {
                    fire.Speeds.Add(speed);
                }
            }
            fires.Add(fire);
        }
        fires.ForEach(f => { Console.Error.WriteLine(f); });

        var rep = GetSimilarSpeedMax(fires);
        Console.WriteLine(rep);
    }
    /// <summary>
    /// Recupère la vitesse maximum communes des feux
    /// </summary>
    /// <param name="fires">Listes des feux</param>
    /// <returns>Vitesse maximum commune de tous les feux</returns>
    static int GetSimilarSpeedMax(List<Fire> fires)
    {
        var speedMax = 0;
        foreach (var speed in fires.First().Speeds)
        {
            var ok = false;
            foreach (var fire in fires)
            {
                if (fire.Speeds.Contains(speed))
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    break;
                }
            }
            if (ok)
            {
                return speed;
            }
        }

        return speedMax;
    }
    /// <summary>
    /// Verifie si on peut traverser le feu vert a cette vitesse
    /// </summary>
    /// <param name="fire">feu en question</param>
    /// <param name="speed">vitesse</param>
    /// <returns>True si la vitesse permet de traverser le feu vert sinon False</returns>
    static bool CanCross(Fire fire, int speed)
    {
        decimal toKm = 1000;
        decimal toHour = 3600;
        var kmDist = fire.Distance / toKm;
        
        var time = kmDist / speed;//en heure
        var timeFire = Convert.ToDecimal(fire.Duration) / toHour;
        if (time <= timeFire)
        {
            return true;
        }
        var i = 2;
        do
        {
            i++;
            if(speed == 54)
            {
                Console.Error.WriteLine("dis " + kmDist + " Vit " + speed + " time " + time + " timefire " + timeFire);
                Console.Error.WriteLine("i " + i + " tic " + timeFire * (i - 1) + " tac " + timeFire * i);
            }
            
            if (i % 2 != 0 && (timeFire * (i - 1)) <= time && time <= (timeFire * i))
            {
                return true;
            }
        } while (time > (timeFire * i));

        return false;
    }
}
/// <summary>
/// Classe representant le feu
/// </summary>
class Fire
{
    public int DistanceAfterFire { get; set; }
    public int Distance { get; set; } // en metres
    public int Duration { get; set; } // en secondes
    public List<int> Speeds { get; set; } = new List<int>();

    public override string ToString()
    {
        return "Dist : " + Distance + " Dist after fire : " + DistanceAfterFire + "m Dur : " + Duration + "s Speed : " + string.Join(',', Speeds);
    }
}