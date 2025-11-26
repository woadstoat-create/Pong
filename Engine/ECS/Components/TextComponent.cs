using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public sealed class TextComponent : IComponent
{
    public string Text = "";
    public SpriteFont Font;
    public Color Color = Color.White;
}