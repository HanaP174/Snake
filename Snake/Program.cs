using static System.Console;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            // todo playground -> init()
            WindowHeight = 16;
            WindowWidth = 32;
            int screenwidth = WindowWidth;
            int screenheight = WindowHeight;
            // todo playground
            
            Random randomnummer = new Random();
            int score = 5;
            bool gameover = false;
            
            // snake
            Pixel head = new Pixel(screenwidth/2, screenheight/2, ConsoleColor.Red);
            List<Pixel> body = new List<Pixel>();

            MoveDirection movement = MoveDirection.Right;
            // treat
            Pixel treat = new Pixel(randomnummer.Next(0, screenwidth), randomnummer.Next(0, screenheight),
                ConsoleColor.Cyan);
            
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            
            bool buttonpressed = false;
            while (true)
            {
                Clear();
                if (head.PositionX == screenwidth-1 || head.PositionX == 0 || head.PositionY == screenheight-1 || head.PositionY == 0)
                { 
                    gameover = true;
                }
                for (int i = 0;i< screenwidth; i++)
                {
                    SetCursorPosition(i, 0);
                    Write("■");
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    SetCursorPosition(i, screenheight -1);
                    Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    SetCursorPosition(0, i);
                    Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    SetCursorPosition(screenwidth - 1, i);
                    Write("■");
                }
                ForegroundColor = ConsoleColor.Green;
                if (treat.PositionX == head.PositionX && treat.PositionY == head.PositionY)
                {
                    score++;
                    treat.PositionX = randomnummer.Next(1, screenwidth-2);
                    treat.PositionY = randomnummer.Next(1, screenheight-2);
                } 
                for (int i = 0; i < body.Count(); i++)
                {
                    Pixel.Draw(body[i]);
                    
                    if (body[i].PositionX == head.PositionX && body[i].PositionY == head.PositionY)
                    {
                        gameover = true;
                    }
                }
                if (gameover)
                {
                    break;
                }
                
                Pixel.Draw(head);
                Pixel.Draw(treat);
                
                tijd = DateTime.Now;
                buttonpressed = false;
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (KeyAvailable)
                    {
                        ConsoleKeyInfo toets = ReadKey(true);
                        //WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != MoveDirection.Down && buttonpressed == false)
                        {
                            movement = MoveDirection.Up;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != MoveDirection.Up && buttonpressed == false)
                        {
                            movement = MoveDirection.Down;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != MoveDirection.Right && buttonpressed == false)
                        {
                            movement = MoveDirection.Left;
                            buttonpressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != MoveDirection.Left && buttonpressed == false)
                        {
                            movement = MoveDirection.Right;
                            buttonpressed = true;
                        }
                    }
                }
                body.Add(new Pixel (head.PositionX, head.PositionY, ConsoleColor.Green));
                switch (movement)
                {
                    case MoveDirection.Up:
                        head.PositionY--;
                        break;
                    case MoveDirection.Down:
                        head.PositionY++;
                        break;
                    case MoveDirection.Left:
                        head.PositionX--;
                        break;
                    case MoveDirection.Right:
                        head.PositionX++;
                        break;
                }
                if (body.Count() > score)
                {
                    body.RemoveAt(0);
                }
            }
            SetCursorPosition(screenwidth / 5, screenheight / 2);
            WriteLine("Game over, Score: "+ score);
            SetCursorPosition(screenwidth / 5, screenheight / 2 +1);
        }
    }
}