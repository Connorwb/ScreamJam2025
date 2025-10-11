using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class PlayerAlive : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).
	[Export]
	public int Gravity { get; set; } = 600; // might want to replace later with Godot official stuff

	public Vector2 ScreenSize; // Size of the game window.
	public Vector2 carried_velocity; 
	public CollisionShape2D aliveCol;
	public RectangleShape2D SelfBoundary;
	private AnimatedSprite2D animatedSprite2D;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		carried_velocity = Vector2.Zero; // The player's movement vector.
		Godot.CollisionShape2D aliveCol = GetNode<CollisionShape2D>("AliveCol");
		SelfBoundary = (Godot.RectangleShape2D)aliveCol.Shape;
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		var ctrl_velocity = Vector2.Zero;
		carried_velocity.Y += Gravity * (float)delta;

		if (Input.IsActionPressed("move_right"))
		{
			ctrl_velocity.X += 1 * Speed;
			animatedSprite2D.Animation = "Walking";
		}

		if (Input.IsActionPressed("move_left"))
		{
			ctrl_velocity.X -= 1 * Speed;
			animatedSprite2D.Animation = "Walking";
		}

		Velocity = carried_velocity + ctrl_velocity;

		if (Velocity.Length() < 50)
		{
			animatedSprite2D.Animation = "Idle";
		}

		MoveAndSlide();

		if (IsOnFloor() && Input.IsActionPressed("jump"))
		{
			carried_velocity.Y = -750;
			animatedSprite2D.Animation = "Jumping";
		}

		animatedSprite2D.Play();
	}
}
