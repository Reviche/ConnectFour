namespace ConnectFour;

public class Player
{
    public string playerNumber;

    public Player(string playerNumber)
    {
        this.playerNumber = playerNumber;
    }

    public string PlayerMove()
    {
        string playerMove;
        Console.WriteLine();
        Console.WriteLine($"Player {playerNumber} place your chip (Ex. 2F, 6C, etc.)");
        do
        {
            playerMove = Console.ReadLine();
            if (playerMove.Length != 2)
            {
                Console.WriteLine("Please Enter a valid move.");
            }

        } while (playerMove.Length != 2);

        return playerMove.ToUpper();

    }



}