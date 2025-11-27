using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

public sealed class PongAISystem : IUpdateSystem
{
    public void Update(GameTime gt, IReadOnlyList<Entity> entities)
    {
        TransformComponent ballTransform = null;
        VelocityComponent ballVelocity = null;

        foreach (var e in entities)
        {
            if (e.TryGetComponent<TagComponent>(out var tags) &&
                tags.Tag.HasFlag(Tags.Ball) && 
                e.TryGetComponent<TransformComponent>(out var t) &&
                e.TryGetComponent<VelocityComponent>(out var v))
            {
                ballTransform = t;
                ballVelocity = v;
                break;
            }
        }

        if (ballTransform == null || ballVelocity == null)
            return;

        foreach (var e in entities)
        {
            if (!e.TryGetComponent<AIPaddleComponent>(out var ai))
                    continue;

            if (!e.TryGetComponent<TransformComponent>(out var transform))
                continue;

            if (!e.TryGetComponent<VelocityComponent>(out var velocity))
                continue;

            if (ai.OnlyTrackWhenBallComingTowards)
            {
                bool ballMovingRight = ballVelocity.Velocity.X > 0f;
                bool paddleOnRight = transform.Position.X > ballTransform.Position.X;

                if (paddleOnRight && !ballMovingRight)
                {
                    velocity.Velocity = Vector2.Zero;
                    continue;
                }

                if (!paddleOnRight && ballMovingRight)
                {
                    velocity.Velocity = Vector2.Zero;
                    continue;
                }
            }

            float targetY = ballTransform.Position.Y;
            Random rng = new Random();

            if (Math.Abs(ai.AimErrorAmplitude) > float.Epsilon)
            {
                targetY += (float)(rng.NextDouble() * (ai.AimErrorAmplitude - -ai.AimErrorAmplitude) + -ai.AimErrorAmplitude);
            }

            float dy = targetY - transform.Position.Y;

            if (Math.Abs(dy) <= ai.DeadZone)
            {
                velocity.Velocity = Vector2.Zero;
                continue;
            }

            float dirY = Math.Sign(dy);
            velocity.Velocity = new Vector2(0f, dirY * ai.MoveSpeed);
        }
        
    }
}