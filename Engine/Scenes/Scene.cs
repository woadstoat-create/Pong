using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public abstract class Scene
{
    protected int _id;
    protected string _name;
    public bool IsLoaded = false;

    public Scene(int id, string name)
    {
        _id = id;
        _name = name;
    }

    public virtual void Initialize()
    {
        
    }

    public virtual void Load(ContentManager content)
    {
        IsLoaded = true;
    }

    public virtual void Unload()
    {
        
    }

    public virtual void Update(GameTime dt)
    {
        
    }

    public virtual void Draw(SpriteBatch sb)
    {
        
    }
}