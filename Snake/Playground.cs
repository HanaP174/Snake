using System.Diagnostics;
using static System.Console;
namespace Snake;

public class Playground
{
    public Playground(int height, int width)
    {
        Height = height;
        Width = width;
    }

    private int Height { get; }

    private int Width { get; }

    private int _score;
    private bool _gameOver;
    private MoveDirection _movement = MoveDirection.Right;
    private Random _random = null!;

    private Snake _snake = null!;
    private Pixel _treat = null!;

    private bool _buttonPressed;
    
    public void StartGame()
    {
        Init();
        GameLoop();
        GameOver();
    }

    private void Init()
    {
        _score = 5;
        _buttonPressed = false;
        _gameOver = false;
        _random = new Random();
        _snake = new Snake(new Pixel(Width / 2, Height / 2, ConsoleColor.Red), new List<Pixel>());
        _treat = new Pixel(_random.Next(0, Width), _random.Next(0, Height),
            ConsoleColor.Cyan);
    }

    private void GameLoop()
    {
        while (true) 
        {
            Clear();
            CheckCollision();
            CreatePlayground();
            EatTreat();
            
            if (_gameOver)
            {
                break;
            }

            DrawGameObjects();
            HandleMovement();
            _snake.UpdateSnakeBodyByScore(_score);
        }
    }
    
    private void CreatePlayground()
    {
        for (var i = 0; i < Width; i++)
        {
            DrawWall(i, 0);
                
            DrawWall(i, Height - 1);
        }
            
        for (var i = 0; i < Height; i++)
        {
            DrawWall(0, i);
                
            DrawWall(Width - 1, i);
        }
    }

    private static void DrawWall(int positionX, int positionY)
    {
        ForegroundColor = ConsoleColor.Green;
        SetCursorPosition(positionX, positionY);
        Write("■");
    }

    private void CheckCollision()
    {
        _gameOver |= _snake.Head.PositionX == Width - 1 || _snake.Head.PositionX == 0 ||
               _snake.Head.PositionY == Height - 1 || _snake.Head.PositionY == 0;
    }

    private void EatTreat()
    {
        if (_treat.PositionX == _snake.Head.PositionX && _treat.PositionY == _snake.Head.PositionY)
        {
            _score++;
            _treat.PositionX = _random.Next(1, Width - 2);
            _treat.PositionY = _random.Next(1, Height - 2);
        }
    }

    private void DrawGameObjects()
    {
        foreach (var bodyPart in _snake.Body)
        {
            Pixel.Draw(bodyPart);
            _gameOver = bodyPart.PositionX == _snake.Head.PositionX && bodyPart.PositionY == _snake.Head.PositionY;
        }
            
        Pixel.Draw(_snake.Head);
        Pixel.Draw(_treat);
    }

    private void HandleMovement()
    {
        _buttonPressed = false;

        var watch = Stopwatch.StartNew();
        while (watch.ElapsedMilliseconds <= 500)
        {
            SetMovement();
        }

        _snake.IncreaseBodySizeByHead();
        _snake.MoveSnake(_movement);
    }

    private void SetMovement()
    {
        if (!KeyAvailable) return;
        
        var consoleKeyInfo = ReadKey(true);
        switch (consoleKeyInfo.Key)
        {
            case ConsoleKey.UpArrow when _movement != MoveDirection.Down && _buttonPressed == false:
                _movement = MoveDirection.Up;
                _buttonPressed = true;
                break;
            case ConsoleKey.DownArrow when _movement != MoveDirection.Up && _buttonPressed == false:
                _movement = MoveDirection.Down;
                _buttonPressed = true;
                break;
            case ConsoleKey.LeftArrow when _movement != MoveDirection.Right && _buttonPressed == false:
                _movement = MoveDirection.Left;
                _buttonPressed = true;
                break;
            case ConsoleKey.RightArrow when _movement != MoveDirection.Left && _buttonPressed == false:
                _movement = MoveDirection.Right;
                _buttonPressed = true;
                break;
        }
    }

    private void GameOver()
    {
        SetCursorPosition(Width / 5, Height / 2);
        WriteLine("Game over, Score: "+ _score);
        SetCursorPosition(Width / 5, Height / 2 + 1);
    }
}