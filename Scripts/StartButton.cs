using Godot;
using System;

public partial class StartButton : Area2D
{
	private bool _isMouseInside;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_isMouseInside = false;
	}

	public override void _Process(double delta)
	{
		if (_isMouseInside)
		{
			if (Input.IsActionJustPressed("select"))
			{
				GetTree().ChangeSceneToFile("res://Scenes/Debug.tscn");
			}
		}
	}

	private void OnMouseEntered()
	{
		_isMouseInside = true;
		GD.Print("Mouse entered Area2D!");
	}

	private void OnMouseExited()
	{
		_isMouseInside = false;
		GD.Print("Mouse exited Area2D!");
	}
}
