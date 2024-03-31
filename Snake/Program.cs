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
            int gameover = 0;
            Pixel pixel = new Pixel(screenwidth/2, screenheight/2, ConsoleColor.Red);
            MoveDirection movement = MoveDirection.Right;
            List<int> xposlijf = new List<int>();
            List<int> yposlijf = new List<int>();
            int berryx = randomnummer.Next(0, screenwidth);
            int berryy = randomnummer.Next(0, screenheight);
            DateTime tijd = DateTime.Now;
            DateTime tijd2 = DateTime.Now;
            bool buttonpressed = false;
            while (true)
            {
                Clear();
                if (pixel.PositionX == screenwidth-1 || pixel.PositionX == 0 ||pixel.PositionY == screenheight-1 || pixel.PositionY == 0)
                { 
                    gameover = 1;
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
                if (berryx == pixel.PositionX && berryy == pixel.PositionY)
                {
                    score++;
                    berryx = randomnummer.Next(1, screenwidth-2);
                    berryy = randomnummer.Next(1, screenheight-2);
                } 
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Write("■");
                    if (xposlijf[i] == pixel.PositionX && yposlijf[i] == pixel.PositionY)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                SetCursorPosition(pixel.PositionX, pixel.PositionY);
                ForegroundColor = pixel.ScreenColor;
                Write("■");
                SetCursorPosition(berryx, berryy);
                ForegroundColor = ConsoleColor.Cyan;
                Write("■");
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
                xposlijf.Add(pixel.PositionX);
                yposlijf.Add(pixel.PositionY);
                switch (movement)
                {
                    case MoveDirection.Up:
                        pixel.PositionY--;
                        break;
                    case MoveDirection.Down:
                        pixel.PositionY++;
                        break;
                    case MoveDirection.Left:
                        pixel.PositionX--;
                        break;
                    case MoveDirection.Right:
                        pixel.PositionX++;
                        break;
                }
                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            SetCursorPosition(screenwidth / 5, screenheight / 2);
            WriteLine("Game over, Score: "+ score);
            SetCursorPosition(screenwidth / 5, screenheight / 2 +1);
        }
    }
}