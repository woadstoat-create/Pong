using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class EntityManager
{
    private List<Entity> _entities = new List<Entity>();

    public EntityManager()
    {
        
    }

    public void Initialize()
    {
        foreach (Entity e in _entities)
        {
            e.Initialize();
        }
    }

    public void Load(ContentManager content)
    {
        foreach (Entity e in _entities)
        {
            e.Load(content);
        }
    }

    public void Update(GameTime dt)
    {
        foreach (Entity e in _entities)
        {
            e.Update(dt);
        }
    }

    public void Draw(SpriteBatch sb)
    {
        foreach (Entity e in _entities)
        {
            e.Draw(sb);
        }
    }

    public void Add(Entity e)
    {
        _entities.Add(e);
    }

    public void Remove(Entity e)
    {
        _entities.Remove(e);
    }
}