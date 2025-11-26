using System.Collections.Generic;
using Microsoft.Xna.Framework;

public sealed class PongCollisionSystem : IUpdateSystem
{
    public void Update(GameTime gt, IReadOnlyList<Entity> entities)
    {
        Entity ballEntity = null;
        ColliderComponent ballCollider = null;
        VelocityComponent ballVelocity = null;

        foreach (var e in entities)
        {
            if (e.TryGetComponent<TagComponent>(out var tag) &&
                tag.Tag.HasFlag(Tags.Ball) &&
                e.TryGetComponent<ColliderComponent>(out var c) &&
                e.TryGetComponent<VelocityComponent>(out var v))
            {
                ballEntity = e;
                ballCollider = c;
                ballVelocity = v;
                break;
            }
        }

        if (ballEntity == null)
                return;

        foreach (var e in entities)
        {
            if (e == ballEntity)
                continue;

            if (!e.TryGetComponent<ColliderComponent>(out var otherCollider))
                continue;

            if (ballCollider.Collider.Intersects(otherCollider.Collider))
            {
                ballVelocity.Velocity = new Vector2(-ballVelocity.Velocity.X, ballVelocity.Velocity.Y);
                break;
            }
        }

        if (ballCollider.Collider.Y < 16 || ballCollider.Collider.Y > 480 - 16)
        {
            ballVelocity.Velocity = new Vector2(ballVelocity.Velocity.X, -ballVelocity.Velocity.Y);
        }
    }
}