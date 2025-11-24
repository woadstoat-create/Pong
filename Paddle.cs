using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Paddle
{
    private Texture2D _texture;
    private Vector2 _position;
    private PlayerController _controller;
    private Collider _collider;

    // Stats
    private float _speed = 10;

    public Collider Collider
    {
        get { return _collider; }
    }

    public Paddle()
    {
        
    }

    public void Initialize()
    {
        
    }

    public void Load(ContentManager content, string loc)
    {
        content.Load<Texture2D>("");
    }

    public void Update(GameTime dt)
    {
        _controller.Update();

        if (_controller.IsKeyPressed(Keys.W))
        {
            _position.Y -= _speed * (float)dt.ElapsedGameTime.TotalSeconds;
        }
        else if (_controller.IsKeyPressed(Keys.S))
        {
            _position.Y += _speed * (float)dt.ElapsedGameTime.TotalSeconds;
        }
        _collider.Update(_position);
        _controller.LateUpdate();
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, Color.White);
    }
}