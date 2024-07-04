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
    
    public static int[] ReplaceTile(string tile, string playerPiece)
    {
        string alph = "ABCDEF";
        
        char[] tileChars = tile.ToCharArray();

        int firstValue = tileChars[0] - '0';
        int secondValue = alph.IndexOf(tileChars[1]);
        
        while (tileChars[1] > 'F' || firstValue > 7 )
        {
            Console.WriteLine("That not a valid move! Try Again!");
            tile = Console.ReadLine();
            tileChars = tile.ToUpper().ToCharArray();
            firstValue = tileChars[0] - '0';
            secondValue = alph.IndexOf(tileChars[1]);
        }

        while (secondValue != 5 && board[secondValue + 1, firstValue - 1] == "0")
        {
            Console.WriteLine("Can't place floating chips! Try Again!");
            tile = Console.ReadLine();
            tileChars = tile.ToUpper().ToCharArray();
            firstValue = tileChars[0] - '0';
            secondValue = alph.IndexOf(tileChars[1]);
        }
        
        
        while (board[secondValue,firstValue-1] == "1" || board[secondValue,firstValue-1] == "2")
        {
            Console.WriteLine("There is already a chip there! Try Again!");
            tile = Console.ReadLine();
            tileChars = tile.ToUpper().ToCharArray();
            firstValue = tileChars[0] - '0';
            secondValue = alph.IndexOf(tileChars[1]);
        }
        

        board[secondValue,firstValue-1] = playerPiece;

        Console.Clear();
        NewBoard();

        int[] replacedTile = { secondValue, firstValue - 1 };
        return replacedTile;
    }

    public static bool CheckWinnner(Player player)
    {
        int counter = 0;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            
            for (int j = 0; j < board.GetLength(1)-1; j++)
            {

                if (board[i, j] == player.playerNumber && board[i, j + 1] == player.playerNumber)
                {
                    counter++;
                }
                else
                {
                    
                    counter=0;
                    
                }

                if (counter == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player {player.playerNumber} won!");
                    return false;
                    
                }
                
            }

            counter = 0;
            
            for (int j = 0; j < board.GetLength(0)-1; j++)
            {

                if (board[j, i] == player.playerNumber && board[j + 1, i] == player.playerNumber)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

                if (counter == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player {player.playerNumber} won!");
                    return false;
                    
                }
                
            }

            counter = 0;
        }
        //diagonal checks
        
        for (int i = 3; i < board.GetLength(0); i++)
        {
            
            for (int j = 0; j < board.GetLength(1) - 3; j++)
            {
                
                if (board[i, j] == player.playerNumber && board[i - 1, j + 1] == player.playerNumber && 
                    board[i - 2, j + 2] == player.playerNumber && board[i - 3, j + 3] == player.playerNumber)
                    
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player {player.playerNumber} won!");
                    return false;
                }
                
            }
            
        }
        
        for (int i = 0; i < board.GetLength(0) - 3; i++)
        {
            
            for (int j = 0; j < board.GetLength(1) - 3; j++)
            {
                
                if (board[i, j] == player.playerNumber && board[i + 1, j + 1] == player.playerNumber && 
                    board[i + 2, j + 2] == player.playerNumber && board[i + 3, j + 3] == player.playerNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Player {player.playerNumber} won!");
                    return false;
                }
                
            }
            
        }
        
        return true;
    }

    public static bool IsDraw()
    {
        foreach (var tile in board)
        {
            if (tile.Contains("0"))
            {
                return true;
            }
            
        }

        return false;
    }
}