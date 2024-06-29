namespace ConnectFour;

class Program
{
    static void Main(string[] args)
    {
        Board.NewBoard();

        Player player1 = new Player("1");
        Player player2 = new Player("2");
        do
        {
            Board.ReplaceTile(player1.PlayerMove(),player1.playerNumber);
            Board.ReplaceTile(player2.PlayerMove(),player2.playerNumber);

        } while (true);

        
        
    }
}