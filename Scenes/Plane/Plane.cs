using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Plane : CharacterBody2D
{

	const float GRAVITY = 800.0f;
	const float POWER = -300.0f;

	[Export] private AnimationPlayer _animationPlayer;
	[Export] private AnimatedSprite2D _planeSprite;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print($"Plane READY at: {GetPath()}");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept")) GD.Print("ACCEPT");


		Vector2 velocity = Velocity;
		velocity.Y += GRAVITY * (float)delta;

		if (Input.IsActionJustPressed("fly") == true)
		{
			velocity.Y = POWER;
			_animationPlayer.Stop();
			_animationPlayer.Play("power");
			GD.Print("Power.");

		}

		Velocity = velocity;
		MoveAndSlide();

		if (IsOnFloor())
		{
			Die();
		}


	}

	public void Die()
	{
		_animationPlayer.Pause();
		SetPhysicsProcess(false);
		_planeSprite.Stop();
		GD.Print("Ded.");
		// EmitSignal(SignalName.OnPlaneDied);
		SignalManager.EmitOnPlaneDied();	

		}
}
