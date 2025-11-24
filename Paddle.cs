using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Paddle
{
    public enum Type
    {
        Player1,
        Player2,
        AI,
    }

    private Type _type;
    private Texture2D _texture;
    private Vector2 _position;
    private PlayerController _controller;
    private Collider _collider;
    private Vector2 _origin;
    // Stats
    private float _speed = 150;

    public Collider Collider
    {
        get { return _collider; }
    }

    public Paddle(int x, int y, Type type)
    {
        _type = type;
        _position = new Vector2(x, y);
        _controller = new PlayerController();
        _collider = new Collider();
    }

    public void Initialize()
    {
        _collider.Initialize((int)_position.X - 16, (int)_position.Y - 64, 32, 128);
    }

    public void Load(ContentManager content, string loc)
    {
        _texture = content.Load<Texture2D>(loc);
        _origin = new Vector2(_texture.Width/2, _texture.Height/2);
    }

    public void Update(GameTime dt, Ball ball)
    {
        _controller.Update();
        if (_type == Type.Player1)
        {
            if (_controller.IsKeyPressed(Keys.W))
            {
                _position.Y -= _speed * (float)dt.ElapsedGameTime.TotalSeconds;
            }
            else if (_controller.IsKeyPressed(Keys.S))
            {
                _position.Y += _speed * (float)dt.ElapsedGameTime.TotalSeconds;
            }
        }
        else if (_type == Type.Player2)
        {
            if (_controller.IsKeyPressed(Keys.Up))
            {
                _position.Y -= _speed * (float)dt.ElapsedGameTime.TotalSeconds;
            }
            else if (_controller.IsKeyPressed(Keys.Down))
            {
                _position.Y += _speed * (float)dt.ElapsedGameTime.TotalSeconds;
            }
        }
        else if (_type == Type.AI)
        {
            if (ball.Position.Y < _position.Y)
            {
                _position.Y -= _speed * (float)dt.ElapsedGameTime.TotalSeconds;
            }
            else if (ball.Position.Y > _position.Y)
            {
                _position.Y += _speed * (float)dt.ElapsedGameTime.TotalSeconds;
            }
        }

        if (_position.Y > 480 - _origin.Y)
        {
            _position.Y = 480 - _origin.Y;
        }
        else if (_position.Y < 0 + _origin.Y)
        {
            _position.Y = 0 + _origin.Y;
        }

        _collider.Update(_position - _origin);
        _controller.LateUpdate();
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, _position, null, Color.White, 0, _origin, 1, SpriteEffects.None, 1);
    }
}