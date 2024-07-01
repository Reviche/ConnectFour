namespace ConnectFour;

class Program
{
    static void Main(string[] args)
    {
        Board.NewBoard();

        Player player1 = new Player("1");
        Player player2 = new Player("2");
        bool winner;
        do
        {
            Board.ReplaceTile(player1.PlayerMove(),player1.playerNumber);
            winner = Board.CheckWinnner(player1);
            if(winner == false) break;
            Board.ReplaceTile(player2.PlayerMove(),player2.playerNumber);
            winner = Board.CheckWinnner(player2);
            if(winner == false) break;

        } while (true);
        
        
    }
}