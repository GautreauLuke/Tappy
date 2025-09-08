using Godot;
using System;

public partial class GameManager : Node
{
    public const float SCROLL_SPEED = 120.0f;

    private PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main/main.tscn");
    private PackedScene _gameScene = GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");
    private PackedScene _simpleTransitionScene =
            GD.Load<PackedScene>("res://Scenes/SimpleTransitions/simple_transition.tscn");


    private PackedScene _nextScene;

    public static GameManager Instance { get; private set; }
    public override void _Ready()
    {
        Instance = this;
    }

    public static PackedScene GetNextScene()
    {
        return Instance._nextScene;
    }

    private void LoadNextScene(PackedScene ns)
    {
        _nextScene = ns;
        Instance.GetTree().ChangeSceneToPacked(Instance._simpleTransitionScene);
    }

    public static void LoadMain()
    {
        //Instance.GetTree().ChangeSceneToPacked(Instance._mainScene);
        Instance.LoadNextScene(Instance._mainScene);
    }
    public static void LoadGame()
    {
        //Instance.GetTree().ChangeSceneToPacked(Instance._gameScene);
        Instance.LoadNextScene(Instance._gameScene);
    }
}

//GameManager.LoadMain();
