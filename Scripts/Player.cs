using Godot;
using System;

public abstract partial class Player : KinematicBody2D
{
	
	public int Speed; // How fast the player will move (pixels/sec).
	public int Gravity; // might want to replace later with Godot official stuff

	public Vector2 ScreenSize; // Size of the game window.
	public Vector2 carried_velocity; 
	public CollisionShape2D Col;
	public RectangleShape2D SelfBoundary;
	public AnimatedSprite animatedSprite2D;
	public float jumpHeight;
	public bool mirrored;
	protected Vector2 ctrl_velocity;

	public override void _PhysicsProcess(float delta)
	{
		carried_velocity.y += Gravity * (float)delta;

		if (Input.IsActionPressed("move_right"))
		{
			move_right();
		}

		if (Input.IsActionPressed("move_left"))
		{
			move_left();
		}

		var velocity = carried_velocity + ctrl_velocity;

		MoveAndSlide(velocity);

		if (velocity.Length() < 50)
		{
			animatedSprite2D.Animation = "Idle";
		}

		if (IsOnFloorMod())
		{
			if (Input.IsActionPressed("jump"))
			{
				carried_velocity.y = jumpHeight;
			}
			else
			{
				carried_velocity.y = 0;
			}

		}
		else if (!IsOnFloorMod())
		{
			animatedSprite2D.Animation = "Jumping";
		}
		
		if (IsOnCeilingMod())
		{
			carried_velocity.y = 0;
		}

		animatedSprite2D.Play();
	}

	public abstract bool IsOnFloorMod();
	public abstract bool IsOnCeilingMod();

	protected void move_left()
	{
		ctrl_velocity.x -= 1 * Speed;
		animatedSprite2D.Animation = "Walking";
		animatedSprite2D.FlipH = !mirrored;
	}

	protected void move_right(){
		ctrl_velocity.x += 1 * Speed;
		animatedSprite2D.Animation = "Walking";
		animatedSprite2D.FlipH = mirrored;
	}
}
