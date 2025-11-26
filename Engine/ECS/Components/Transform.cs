using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Transform : Component
{
    private Vector2 _position;
    private Vector2 _scale;
    private float _rotation; 

    public Vector2 Position
    {
        get
        {
            return _position;
        }
    }

    public Vector2 Scale
    {
        get
        {
            return _scale;
        }
    }

    public float Rotation
    {
        get
        {
            return _rotation;
        }
    }

    public float X
    {
        get
        {
            return _position.X;
        }
    }

    public float Y
    {
        get
        {
            return _position.Y;
        }
    }

    public Transform(Entity parent) : base(parent)
    {
        
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Load(ContentManager content)
    {
        base.Load(content);
    }

    public override void Update(GameTime dt)
    {
        base.Update(dt);
    }

    public override void Draw(SpriteBatch sb)
    {
        base.Draw(sb);
    }

    
}