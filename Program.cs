using System.Diagnostics;

namespace ConnectFour;

class Program
{
    static void Main(string[] args)
    {
        Board.NewBoard();
        
        Validation valid = new Validation();
        UserInput userInput = new UserInput();
        
        Player player1 = new Player("1");
        Player player2 = new Player("2");
        bool winner;
        do
        {
            Board.ReplaceTile(valid.ValidatePlayerMove(userInput.GetPlayerMove(player1)),player1.PlayerNumber);
            winner = Board.CheckWinnner(player1);
            if (winner == false)
            {
                UserInput.WinnerMessage(player1);
                break;
            }
            Board.ReplaceTile(valid.ValidatePlayerMove(userInput.GetPlayerMove(player2)),player2.PlayerNumber);
            winner = Board.CheckWinnner(player2);
            if (winner == false)
            {
                UserInput.WinnerMessage(player2);
                break;
            }

        } while (Board.IsDraw());

        if (userInput.PlayAgain())
        {
            
            Console.Clear();
            string currentApplication = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start( currentApplication );
            Environment.Exit(0);
        }
       
        

        
    }
}