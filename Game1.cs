using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private SceneManager _sceneManager;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        
   }

    protected override void Initialize()
    {
        _sceneManager = new SceneManager();

        //_sceneManager.AddScene(SceneId.MainMenu, new MenuScene(this));
        _sceneManager.AddScene(SceneId.Play, new GameScene(this));

        _sceneManager.ChangeScene(SceneId.Play);
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        
        
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        _sceneManager.Update(gameTime);
        

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        _sceneManager.Draw(gameTime, _spriteBatch);     

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
