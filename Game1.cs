using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;



    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        
        SceneManager.Instance.AddScene("MenuScene", new MenuScene());
        SceneManager.Instance.AddScene("GameScene", new GameScene());
        SceneManager.Instance.SetCurrentScene("MenuScene");
    }

    protected override void Initialize()
    {
        SceneManager.Instance.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        SceneManager.Instance.Load(Content);
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        SceneManager.Instance.Update(gameTime);
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        SceneManager.Instance.Draw(_spriteBatch);      

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
