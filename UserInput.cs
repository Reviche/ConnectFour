namespace ConnectFour;

public class UserInput
{
    private string? playerMove;
    public string GetPlayerMove(Player player)
    {
        Console.WriteLine();
        Console.WriteLine($"Player {player.PlayerNumber} place your chip (Ex. 2F, 6C, etc.)");
        playerMove = Console.ReadLine();

        return playerMove.ToUpper();

    }
    
    public static void WinnerMessage(Player player)
    {
            Console.WriteLine();
            Console.WriteLine($"Player {player.PlayerNumber} won!");
        
    }
    
    public bool PlayAgain()
    {
        Console.WriteLine("Would you like to play again? y/n");
        string yesOrNo = Console.ReadLine().ToLower();

        while (yesOrNo != "y" && yesOrNo != "n")
        {
            Console.WriteLine("Please type 'y' for yes or 'n' for no");
           yesOrNo = Console.ReadLine().ToLower();
        }

        if (yesOrNo == "y")
        {
            return true;
        }
        Console.WriteLine("Thank you for playing!");
        return false;
    }
    
    
}