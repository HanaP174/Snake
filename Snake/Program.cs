using static System.Console;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Playground(16, 32);
            game.StartGame();
        }
    }
}