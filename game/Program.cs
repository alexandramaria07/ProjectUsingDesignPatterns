using System;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();

                game.NewGame();
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred: " + exception);
            }
        }
    }
}
