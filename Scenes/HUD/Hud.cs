using Godot;
using System;

public partial class Hud : Control
{
	[Export] private Label _scoreLabel;
	public override void _Ready()
	{
		GD.Print("HUD");
		SignalManager.Instance.OnScored += OnScored;
	}

	private void OnScored()
	{
		_scoreLabel.Text = $"{ScoreManager.GetScore():0000}";
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnScored -= OnScored;
	}

}
