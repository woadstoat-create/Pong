using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class Entity
{
    private List<Component> _components;

    public Entity()
    {
        
    }

    public void Initialize()
    {
        
    }

    public void Load(ContentManager content)
    {
        
    }

    public void Update(GameTime dt)
    {
        
    }

    public void Draw(SpriteBatch sb)
    {
        
    }

    public T GetComponent<T>() where T : Component
    {
        foreach (Component component in _components)
        {
            if (component.GetType().Equals(typeof(T)))
            {
                return (T)component;
            }
        }

        return null;
    }
}