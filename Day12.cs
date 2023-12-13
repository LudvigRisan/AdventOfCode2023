namespace AdventOfCode2023;

public class Day12
{
    public static void solve()
    {
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_12.txt");
        string? line = reader.ReadLine();

        long optionCount = 0;
        
        while (line != null)
        {
            string[] numbers = line.Split(" ")[1].Split(",");
            line = line.Split(" ")[0];
            line = line + "?" + line + "?" + line + "?" + line + "?" + line;
            char[] map = line.ToCharArray();
            int[] values = new int[numbers.Length * 5];
            
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = int.Parse(numbers[i % numbers.Length]);
                Console.Write(values[i] + ",");
            }
            Console.WriteLine();
            Console.WriteLine(map);
            

            uint options = 0;
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == '?')
                {
                    options++;
                }
            }

            for (ulong i = 0; i < Math.Pow(2, options); i++)
            {
                int unknownIndex = 0;
                bool[] applied = applyMap(map, i);
                // Console.Write(applied);
                if (checkMap(applied, values))
                {
                    optionCount++;
                    // Console.Write("+");
                }
                // Console.WriteLine();
            }
            line = reader.ReadLine();
            Console.WriteLine(optionCount);
        }
        Console.WriteLine(optionCount);
        
    }

    static bool[] applyMap(char[] map, ulong value)
    {
        bool[] clone = new bool[map.Length];
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == '?')
            {
                clone[i] = (value & 1) == 0;
                value >>= 1;
            }
            else
            {
                clone[i] = map[i] == '#';
            }
        }
        
        return clone;
    }

    static bool checkMap(bool[] map, int[] ledger)
    {
        int run = 0;
        int ledgerIndex = 0;
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i])
            {
                run++;
            }
            else if(run > 0)
            {
                if (ledgerIndex >= ledger.Length || run != ledger[ledgerIndex])
                {
                    return false;
                }
                
                ledgerIndex++;
                run = 0;
            }
        }

        return (ledgerIndex == ledger.Length && run == 0) || (ledgerIndex == ledger.Length - 1 && run == ledger[ledgerIndex]);
    } 
    
}