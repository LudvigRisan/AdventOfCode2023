namespace AdventOfCode2023;

public class Day7
{
    struct Hand
    {
        public string cards;
        public int bid;
    }
    
    public static void solve()
    {
        StreamReader reader = new StreamReader(@"..\..\..\..\Inputs\input_07.txt");
        string? line = reader.ReadLine();


        List<Hand> hands = new List<Hand>();

        while (line != null)
        {
            Hand readHand = new Hand();
            string[] split = line.Split(" ");
            readHand.cards = split[0];
            readHand.bid = int.Parse(split[1]);
            
            hands.Add(readHand);
            
            line = reader.ReadLine();
        }


        hands.Sort(compareHands);

        int sumWins = 0;
        for (int i = 0; i < hands.Count; i++)
        {
            Console.WriteLine((i + 1) + ": " + hands[i].cards + " " + hands[i].bid + " : " + sumWins + " + " + (hands[i].bid * (i + 1)));
            sumWins += hands[i].bid * (i + 1);
        }
        Console.WriteLine(sumWins);
    }

    static int compareHands(Hand handX, Hand handY)
    {
        if (handX.cards == handY.cards)
        {
            return 0;
        }

        int typeX = getType(handX.cards);
        int typey = getType(handY.cards);

        if (typey == typeX)
        {
            for (int i = 0; i < 5; i++)
            {
                if (handX.cards[i] != handY.cards[i])
                {
                    return getValue(handX.cards[i]) - getValue(handY.cards[i]);
                }
            }
            return 0;
        }

        return typeX - typey;
    }

    static int getValue(char input)
    {
        switch (input)
        {
            case 'A':
                return 14;
            case 'K':
                return 13;
            case 'Q':
                return 12;
            case 'J':
                return 1;
            case 'T':
                return 10;
            default:
                return int.Parse(input.ToString());
            
        }
    }
    
    static int getType(string hand)
    {
        int highest = 0;
        int secondHighest = 0;
        List<Char> found = new List<char>();
        int jCount = 0;
        for (int i = 0; i < 5; i++)
        {
            if (hand[i] == 'J')
            {
                jCount++;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            int counter = 0;
            char character = hand[i];
            if (found.Contains(character))
            {
                continue;
            }
            found.Add(character);
            if (character != 'J')
            {
                for (int j = i; j < 5; j++)
                {
                    if (hand[j] == character)
                    {
                        counter++;
                    }
                }
            }

            if (counter > highest)
            {
                secondHighest = highest;
                highest = counter;
            }
            else if (counter > secondHighest)
            {
                secondHighest = counter;
            }
        }

        switch (highest + jCount)
        {
            case 5:
                return 6;
            case 4:
                return 5;
            case 3:
                return secondHighest == 2 ? 4 : 3;
            case 2:
                return secondHighest == 2 ? 2 : 1;
            default:
                return 0;
        }
    }
    

}