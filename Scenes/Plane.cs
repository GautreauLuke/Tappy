using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Plane : CharacterBody2D
{

	const float GRAVITY = 800.0f;
	const float POWER = -300.0f;

	[Export] private AnimationPlayer _animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += GRAVITY * (float)delta;

		if (Input.IsActionJustPressed("fly") == true)
		{
			velocity.Y = POWER;
			_animationPlayer.Stop();
			_animationPlayer.Play("power");
		}

		Velocity = velocity;
		MoveAndSlide();

	}
}
