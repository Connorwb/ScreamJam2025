using Godot;
using System;

public partial class MainCamera : Camera2D
{
	private Area2D AlivePlayer;
	private Area2D DeadPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AlivePlayer = GetNode<Area2D>("/root/Node/PlayerAlive");
		DeadPlayer = GetNode<Area2D>("/root/Node/PlayerDead");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		var aliveX = AlivePlayer.Position.x;
		var deadX = DeadPlayer.Position.x;
		var newX = (aliveX + deadX) / 2;
		var newY = Offset.y;
		Offset = new Vector2(
			newX,
			newY
		);
	}
}
