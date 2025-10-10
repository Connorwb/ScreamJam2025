using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class PlayerAlive : Area2D
{
	[Export]
	public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).
	[Export]
	new public int Gravity { get; set; } = 10; // might want to replace later with Godot official stuff

	public Vector2 ScreenSize; // Size of the game window.
	public Vector2 velocity; 
	public CollisionShape2D aliveCol;
	public RectangleShape2D SelfBoundary;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		var velocity = Vector2.Zero; // The player's movement vector.
		Godot.CollisionShape2D aliveCol = GetNode<CollisionShape2D>("AliveCol");
		SelfBoundary = (Godot.RectangleShape2D) aliveCol.Shape;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var ctrl_velocity = Vector2.Zero;

		if (Input.IsActionPressed("move_right"))
		{
			ctrl_velocity.X += 1 * Speed;
		}

		if (Input.IsActionPressed("move_left"))
		{
			ctrl_velocity.X -= 1 * Speed;
		}

		if (OnGround())
		{
			if (velocity.Y > 0)
			{
				velocity.Y = 0; // Stop falling if on the ground
			}
		}
		else
		{
			velocity.Y += Gravity;
		}

		Position += (velocity + ctrl_velocity) * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey inputEventKey)
		{
			if (inputEventKey.PhysicalKeycode == Key.W)
			{
				if (OnGround())
				{
					velocity.Y -= 1000;
				}
				else
				{
					return;
				}
			}
		}
	}
	
	private bool OnGround()
	{
		return Position.Y > (ScreenSize.Y - SelfBoundary.Size.Y) / 2;
	}
}
