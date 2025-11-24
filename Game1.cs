using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Paddle player1;
    Paddle player2;
    Ball ball;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        player1 = new Paddle(64, 240, Paddle.Type.Player1);
        player2 = new Paddle(800 - 64, 240, Paddle.Type.AI);
        ball = new Ball();

        ball.Initialize();
        player1.Initialize();
        player2.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        player1.Load(Content, "Sprites/Paddle");
        player2.Load(Content, "Sprites/Paddle");
        ball.Load(Content, "Sprites/Ball");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player1.Update(gameTime, ball);
        player2.Update(gameTime, ball);
        ball.Update(gameTime, player1, player2);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        player1.Draw(_spriteBatch);
        player2.Draw(_spriteBatch);
        ball.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
