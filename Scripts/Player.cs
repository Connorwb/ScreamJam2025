using Godot;
using System;

public abstract partial class Player : CharacterBody2D
{
	
	public int Speed; // How fast the player will move (pixels/sec).
	public int Gravity; // might want to replace later with Godot official stuff

	public Vector2 ScreenSize; // Size of the game window.
	public Vector2 carried_velocity; 
	public CollisionShape2D Col;
	public RectangleShape2D SelfBoundary;
	public AnimatedSprite2D animatedSprite2D;
	public float jumpHeight;
	public bool mirrored;
	protected Vector2 ctrl_velocity;

	public override void _PhysicsProcess(double delta)
	{
		carried_velocity.Y += Gravity * (float)delta;

		if (Input.IsActionPressed("move_right"))
		{
			move_right();
		}

		if (Input.IsActionPressed("move_left"))
		{
			move_left();
		}

		Velocity = carried_velocity + ctrl_velocity;

		MoveAndSlide();

		if (Velocity.Length() < 50)
		{
			animatedSprite2D.Animation = "Idle";
		}

		if (IsOnFloorMod() && Input.IsActionPressed("jump"))
		{
			carried_velocity.Y = jumpHeight;
		}
		else if (!IsOnFloorMod())
		{
			animatedSprite2D.Animation = "Jumping";
		}

		animatedSprite2D.Play();
	}

	public abstract bool IsOnFloorMod();

	protected void move_left()
	{
		ctrl_velocity.X -= 1 * Speed;
		animatedSprite2D.Animation = "Walking";
		animatedSprite2D.FlipH = !mirrored;
	}

	protected void move_right(){
		ctrl_velocity.X += 1 * Speed;
		animatedSprite2D.Animation = "Walking";
		animatedSprite2D.FlipH = mirrored;
	}
}
