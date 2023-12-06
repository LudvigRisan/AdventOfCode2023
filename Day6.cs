namespace AdventOfCode2023;

public class Day6
{
    public static void solve()
    {
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_06.txt");
        List<string> timeLine = reader.ReadLine().Split(" ").ToList();
        List<string> distanceLine = reader.ReadLine().Split(" ").ToList();
        // List<int> times = new List<int>();
        // List<int> distances = new List<int>();
        timeLine.RemoveAll((x) => x == "");
        distanceLine.RemoveAll((x) => x == "");

        string timeString = "";
        string distString = "";
        for (int i = 1; i < timeLine.Count; i++)
        {
            timeString += timeLine[i];
            distString += distanceLine[i];
        }

        long time = long.Parse(timeString);
        long dist = long.Parse(distString);

        long successes = 0;
        
        for (long i = 0; i <= time; i++)
        {
            if (i * (time - i) > dist)
            {
                successes++;
            }
        }
        
        Console.WriteLine(successes);
        
        // for (int i = 1; i < timeLine.Count; i++)
        // {
        //     times.Add(int.Parse(timeLine[i]));
        //     distances.Add(int.Parse(distanceLine[i]));
        // }
        //
        // List<int> options = new List<int>();
        //
        // for (int i = 0; i < times.Count; i++)
        // {
        //     options.Add(0);
        //     for (int j = 0; j <= times[i]; j++)
        //     {
        //         if (j * (times[i] - j) > distances[i])
        //         {
        //             options[i]++;
        //         }
        //     }
        // }
        //
        // int compound = 1;
        // for (int i = 0; i < options.Count; i++)
        // {
        //     compound *= options[i];
        // }
        // Console.WriteLine(compound);
    }
}