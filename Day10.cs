namespace AdventOfCode2023;

public class Day10
{
    struct Runner
    {
        public int currentX;
        public int currentY;
        public int prevX;
        public int prevY;
    }
    
    static List<string> board = new List<string>();
    static List<string> map = new List<string>();
    
    public static void solve(){
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_10.txt");
        string? line = reader.ReadLine();
        
        int posX = 0;
        int posY = 0;
        
        while (line != null){
            board.Add(line);
            map.Add(new string('.', line.Length));
            if (line.Contains('S')){
                posX = line.IndexOf('S');
                posY = board.Count - 1;
            }
            
            line = reader.ReadLine();
        }
        
        //Manually discover starting node to be a 7
        map[posY] = map[posY].Remove(posX, 1).Insert(posX, "7");
        
        Runner runner1 = new Runner(){
            currentX = posX,
            currentY = posY + 1,
            prevX = posX,
            prevY = posY
        };
        
        Runner runner2 = new Runner(){
            currentX = posX - 1,
            currentY = posY,
            prevX = posX,
            prevY = posY
        };
        
        int stepCounter = 1;
        while (runner1.currentX != runner2.currentX || runner1.currentY != runner2.currentY){
            stepCounter++;
            
            runner1 = stepRunner(runner1);
            runner2 = stepRunner(runner2);
            
        }
        for (int i = 0; i < map.Count; i++){
            Console.WriteLine(map[i]);
        }
        Console.WriteLine();
        
        
        int insideCounter = 0;
        for (int i = 0; i < map.Count; i++){
            for (int j = 0; j < map[i].Length; j++){
                if (map[i][j] == '.'){
                    bool inside = false;
                    int run = 0;
                    for (int k = j; k >= 0; k--){
                        if (run == 0){
                            if (map[i][k] != '.' && map[i][k] != '§'){
                                inside = !inside;
                                
                                if ("F7".Contains(map[i][k])){
                                    run = 1;
                                }
                                else if ("LJ".Contains(map[i][k])){
                                    run = -1;
                                }
                            }
                        }
                        else{
                            int tilt = 0;
                            if ("F7".Contains(map[i][k])){
                                tilt = 1;
                            }
                            else if ("LJ".Contains(map[i][k])){
                                tilt = -1;
                            }

                            if (tilt == -run){
                                run = 0;
                            }
                            else if(tilt == run){
                                run = 0;
                                inside = !inside;
                            }
                        }
                    }
                    if (inside){
                        insideCounter++;
                        map[i] = map[i].Remove(j, 1).Insert(j, "§");
                    }
                }
            }
        }
        
        for (int i = 0; i < map.Count; i++){
            Console.WriteLine(map[i]);
        }
        
        Console.WriteLine(insideCounter);
        
    }

    static Runner stepRunner(Runner runner){
        int prevX = runner.currentX;
        int prevY = runner.currentY;
        map[runner.currentY] = map[runner.currentY].Remove(runner.currentX, 1).Insert(runner.currentX, board[runner.currentY][runner.currentX].ToString());
        switch (board[runner.currentY][runner.currentX]){
            case '-':
                runner.currentX += runner.currentX - runner.prevX;
                break;
            case '|':
                runner.currentY += runner.currentY - runner.prevY;
                break;
            case 'L':
                if (runner.currentX != runner.prevX){
                    runner.currentY--;
                }
                else{
                    runner.currentX++;
                }
                break;
            case 'F':
                if (runner.currentX != runner.prevX){
                    runner.currentY++;
                }
                else{
                    runner.currentX++;
                }
                break;
            case 'J':
                if (runner.currentX != runner.prevX){
                    runner.currentY--;
                }
                else{
                    runner.currentX--;
                }
                break;
            case '7':
                if (runner.currentX != runner.prevX){
                    runner.currentY++;
                }
                else{
                    runner.currentX--;
                }
                break;
        }
        runner.prevX = prevX;
        runner.prevY = prevY;
        return runner;
    }
    
}
