namespace Snake;
using static System.Console;

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

    public static void Draw(Pixel pixel)
    {
        SetCursorPosition(pixel.PositionX, pixel.PositionY);
        ForegroundColor = pixel.ScreenColor;
        Write("■");
    }
}