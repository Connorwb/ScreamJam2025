using Godot;
using System;

public partial class PlayerAlive : Player
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		carried_velocity = Vector2.Zero;
		Col = GetNode<CollisionShape2D>("AliveCol");
		SelfBoundary = (Godot.RectangleShape2D)Col.Shape;
		animatedSprite2D = GetNode<AnimatedSprite>("AnimatedSprite");
		jumpHeight = -450;
		Speed = 400;
		Gravity = 600;
		mirrored = false;
	}

	public override void _PhysicsProcess(float delta)
	{
		base._PhysicsProcess(delta);
		ctrl_velocity = Vector2.Zero;
	}

	public override bool IsOnFloorMod()
	{
		return IsOnFloor();
	}

	public override bool IsOnCeilingMod()
	{
		return IsOnCeiling();
	}

}
