namespace AdventOfCode2023;

public class Day9
{
    public static void solve(){
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_09.txt");
        string? line = reader.ReadLine();
        int sumValues = 0;
        
        while (line != null){
            List<List<int>> sequenceTree = new List<List<int>>();
            sequenceTree.Add(new List<int>());
            
            string[] numbers = line.Split(" ");
            
            for (int i = 0; i < numbers.Length; i++){
                sequenceTree[0].Add(int.Parse(numbers[i]));
            }
            
            while (sequenceTree.Last().Any(x => x != 0)){
                List<int> currentLine = sequenceTree.Last();
                sequenceTree.Add(new List<int>());
                
                for (int i = 0; i < currentLine.Count - 1; i++){
                    sequenceTree.Last().Add(currentLine[i + 1] - currentLine[i]);
                }
            }
            
            sequenceTree.Last().Add(0);
            
            for (int i = sequenceTree.Count - 2; i >= 0; i--){
                sequenceTree[i].Insert(0,sequenceTree[i][0] - sequenceTree[i + 1][0]);
            }
            
            sumValues += sequenceTree[0][0];
            
            line = reader.ReadLine();
        }
        Console.WriteLine(sumValues);
    }
}
