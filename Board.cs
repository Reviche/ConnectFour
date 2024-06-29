namespace ConnectFour;

public class Board
{
    public static string[,] board =
    {
        { "0", "0", "0", "0", "0", "0", "0" },
        { "0", "0", "0", "0", "0", "0", "0" },
        { "0", "0", "0", "0", "0", "0", "0" },
        { "0", "0", "0", "0", "0", "0", "0" },
        { "0", "0", "0", "0", "0", "0", "0" },
        { "0", "0", "0", "0", "0", "0", "0" },

    };
    public static void NewBoard()
    {
        int counter = 0;
        int asciiValue = 65;
        Console.Write("  ");
        for (int i = 0; i < board.GetLength(1); i++)
        {
            Console.Write($" {i+1} ");
        }
        
        foreach (var x in board)
        {
            if (counter % 7 == 0 || counter == 0)
            {
                
                Console.WriteLine();
                Console.Write(Convert.ToChar(asciiValue++)+" ");
                
            }

            Console.Write($"|{x}|");
            counter++;
        }
    }
    
    
    
    public static void ReplaceTile(string tile, string playerPiece)
    {
        //2B
        // '2','B'

        string alph = "ABCDEF";
        
        char[] tileChars = tile.ToCharArray();

        int firstValue = tileChars[0] - '0';
        int secondValue = alph.IndexOf(tileChars[1]);
        if (secondValue != 5)
        {
            while (board[secondValue + 1, firstValue - 1] == "0")
            {
                Console.WriteLine("Can't place floating chips! Try Again!");
                tile = Console.ReadLine();
                tileChars = tile.ToCharArray();
                firstValue = tileChars[0] - '0';
                secondValue = alph.IndexOf(tileChars[1]);
            }
        }

        board[secondValue,firstValue-1] = playerPiece;
        
        Console.Clear();
        NewBoard();

    }
}