using Godot;
using System;

public partial class MainCamera : Camera2D
{
	private CharacterBody2D AlivePlayer;
	private CharacterBody2D DeadPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AlivePlayer = GetNode<CharacterBody2D>("/root/Node/PlayerAlive");
		DeadPlayer = GetNode<CharacterBody2D>("/root/Node/PlayerDead");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var aliveX = AlivePlayer.Position.X;
		var deadX = DeadPlayer.Position.X;
		var newX = (aliveX + deadX) / 2;
		var newY = Offset.Y;
		Offset = new Vector2(
			newX,
			newY
		);
	}
}
