using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GameScene : EcsScene
{
    public GameScene(Game game) : base(game)
    {
        
    }

    protected override void ConfigureSystems()
    {
        updateSystems.Add(new PlayerInputSystem());
        updateSystems.Add(new PongAISystem());
        updateSystems.Add(new MovementSystem());
        updateSystems.Add(new ColliderSyncSystem());
        updateSystems.Add(new PongCollisionSystem());
        updateSystems.Add(new PongScoringSystem(
            GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height
        ));
        updateSystems.Add(new PaddleBoundsSystem(GraphicsDevice.Viewport.Height));
        updateSystems.Add(new ScoreUiSystem());
        drawSystems.Add(new RenderSystem());
        drawSystems.Add(new TextRenderSystem());
    }

    public override void LoadContent()
    {
        base.LoadContent();

        var player1 = new Entity();
        Texture2D paddleTex = Content.Load<Texture2D>("Sprites/Paddle");
        player1.AddComponent(new SpriteComponent{
            Texture = paddleTex, 
            Color = Color.White,
            Origin = new Vector2(paddleTex.Width / 2, paddleTex.Height / 2),
        });
        player1.AddComponent(new VelocityComponent {Velocity = new Vector2(0,0)});
        player1.AddComponent(new TransformComponent { Position = new Vector2(64, 240)}); 
        player1.AddComponent(new ColliderComponent {Collider = new Rectangle(0, 0, 32, 128), IsTrigger = false});
        player1.AddComponent(new TagComponent { Tag = Tags.Player });
        player1.AddComponent(new InputComponent { UpKey = Keys.W, DownKey = Keys.S, MoveSpeed = 300, VerticalOnly = true });
        entities.Add(player1);

        var player2 = new Entity();
        player2.AddComponent(new SpriteComponent{
            Texture = paddleTex, 
            Color = Color.White,
            Origin = new Vector2(paddleTex.Width / 2, paddleTex.Height / 2),
        });
        player2.AddComponent(new VelocityComponent {Velocity = new Vector2(0,0)});
        player2.AddComponent(new TransformComponent { Position = new Vector2(800 - 64, 240)}); 
        player2.AddComponent(new ColliderComponent {Collider = new Rectangle(0, 0, 32, 128), IsTrigger = false});
        player2.AddComponent(new TagComponent { Tag = Tags.Player2 });
        player2.AddComponent(new AIPaddleComponent { });
        entities.Add(player2);

        var ball = new Entity();
        Texture2D ballTex = Content.Load<Texture2D>("Sprites/Ball");
        ball.AddComponent(new SpriteComponent{
            Texture = ballTex, 
            Color = Color.White,
            Origin = new Vector2(ballTex.Width / 2, ballTex.Height / 2),
        });
        ball.AddComponent(new VelocityComponent {Velocity = new Vector2(20,20)});
        ball.AddComponent(new TransformComponent { Position = new Vector2(800 / 2, 480 / 2)}); 
        ball.AddComponent(new ColliderComponent {Collider = new Rectangle(0, 0, 32, 32), IsTrigger = false});
        ball.AddComponent(new TagComponent { Tag = Tags.Ball });
        var paddleSfx = Content.Load<SoundEffect>("Audio/PaddleHit");
        var wallSfx = Content.Load<SoundEffect>("Audio/WallHit");
        var scoreSfx = Content.Load<SoundEffect>("Audio/ScoreFX");
        ball.AddComponent(new BallAudioComponent
        {
            PaddleHitSound = paddleSfx,
            WallHitSound = wallSfx,
            ScoreSound = scoreSfx
        });

        entities.Add(ball);

        var gameState = new Entity();
        gameState.AddComponent(new ScoreComponent());
        gameState.AddComponent(new TagComponent { Tag = Tags.UI });
        entities.Add(gameState);

        SpriteFont scoreFont = Content.Load<SpriteFont>("Fonts/ScoreFont");

        var leftScoreUi = new Entity();
        leftScoreUi.AddComponent(new TextComponent
        {
            Font = scoreFont,
            Color = Color.White,
            Text = "0"
        });
        leftScoreUi.AddComponent(new TransformComponent {Position = new Vector2(GraphicsDevice.Viewport.Width / 4, 50) , Rotation = 0, Scale = new Vector2(1, 1)});
        leftScoreUi.AddComponent(new TagComponent { Tag = Tags.UI | Tags.Player});
        entities.Add(leftScoreUi);

        var rightScoreUi = new Entity();
        rightScoreUi.AddComponent(new TextComponent
        {
            Font = scoreFont,
            Color = Color.White,
            Text = "0"
        });
        rightScoreUi.AddComponent(new TransformComponent {Position = new Vector2(GraphicsDevice.Viewport.Width * 3 / 4, 50) , Rotation = 0, Scale = new Vector2(1, 1)});
        rightScoreUi.AddComponent(new TagComponent { Tag = Tags.UI | Tags.Player2});
        entities.Add(rightScoreUi);
    }

    public override void UnloadContent()
    {
        base.UnloadContent();
    }
}