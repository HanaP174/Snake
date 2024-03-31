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
}