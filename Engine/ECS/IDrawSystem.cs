using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

public interface IDrawSystem
{
    void Draw(SpriteBatch sb, IReadOnlyList<Entity> entities);
}