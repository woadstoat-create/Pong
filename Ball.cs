using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Ball
{
    private Texture2D _texture;
    private Vector2 _position;
    private Collider _collider;
    private Vector2 _speed = new Vector2(100, 50);
    private float _speedMultiplier = 1.0f; 
    private Vector2 _origin;

    private SoundEffect _bumpSound;

    public Vector2 Position
    {
        get { return _position; }
    }

    public Ball()
    {
        _collider = new Collider();
    }

    public void Initialize()
    {
        _position = new Vector2(400, 240);
        _collider.Initialize((int)_position.X, (int)_position.Y, 32, 32);
    }

    public void Load(ContentManager content, string loc)
    {
        _texture = content.Load<Texture2D>(loc);
        _bumpSound = content.Load<SoundEffect>("audio/bump");
        _origin = new Vector2(_texture.Width/2, _texture.Height/2);
    }

    public void Update(GameTime dt, Paddle paddle1, Paddle paddle2)
    {
        if (_collider.IsCollision(paddle1.Collider) || _collider.IsCollision(paddle2.Collider))
        {
            _speed.X *= -1;
            _bumpSound.Play();
        }    
        else if (_position.Y <= 0 + _origin.X || _position.Y >= 480 - _origin.Y)
        {
            _speed.Y *= -1;
            _speedMultiplier += 0.2f;
            _bumpSound.Play();
        }

        _position += _speed * _speedMultiplier * (float)dt.ElapsedGameTime.TotalSeconds;
        _collider.Update(_position - _origin);
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(_texture, 
        _position, 
        null, 
        Color.White, 
        0, 
        _origin, 
        1, 
        SpriteEffects.None, 
        1);
    }


}