namespace AdventOfCode2023;

public class Day8
{

    struct Node
    {
        public string iD;
        public string l;
        public string r;
        public int foundIndex;
    }
    public static void solve()
    {
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_08.txt");
        string? line = reader.ReadLine();
        List<Node> nodes = new List<Node>();
        long stepCounter = -3;
        string sequence = line;
        reader.ReadLine();
        line = reader.ReadLine();

        while (line != null)
        {
            Node newNode = new Node();
            newNode.iD = line.Substring(0, 3);
            newNode.l = line.Substring(7, 3);
            newNode.r = line.Substring(12, 3);
            nodes.Add(newNode);
            line = reader.ReadLine();
        }

        int sequenceIndex = -3;
        List<Node> currentNodes = nodes.FindAll((x) => x.iD[2] == 'A');
        int[] lengths = { 19633, 17293, 12601, 23149, 13773, 20806 };
        int[] offsets = {3, 7, 3, 3, 3, 4};
        for(int i = 0; i < currentNodes.Count; i++)
        {
            int offset = 0;
            sequenceIndex = 0;
            var search = new List<Node>();
            // while (!search.Contains(new Node{foundIndex = sequenceIndex, iD = currentNodes[i].iD}))
            Console.WriteLine(currentNodes[i].iD + ": " + currentNodes[i].l + " | " + currentNodes[i].r + " | " + sequence[sequenceIndex]);
            while (currentNodes[i].iD[2] != 'Z'){
                offset++;
                // search.Add(new Node{foundIndex = sequenceIndex, iD = currentNodes[i].iD});
                currentNodes[i] = nodes.Find(x => x.iD == (sequence[sequenceIndex] == 'L' ? currentNodes[i].l : currentNodes[i].r));
                sequenceIndex = (sequenceIndex + 1) % sequence.Length;
                // if (offset > 0 || currentNodes[i].iD[2] == 'Z')
                // {
                //     offset++;
                // }
                
                // Console.Write(currentNodes[i].iD[2] == 'Z' ? "-" : "");
            }
            // Console.WriteLine(search.Count + " : " + offset);
            Console.WriteLine(currentNodes[i].iD + ": " + currentNodes[i].l + " | " + currentNodes[i].r + " | " + sequence[sequenceIndex]);
            Console.WriteLine(offset);
            //!IMPORTANT!!!! offset values input into least common multiple calc, it's that easy
            
            // Console.WriteLine()
        }
        

        // bool found = false;
        // int lengthCount = lengths.Length;
        // while (!found)
        // {
        //     stepCounter+=(247395433);
        //     found = true;
        //     // List<int> foundList = new List<int>();
        //
        //     // if ((stepCounter + offsets[1]) % lengths[1] == 0){
        //     //     found = true;
        //     // }
        //     
        //     for (int i = 0; i < lengthCount; i++)
        //     {
        //         // if ((stepCounter + offsets[i]) % lengths[i] == 0){
        //         //     foundList.Add(i);
        //         // }
        //         found = found && ((stepCounter + offsets[i]) % lengths[i] == 0);
        //     }
        //
        //     // if (foundList.Count > 3){
        //     //     Console.Write(stepCounter + " : " );
        //     //
        //     //     for (int i = 0; i < foundList.Count; i++){
        //     //         Console.Write(foundList[i]);
        //     //     }
        //     //     Console.WriteLine();
        //     // }
        // }
        
        // Console.WriteLine();
        // while (currentNodes.Any(x => x.iD[2] != 'Z'))
        // {
        //     
        //     for (int i = 0; i < currentNodes.Count; i++)
        //     {
        //         if (sequence[sequenceIndex] == 'L')
        //         {
        //             currentNodes[i] = nodes.Find(x => x.iD == currentNodes[i].l);
        //         }
        //         else
        //         {
        //             currentNodes[i] = nodes.Find(x => x.iD == currentNodes[i].r);
        //         }
        //     }
        //
        //     sequenceIndex = (sequenceIndex + 1) % sequence.Length;
        //     stepCounter++;
        // }
        
        Console.WriteLine(stepCounter);
    }
}