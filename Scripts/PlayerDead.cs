using Godot;
using System;

public partial class PlayerDead : Player
{
	[Export]
	private KinematicBody AlivePair;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		carried_velocity = Vector2.Zero;
		Col = GetNode<CollisionShape2D>("DeadCol");
		SelfBoundary = (Godot.RectangleShape2D)Col.Shape;
		animatedSprite2D = GetNode<AnimatedSprite>("AnimatedSprite2D");
		jumpHeight = 450;
		Speed = 400;
		Gravity = -600;
		mirrored = true;
	}
	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionPressed("regroup"))
		{
			if (Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right"))
			{

			}
			else
			{
				if (AlivePair.Position.x > Position.x)
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
