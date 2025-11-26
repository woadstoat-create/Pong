using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class TextureRenderer : Component
{
    private string _loc;
    private Texture2D _texture;
    private Vector2 _position, _origin, _scale;
    private float _rotation, _layer, _alpha;
    private Rectangle _sourceRect;
    private Color _color;
    private SpriteEffects _effect;
    private Transform _transformReference;

    public TextureRenderer(Entity parent) : base(parent)
    {
        _position = new Vector2();
        _scale = new Vector2();
        _color = Color.White;
        _effect = SpriteEffects.None;
        _alpha = 1;
        _layer = 1;
    }

    public TextureRenderer(Entity parent, string loc) : this(parent)
    {
        _loc = loc;
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Load(ContentManager content)
    {
        _texture = content.Load<Texture2D>(_loc);
        _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        _sourceRect = new Rectangle(0, 0, _texture.Width, _texture.Height);
        base.Load(content);
    }

    public override void Update(GameTime dt)
    {

        if (_isActive)
        {  
            _transformReference = _parent.GetComponent<Transform>();
            if (_transformReference != null && 
                (_position != _transformReference.Position || 
                _scale != _transformReference.Scale || 
                _rotation != _transformReference.Rotation))
            {
                _position = _transformReference.Position;
                _scale = _transformReference.Scale;
                _rotation = _transformReference.Rotation;
            }
        }
        
        base.Update(dt);
    }

    public override void Draw(SpriteBatch sb)
    {
        if (_isVisible)
        {
            sb.Draw(_texture, _position, _sourceRect, _color * _alpha, _rotation, _origin, _scale, _effect, _layer);
        }
        base.Draw(sb);
    }
}