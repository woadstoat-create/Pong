using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class MenuScene : Scene
{
    private UI_Text _titleText;
    private PlayerController _controller;

    public MenuScene() : base(0, "MenuScene")
    {
        _titleText = new UI_Text("PONG", "ScoreFont", 400, 80, Color.White);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Load(ContentManager content)
    {
        _titleText.Load(content);
        base.Load(content);
    }

    public override void Unload()
    {
        base.Unload();
    }

    public override void Update(GameTime dt)
    {
        _controller.Update();

        if (_controller.IsKeyPressed(Keys.Enter))
        {
            SceneManager.Instance.SetCurrentScene("GameScene");
        }

        _controller.LateUpdate();
        base.Update(dt);
    }

    public override void Draw(SpriteBatch sb)
    {
        _titleText.Draw(sb);
        base.Draw(sb);
    }
}