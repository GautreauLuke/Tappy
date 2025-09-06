using Godot;
using System;

public partial class Game : Node2D
{
	private static readonly PackedScene MAIN_SCENE = GD.Load<PackedScene>("res://Scenes/Main/main.tscn");
	private static readonly PackedScene GAME_SCENE = GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");


	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;
	// [Export] private Node2D _pipesHolder;
	[Export] private Timer _spawnTimer; 
	[Export] private PackedScene _pipesScene;
	[Export] private Plane _plane;
	[Export] private AudioStreamPlayer2D _music;
	[Export] private Label _gameOverLabel;

	bool IsGameOver = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_spawnTimer.Timeout += SpawnPipes;
		SignalManager.Instance.OnPlaneDied += GameOver;

		ScoreManager.ResetScore(); 

		SpawnPipes();
		// GD.Print($"{GetSpawnY()}");
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= GameOver;
	}


	public void StopPipes()
	{
		_spawnTimer.Stop();
		// foreach (Pipes pipe in _pipesHolder.GetChildren())
		// {
		// 	pipe.SetProcess(false);
		// }
	}

	public void GameOver()
	{
		GD.Print("GameOver");
		StopPipes();
		IsGameOver = true;
		_music.Stop();
		_gameOverLabel.Visible = true;
	}

	private void SpawnPipes()
	{
		Pipes np = _pipesScene.Instantiate<Pipes>();
		// _pipesHolder.AddChild(np);
		AddChild(np);
		np.GlobalPosition = new Vector2(_spawnLower.Position.X, GetSpawnY());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("fly") && IsGameOver == true)
		{
			// GetTree().ChangeSceneToPacked(GAME_SCENE);
			GameManager.LoadGame();
		}

		// if (Input.IsKeyPressed(Key.Q))
		// {
		// 	GetTree().ChangeSceneToPacked(MAIN_SCENE);
		// }

		if (Input.IsKeyPressed(Key.R) && IsGameOver == true)
		{
			// GetTree().ChangeSceneToPacked(MAIN_SCENE);
			GameManager.LoadMain();
		}
	}

	public float GetSpawnY()
	{
		return (float)GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
	}
}
