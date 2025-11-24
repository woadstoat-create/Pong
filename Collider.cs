

using Microsoft.Xna.Framework;

public class Collider
{
    private Rectangle _rect;

    public Rectangle Rect
    {
        get { return _rect; }
    }

    public Collider()
    {
        
    }

    public void Initialize(int x, int y, int w, int h)
    {
        _rect = new Rectangle(x, y, w, h);
    }

    public void Update(Vector2 pos)
    {
        _rect.X = (int)pos.X;
        _rect.Y = (int)pos.Y;
    }

    public bool IsCollision(Collider other)
    {
        return _rect.Intersects(other.Rect);
    }


}