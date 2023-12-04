namespace AdventOfCode2023;

public class Day4
{
    
    
    public static void solve()
    {
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_04.txt");
        string? line = reader.ReadLine();

        int sum = 0;

        List<int> copies = new List<int>();
        
        while (line != null)
        {
            int copyValue = copies.Count > 0 ? copies[0] : 1;
            if (copies.Count > 0)
            {
                copies.RemoveAt(0);
            }
            line = line.Split(':')[1];
            string[] winning = line.Split('|')[0].Split(' ');
            string[] numbers = line.Split('|')[1].Split(' ');

            int points = 0;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == " " || numbers[i] == "") continue;
                // Console.WriteLine(numbers[i]);
                if (winning.Contains(numbers[i]))
                {
                    points++;
                }
            }

            for (int i = 0; i < points; i++)
            {
                if (copies.Count > i)
                {
                    copies[i] += copyValue;
                }
                else
                {
                    copies.Add(copyValue + 1);
                }
            }

            sum += copyValue;
            
            line = reader.ReadLine();
        }
        
        Console.WriteLine(sum);
    }
    
    
    
}