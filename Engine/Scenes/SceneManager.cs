using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class SceneManager
{
    private static SceneManager _instance;
    public static SceneManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SceneManager();
            }
            return _instance;
        }
    }
    
    private Dictionary<string, Scene> _scenes;
    private Scene _currentScene;

    private ContentManager _content;

    public SceneManager()
    {
        _scenes = new Dictionary<string, Scene>();    
    }

    public void Initialize()
    {
        if (_currentScene != null)
        {
            _currentScene.Initialize();   
        }
    }

    public void Load(ContentManager content)
    {
        _content = content;
        if (_currentScene != null)
        {
            _currentScene.Load(_content);   
        }
    }

    public void Unload()
    {
        
    }

    public void Update(GameTime dt)
    {
        if (_currentScene != null && _currentScene.IsLoaded)
        {
            _currentScene.Update(dt);
        }
    }

    public void Draw(SpriteBatch sb)
    {
        if (_currentScene != null && _currentScene.IsLoaded)
        {
            _currentScene.Draw(sb);
        }
    }

    public void AddScene(string name, Scene scene)
    {
        _scenes.Add(name, scene);
    }

    public void RemoveScene(string name)
    {
        _scenes.Remove(name);
    }

    public void SetCurrentScene(string name)
    {
        if (_currentScene != null)
        {
            _currentScene.Unload();
            _currentScene = _scenes[name];
            _currentScene.Load(_content);
        }
        else
        {
            _currentScene = _scenes[name];
        }
    }
}