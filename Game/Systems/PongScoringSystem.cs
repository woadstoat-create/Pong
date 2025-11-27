using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public sealed class PongScoringSystem : IUpdateSystem
{
    private readonly int _screenWidth;
    private readonly int _screenHeight;

    public PongScoringSystem(int screenWidth, int screenHeight)
    {
        _screenWidth = screenWidth;
        _screenHeight = screenHeight;
    }

    public void Update(GameTime gt, IReadOnlyList<Entity> entities)
    {
        Entity ballEntity = null;
        TransformComponent ballTransform = null;
        VelocityComponent ballVelocity = null;
        ColliderComponent ballCollider = null;

        ScoreComponent score = null;

        foreach (var e in entities)
        {
            if (score == null && e.TryGetComponent<ScoreComponent>(out var s))
                score = s;

            if (ballEntity == null &&
                e.TryGetComponent<TagComponent>(out var tag) &&
                tag.Tag.HasFlag(Tags.Ball) &&
                e.TryGetComponent<TransformComponent>(out var t) &&
                e.TryGetComponent<VelocityComponent>(out var v) &&
                e.TryGetComponent<ColliderComponent>(out var c))
            {
                ballEntity = e;
                ballTransform = t;
                ballVelocity = v;
                ballCollider = c;
            }

            if (score != null && ballEntity != null)
                break;
        }

        if (ballEntity == null || score == null)
            return;
   
        if (ballCollider.Collider.Right < 0)
        {
            score.RightScore++;
            PlayScoreSound(ballEntity);
            ResetBall(ballTransform, ballVelocity, toLeft: false);
        }
        else if (ballCollider.Collider.Left > _screenWidth)
        {
            score.LeftScore++;
            PlayScoreSound(ballEntity);
            ResetBall(ballTransform, ballVelocity, toLeft: true);
        }
    }

    private void ResetBall(TransformComponent transform, VelocityComponent velocity, bool toLeft)
    {
        // Centre of screen
        transform.Position = new Vector2(_screenWidth / 2f, _screenHeight / 2f);

        // Basic speed
        float speed = 250f;

        Random rng = new Random();

        // Random slight vertical angle so it’s not perfectly flat every time
        float angleY = (float)rng.NextDouble() * (0.5f - 0.5f) + -0.5f;

        var dir = new Vector2(toLeft ? -1f : 1f, angleY);
        dir.Normalize();

        velocity.Velocity = dir * speed;
        velocity.Multiplier = 1.0f;
    }

    private void PlayScoreSound(Entity ballEntity)
    {
        if (ballEntity.TryGetComponent<BallAudioComponent>(out var audio) &&
            audio.ScoreSound != null)
        {
            audio.ScoreSound.Play();
        }
    }
}