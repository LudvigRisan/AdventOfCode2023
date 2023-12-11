using System.IO;
using AdventOfCode2023;

// using System.Text.RegularExpressions;
//
// StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_01.txt");
//
// string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
// string cleaner = "[^0-9]";
// string? line;
//
// line = reader.ReadLine();
// int sum = 0;
//
// while (line != null)
// {
//     for (int i = 0; i < numbers.Length; i++)
//     {
//         line = Regex.Replace(line, "(" +numbers[i] + ")",  "$&" + (i + 1).ToString() + "$&");
//     }
//     // Console.WriteLine(line);
//
//     line = Regex.Replace(line, cleaner, "");
//     
//     
//     List<char> values = line.ToList();
//
//     sum += int.Parse(values[0].ToString() + values.Last().ToString());
//     
//     line = reader.ReadLine();
// }
//
// Console.WriteLine(sum);

Day11.solve();

