using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Ball
{
    private Texture2D _texture;
    private Vector2 _position;
    private Collider _collider;
    private Vector2 _speed = new Vector2(10, 1);
    private float _speedMultiplier = 1.0f; 

    public Ball()
    {
        
    }

    public void Initialize()
    {
        _position = new Vector2(400, 240);
    }

    public void Load(ContentManager content)
    {
        content.Load<Texture2D>("");
    }

    public void Update(GameTime dt, Paddle paddle1, Paddle paddle2)
    {
        if (_collider.IsCollision(paddle1.Collider) || _collider.IsCollision(paddle2.Collider))
        {
            _speed.X *= -1;
        }    
        else if (_position.Y <= 0 || _position.Y >= 480)
        {
            _speed.Y *= -1;
            _speedMultiplier += 0.2f;
        }

        _position += _speed * _speedMultiplier * (float)dt.ElapsedGameTime.TotalSeconds;
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, 
        _position, 
        null, 
        Color.White, 
        0, 
        new Vector2(_texture.Width/2, _texture.Height/2), 
        1, 
        SpriteEffects.None, 
        1);
    }


}