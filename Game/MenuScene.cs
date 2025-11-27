using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public sealed class MenuScene : Scene
{
    private readonly SceneManager _sceneManager;
    private SpriteFont _font;

    private KeyboardState _previousKeyboardState;

    private const string TitleText = "PONG";
    private const string PromptText = "Press Enter to Start";

    public MenuScene(Game game, SceneManager sceneManager) : base(game)
    {
        _sceneManager = sceneManager;
    }

    public override void LoadContent()
    {
        _font = Content.Load<SpriteFont>("Fonts/MainFont");
    }

    public override void Update(GameTime gt)
    {
        var kb = Keyboard.GetState();

        if (kb.IsKeyDown(Keys.Enter) && !_previousKeyboardState.IsKeyDown(Keys.Enter))
        {
            _sceneManager.ChangeScene(SceneId.Play);
        }

        _previousKeyboardState = kb;
    }

    public override void Draw(GameTime gt, SpriteBatch sb)
    {
        var vp = GraphicsDevice.Viewport;

        float centerX = vp.Width / 2f;
        float centerY = vp.Height / 2f;

        var titleSize = _font.MeasureString(TitleText);
        var promptSize = _font.MeasureString(PromptText);

        var titlePos = new Vector2(
            centerX - titleSize.X / 2f,
            centerY * 0.5f
        );

        var promptPos = new Vector2(
            centerX - promptSize.X / 2f,
            centerY * 1.1f
        );

        sb.DrawString(_font, TitleText,  titlePos,  Color.White);
        sb.DrawString(_font, PromptText, promptPos, Color.White);

        base.Draw(gt, sb);
    }
}