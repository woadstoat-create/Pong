using Microsoft.Xna.Framework.Input;

public class PlayerController
{
    private KeyboardState _currKb, _prevKb;

    public PlayerController()
    {
        
    }

    public void Initialize()
    {
        
    }

    public void Update()
    {
        _currKb = Keyboard.GetState();
    }

    public void LateUpdate()
    {
        _prevKb = _currKb;
    }

    public bool IsKeyPressed(Keys key)
    {
        return _currKb.IsKeyDown(key);
    }
}