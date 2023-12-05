namespace AdventOfCode2023;

public class Day5
{
    public static void solve()
    {
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_05.txt");
        string? line = reader.ReadLine();

        List<List<long>> valid = new List<List<long>>();
        valid.Add(new List<long>());
        
        string[] segments = line.Split(" ");
        
        for (int i = 1; i < segments.Length; i += 2)
        {
            valid[0].Add(long.Parse(segments[i]));
            valid[0].Add(long.Parse(segments[i + 1]));
        }

        line = reader.ReadLine();
        line = reader.ReadLine();
        line = reader.ReadLine();
        
        valid.Add(new List<long>());
        
        int stageCounter = 1;

        List<long> found = new List<long>();
        
        while (line != null)
        {
            if (line == "")
            {
                for (int i = 0; i < valid[stageCounter - 1].Count; i ++)
                {
                    valid[stageCounter].Add(valid[stageCounter - 1][i]);
                }
                
                valid.Add(new List<long>());
                reader.ReadLine();
                stageCounter++;
            }
            else
            {
                segments = line.Split(" ");
                long source = long.Parse(segments[1]);
                long change = long.Parse(segments[0]) - source;
                long span = long.Parse(segments[2]);
                for (int i = valid[stageCounter - 1].Count - 2; i >= 0; i -= 2)
                {
                    long start = Math.Max(source, valid[stageCounter - 1][i]);
                    long end = Math.Min(source + span, valid[stageCounter - 1][i] + valid[stageCounter - 1][i + 1]);
                    if (start < end)
                    {
                        valid[stageCounter].Add(start + change);
                        valid[stageCounter].Add((end - start));

                        if (end < valid[stageCounter - 1][i] + valid[stageCounter - 1][i + 1] && start > valid[stageCounter - 1][i])
                        {
                            long start1 = valid[stageCounter - 1][i];
                            long span1 = start - valid[stageCounter - 1][i];
                            valid[stageCounter - 1][i] = start1;
                            valid[stageCounter - 1][i + 1] = span1;
                            valid[stageCounter - 1].Add(end);
                            valid[stageCounter - 1].Add(valid[stageCounter - 1][i] + valid[stageCounter - 1][i + 1] - end);
                        }
                        else if (end < valid[stageCounter - 1][i] + valid[stageCounter - 1][i + 1])
                        {
                            valid[stageCounter - 1][i + 1] =
                                valid[stageCounter - 1][i] + valid[stageCounter - 1][i + 1] - end;
                            valid[stageCounter - 1][i] = end;
                        }
                        else if (start > valid[stageCounter - 1][i])
                        {
                            valid[stageCounter - 1][i + 1] = start - valid[stageCounter - 1][i];
                        }
                        else
                        {
                            valid[stageCounter - 1].RemoveRange(i, 2);
                        }
                        
                    }
                }
            }
            
            line = reader.ReadLine();
        }
        
        for (int i = 0; i < valid[stageCounter - 1].Count; i++)
        {
            if (!found.Contains(valid[stageCounter - 1][i]))
            {
                valid[stageCounter].Add(valid[stageCounter - 1][i]);
            }
        }
        
        // for (int i = 0; i < valid.Count; i++)
        // {
        //     for (int j = 0; j < valid[i].Count; j++)
        //     {
        //         Console.WriteLine(valid[i][j]);
        //         
        //     }
        //     Console.WriteLine();
        // }

        long lowest = long.MaxValue;
        
        for (int i = 0; i < valid.Last().Count; i+= 2)
        {
            if (valid.Last()[i] < lowest)
            {
                lowest = valid.Last()[i];
            }
        }
        
        Console.WriteLine(lowest);
        
    }
}