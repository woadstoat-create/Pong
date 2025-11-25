using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class UI_Text
{
    private string _text;
    private string _fontName;
    private SpriteFont _font;
    private Vector2 _position;
    private Color _color;
    private Vector2 _origin;

    public string Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
            _origin = new Vector2(_font.MeasureString(_text).X, _font.MeasureString(_text).Y);
        }
    }

    public UI_Text(string text, string fontName, int x, int y, Color color)
    {
        _text = text;
        _fontName = fontName;
        _position = new Vector2(x, y);
        _color = color;
    }

    public void Initialize()
    {
        
    }

    public void Load(ContentManager content)
    {
        _font = content.Load<SpriteFont>("Fonts/" + _fontName);
        _origin = new Vector2(_font.MeasureString(_text).X, _font.MeasureString(_text).Y);
    }

    public void Update(GameTime dt)
    {
        
    }

    public void Draw(SpriteBatch sb)
    {
        sb.DrawString(_font, _text, _position, _color, 0, _origin, 1, SpriteEffects.None, 1);
    }

}