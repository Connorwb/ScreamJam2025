using Godot;
using System;

public partial class ActiveBush : Area2D
{
	public bool activated;
	private StaticBody2D actuate_obj_body;
	private Node2D actuate_obj_unop;
	private Node2D actuate_obj_open;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		activated = false;
		actuate_obj_unop = GetNode<Node2D>("/root/Node/DebugDoor/Unopened");
		actuate_obj_open = GetNode<Node2D>("/root/Node/DebugDoor/Opened");
		actuate_obj_body = GetNode<StaticBody2D>("/root/Node/DebugDoor");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node2D node)
	{
		GD.Print($"Body '{node.Name}' entered");
		activated = true;
		actuate_obj_unop.Visible = false;
		actuate_obj_open.Visible = true;
		actuate_obj_body.CollisionLayer &= ~(1u << 0);
	}
	
	private void OnBodyExited(Node2D node)
	{
		GD.Print($"Body '{node.Name}' exited");
		activated = false;
		actuate_obj_unop.Visible = true;
		actuate_obj_open.Visible = false;
		actuate_obj_body.CollisionLayer |= (1u << 0);
	}
}
