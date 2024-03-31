namespace Snake;

public class Pixel
{
    public Pixel(int positionX, int positionY, ConsoleColor screenColor)
    {
        PositionX = positionX;
        PositionY = positionY;
        ScreenColor = screenColor;
    }

    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public ConsoleColor ScreenColor { get; set; }
}