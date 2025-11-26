using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public abstract class Component
{
    protected bool _isActive, _isVisible;
    protected Entity _parent;

    public Component(Entity parent)
    {
        _parent = parent;
        _isActive = true;
        _isVisible = true;
    }

    public Component(Entity parent, bool active, bool visible)
    {
        _parent = parent;
        _isActive = active;
        _isVisible = visible;
    }

    public virtual void Initialize()
    {
        
    }

    public virtual void Load(ContentManager content)
    {
        
    }

    public virtual void Update(GameTime dt)
    {
        
    }

    public virtual void Draw(SpriteBatch sb)
    {
        
    }
}