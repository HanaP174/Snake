namespace Snake;

public class Snake
{
    public Snake(Pixel head, List<Pixel> body)
    {
        Head = head;
        Body = body;
    }

    public Pixel Head { get; set; }
    public List<Pixel> Body { get; set; }

    public void IncreaseBodySizeByHead()
    {
        Body.Add(new Pixel (Head.PositionX, Head.PositionY, ConsoleColor.Green));
    }

    public void MoveSnake(MoveDirection movement)
    {
        switch (movement)
        {
            case MoveDirection.Up:
                Head.PositionY--;
                break;
            case MoveDirection.Down:
                Head.PositionY++;
                break;
            case MoveDirection.Left:
                Head.PositionX--;
                break;
            case MoveDirection.Right:
                Head.PositionX++;
                break;
        }
    }

    public void UpdateSnakeBodyByScore(int score)
    {
        if (Body.Count > score)
        {
            Body.RemoveAt(0);
        }
    }
}