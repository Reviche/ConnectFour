namespace ConnectFour;

public class Validation : Board

{
    const string alph = "ABCDEF";

    private bool isValid = false;
    
    private char[] tileChars;
    private int firstValue;
    private int secondValue;

    public int[] ValidatePlayerMove(string? tile)
    {
        while (!isValid)
        {
            if (tile == null || tile.Length != 2)
            {
                
                Console.WriteLine("Please Enter a valid move.");
                tile = Console.ReadLine().ToUpper();

            }
            else if (tile[1] > 'F' || tile[0] - '0' > 7)
            {
                
                Console.WriteLine("That not a valid move! Try Again!");
                tile = Console.ReadLine().ToUpper();
            }
            else
            {
                tileChars = tile.ToUpper().ToCharArray();
                firstValue = tileChars[0] - '0';
                secondValue = alph.IndexOf(tileChars[1]);
                
                if (ValidateTile(tile))
                {
                    isValid = true;
                }
                else
                {
                    tile = Console.ReadLine().ToUpper();
                }
            }
        }
        
        isValid = false;
        firstValue -= 1;
        int[] tileSpot = { firstValue, secondValue};

        return tileSpot;
    }

    public bool ValidateTile(string tile)
    {
        
            if (secondValue != 5 && board[secondValue + 1, firstValue - 1] == "0")
            {
                Console.WriteLine("Can't place floating chips! Try again!");
                return false;
                
            }
            if (board[secondValue, firstValue - 1] == "1" || board[secondValue, firstValue - 1] == "2")
            {
                Console.WriteLine("There is already a chip there! Try again!");
                return false;
            }
            return true;
        

    }
}