namespace ConnectFour;

public class Board
{
    protected static readonly string[,] board =
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
    
    public static void ReplaceTile(int[] tileSpot, string playerPiece)
    {
        
        board[tileSpot[1],tileSpot[0]] = playerPiece;

        Console.Clear();
        NewBoard();
    }

    public static bool CheckWinnner(Player player)
    {
        int counter = 0;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            
            for (int j = 0; j < board.GetLength(1)-1; j++)
            {

                if (board[i, j] == player.PlayerNumber && board[i, j + 1] == player.PlayerNumber)
                {
                    counter++;
                }
                else
                {
                    
                    counter=0;
                    
                }

                if (counter == 3)
                {
                    
                    return false;
                    
                }
                
            }

            counter = 0;
            
            for (int j = 0; j < board.GetLength(0)-1; j++)
            {

                if (board[j, i] == player.PlayerNumber && board[j + 1, i] == player.PlayerNumber)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }

                if (counter == 3)
                {
                    
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
                
                if (board[i, j] == player.PlayerNumber && board[i - 1, j + 1] == player.PlayerNumber && 
                    board[i - 2, j + 2] == player.PlayerNumber && board[i - 3, j + 3] == player.PlayerNumber)
                    
                {
                    return false;
                }
                
            }
            
        }
        
        for (int i = 0; i < board.GetLength(0) - 3; i++)
        {
            
            for (int j = 0; j < board.GetLength(1) - 3; j++)
            {
                
                if (board[i, j] == player.PlayerNumber && board[i + 1, j + 1] == player.PlayerNumber && 
                    board[i + 2, j + 2] == player.PlayerNumber && board[i + 3, j + 3] == player.PlayerNumber)
                {
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
        Console.WriteLine();
        Console.WriteLine("It's a Draw!");
        return false;
    }
}