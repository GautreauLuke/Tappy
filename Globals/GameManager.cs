using Godot;
using System;

public partial class GameManager : Node
{
    private PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main/main.tscn");
    private PackedScene _gameScene = GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");

    public static GameManager Instance { get; private set; }
    public override void _Ready()
    {
        Instance = this;
    }

    public static void LoadMain()
    {
        Instance.GetTree().ChangeSceneToPacked(Instance._mainScene);
    }
    public static void LoadGame()
    {
        Instance.GetTree().ChangeSceneToPacked(Instance._gameScene);
    }
}

//GameManager.LoadMain();
