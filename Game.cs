using Godot;
using System;

public partial class Game : Node2D
{

	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print($"{GetSpawnY()}");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public float GetSpawnY()
	{
		return (float)GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
	}
}
