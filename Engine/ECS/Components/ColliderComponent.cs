using Microsoft.Xna.Framework;

public sealed class ColliderComponent : IComponent
{
    public Rectangle Collider;
    public bool IsTrigger;
}