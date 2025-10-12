using Godot;
using System;

public partial class StartButton : Area2D
{
	private bool _isMouseInside;
	private PackedScene Level1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_isMouseInside = false;
		Level1 = (PackedScene)ResourceLoader.Load("res://Scenes/Level1.tscn");
	}

	public override void _Process(float delta)
	{
		if (_isMouseInside)
		{
			if (Input.IsActionJustPressed("select"))
			{
				GetTree().ChangeSceneTo(Level1);
			}
		}
	}

	private void OnMouseEntered()
	{
		_isMouseInside = true;
	}

	private void OnMouseExited()
	{
		_isMouseInside = false;
	}
}
