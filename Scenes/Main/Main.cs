using Godot;
using System;

public partial class Main : Control
{
	[Export] private Label _highScoreLabel;

	private static readonly PackedScene GAME_SCENE =
				GD.Load<PackedScene>("res://Scenes/Game/Game.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_highScoreLabel.Text = $"{ScoreManager.GetHighScore():0000}";
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("fly"))
		{
			GetTree().ChangeSceneToPacked(GAME_SCENE);
		}
	}
}
