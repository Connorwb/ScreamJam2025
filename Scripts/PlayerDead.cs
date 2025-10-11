using Godot;
using System;

public partial class PlayerDead : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).
	[Export]
	public int Gravity { get; set; } = -600; // might want to replace later with Godot official stuff

	public Vector2 ScreenSize; // Size of the game window.
	public Vector2 carried_velocity; 
	public CollisionShape2D deadCol;
	public RectangleShape2D SelfBoundary;
	private AnimatedSprite2D animatedSprite2D;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		var velocity = Vector2.Zero; // The player's movement vector.
		Godot.CollisionShape2D deadCol = GetNode<CollisionShape2D>("DeadCol");
		SelfBoundary = (Godot.RectangleShape2D)deadCol.Shape;
	}

	public override void _PhysicsProcess(double delta)
	{
		var ctrl_velocity = Vector2.Zero;
		carried_velocity.Y += Gravity * (float)delta;

		if (Input.IsActionPressed("move_right"))
		{
			ctrl_velocity.X += 1 * Speed;
		}

		if (Input.IsActionPressed("move_left"))
		{
			ctrl_velocity.X -= 1 * Speed;
		}

		Velocity = carried_velocity + ctrl_velocity;

		MoveAndSlide();

		if (IsOnCeiling() && Input.IsActionPressed("jump"))
		{
			carried_velocity.Y = 750;
		}
	}
}
