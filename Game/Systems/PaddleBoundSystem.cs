using System.Collections.Generic;
using Microsoft.Xna.Framework;

public sealed class PaddleBoundsSystem : IUpdateSystem
    {
        private readonly int _screenHeight;

        public PaddleBoundsSystem(int screenHeight)
        {
            _screenHeight = screenHeight;
        }

        public void Update(GameTime gameTime, IReadOnlyList<Entity> entities)
        {
            foreach (var e in entities)
            {
                // Only care about paddles
                if (!e.TryGetComponent<TagComponent>(out var tags) ||
                    !tags.Tag.HasFlag(Tags.Player | Tags.Player2))
                    continue;

                if (!e.TryGetComponent<TransformComponent>(out var transform))
                    continue;

                if (!e.TryGetComponent<ColliderComponent>(out var collider))
                    continue;

                // Get paddle half-height from collider
                float halfHeight = collider.Collider.Height / 2f;

                float y = transform.Position.Y;
                bool clamped = false;

                // Top edge
                if (y - halfHeight < 0f)
                {
                    y = halfHeight;
                    clamped = true;
                }

                // Bottom edge
                if (y + halfHeight > _screenHeight)
                {
                    y = _screenHeight - halfHeight;
                    clamped = true;
                }

                if (clamped)
                {
                    // Apply the clamped position
                    transform.Position = new Vector2(transform.Position.X, y);

                    // Optional: stop vertical movement so they don't "vibrate" at edge
                    if (e.TryGetComponent<VelocityComponent>(out var vel))
                    {
                        vel.Velocity = new Vector2(vel.Velocity.X, 0f);
                    }
                }
            }
        }
    }