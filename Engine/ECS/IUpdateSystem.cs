using System.Collections.Generic;
using Microsoft.Xna.Framework;

public interface IUpdateSystem
{
    void Update(GameTime dt, IReadOnlyList<Entity> entities);
}