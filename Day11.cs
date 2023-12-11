namespace AdventOfCode2023;

public class Day11
{
    struct Galaxy
    {
        public int x;
        public int y;
    }
    
    public static void solve()
    {
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_11.txt");
        string? line = reader.ReadLine();
        
        List<string> map = new List<string>();

        List<int> verticals = new List<int>();
        List<int> horizontals = new List<int>();
        
        while (line != null)
        {
            if (line.All(x => x == '.'))
            {
                horizontals.Add(map.Count);
                Console.Write(map.Count + " ");
            }
            map.Add(line);
            line = reader.ReadLine();
        }
        Console.WriteLine();
        for (int i = 0; i < map[0].Length; i++)
        {
            bool empty = true;
            for (int j = 0; j < map.Count; j++)
            {
                empty = empty && map[j][i] == '.';
            }

            if (empty)
            {
                verticals.Add(i);
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
        
        List<Galaxy> locations = new List<Galaxy>();

        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '#')
                {
                    locations.Add(new Galaxy{x = j, y = i});
                }
            }
        }
        
        long sumDist = 0;
        
        for (int i = 0; i < locations.Count - 1; i++)
        {
            for (int j = i + 1; j < locations.Count; j++)
            {
                sumDist += Math.Abs(locations[i].x - locations[j].x);
                int minX = Math.Min(locations[i].x, locations[j].x);
                int maxX = Math.Max(locations[i].x, locations[j].x);
                for (int k = 0; k < verticals.Count; k++)
                {
                    if (minX < verticals[k] && verticals[k] < maxX)
                    {
                        sumDist += 999999;
                    }
                }
                
                sumDist += Math.Abs(locations[i].y - locations[j].y);
                int minY = Math.Min(locations[i].y, locations[j].y);
                int maxY = Math.Max(locations[i].y, locations[j].y);
                for (int k = 0; k < horizontals.Count; k++)
                {
                    if (minY < horizontals[k] && horizontals[k] < maxY)
                    {
                        sumDist += 999999;
                    }
                }
            }
        }
        
        Console.WriteLine(sumDist);
    }
}