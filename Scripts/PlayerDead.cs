using Godot;
using System;

public partial class PlayerDead : Player
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		carried_velocity = Vector2.Zero;
		Col = GetNode<CollisionShape2D>("DeadCol");
		SelfBoundary = (Godot.RectangleShape2D)Col.Shape;
		animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		jumpHeight = 750;
		Speed = 400;
		Gravity = -600;
	}
	
	public override bool IsOnFloorMod()
	{
		return IsOnCeiling();
	}
}
