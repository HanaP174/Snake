namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var snakeGame = new Playground(16, 32);
            snakeGame.StartGame();
        }
    }
}