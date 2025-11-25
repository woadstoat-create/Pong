using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class GameScene : Scene
{
    private Paddle _player1;
    private Paddle _player2;
    private Ball _ball;
    private int _p1Score = 0;
    private int _p2Score = 0;
    private UI_Text _scoreText; 

    public GameScene() : base(1, "GameScene")
    {
        _player1 = new Paddle(64, 240, Paddle.Type.Player1);
        _player2 = new Paddle(800 - 64, 240, Paddle.Type.AI);
        _ball = new Ball();
        _scoreText = new UI_Text(_p1Score.ToString() + " : " + _p2Score.ToString(), "ScoreFont", 400, 60, Color.White);
    }

    public override void Initialize()
    {
        _ball.Initialize();
        _player1.Initialize();
        _player2.Initialize();
    
        base.Initialize();
    }

    public override void Load(ContentManager content)
    {
        _player1.Load(content, "Sprites/Paddle");
        _player2.Load(content, "Sprites/Paddle");
        _ball.Load(content, "Sprites/Ball");
        _scoreText.Load(content);
        base.Load(content);
    }

    public override void Unload()
    {
        base.Unload();
    }

    public override void Update(GameTime dt)
    {
        _player1.Update(dt, _ball);
        _player2.Update(dt, _ball);
        _ball.Update(dt, _player1, _player2);

        if (_ball.Position.X > 800)
        {
            _p1Score++;
            _ball.ResetBall();
        }
        else if (_ball.Position.X < 0)
        {
            _p2Score++;
            _ball.ResetBall();
        }

        _scoreText.Text = _p1Score.ToString() + " : " + _p2Score.ToString();

        base.Update(dt);
    }

    public override void Draw(SpriteBatch sb)
    {
        _player1.Draw(sb);
        _player2.Draw(sb);
        _ball.Draw(sb);
        _scoreText.Draw(sb);

        base.Draw(sb);
    }
}