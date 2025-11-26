using System.Collections.Generic;
using Microsoft.Xna.Framework;

public sealed class ScoreUiSystem : IUpdateSystem
    {
        public void Update(GameTime gameTime, IReadOnlyList<Entity> entities)
        {
            ScoreComponent score = null;
            Entity leftUi = null;
            Entity rightUi = null;

            // Find score + UI entities
            foreach (var e in entities)
            {
                if (score == null && e.TryGetComponent<ScoreComponent>(out var s))
                    score = s;

                if (e.TryGetComponent<TagComponent>(out var tags) &&
                    tags.Tag.HasFlag(Tags.UI))
                {
                    // crude example: use Player vs Enemy tags to distinguish
                    if (tags.Tag.HasFlag(Tags.Player))
                        leftUi = e;
                    else if (tags.Tag.HasFlag(Tags.Player2))
                        rightUi = e;
                }

                if (score != null && leftUi != null && rightUi != null)
                    break;
            }

            if (score == null)
                return;

            if (leftUi != null && leftUi.TryGetComponent<TextComponent>(out var leftText))
            {
                leftText.Text = score.LeftScore.ToString();
            }

            if (rightUi != null && rightUi.TryGetComponent<TextComponent>(out var rightText))
            {
                rightText.Text = score.RightScore.ToString();
            }
        }
    }