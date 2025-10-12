using Godot;
using System;

public partial class PlayerDead : Player
{
	[Export]
	private CharacterBody2D AlivePair;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		carried_velocity = Vector2.Zero;
		Col = GetNode<CollisionShape2D>("DeadCol");
		SelfBoundary = (Godot.RectangleShape2D)Col.Shape;
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		jumpHeight = 450;
		Speed = 400;
		Gravity = -600;
		mirrored = true;
	}
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("regroup"))
		{
			if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
			{

			}
			else
			{
				if (AlivePair.Position.X > Position.X)
				{
					move_right();
				}
				else
				{
					move_left();
				}
			}
		}
		base._PhysicsProcess(delta);
		ctrl_velocity = Vector2.Zero;
	}


	public override bool IsOnFloorMod()
	{
		return IsOnCeiling();
	}

	public override bool IsOnCeilingMod()
	{
		return IsOnFloor();
	}

}
