using Godot;
using System;

public partial class PowerButton : StaticBody2D
{
    [Export]
    private AnimationPlayer actuate_anim;
    
    private Node2D depressed;
    private Node2D inactive;

    public override void _Ready()
    {
        depressed = GetNode<Node2D>("Depressed");
        inactive = GetNode<Node2D>("Ready");
    }

    public override void _Process(double delta)
    {
        
    }

    private void OnBodyEntered(Node2D node)
    {
        GD.Print($"Body '{node.Name}' entered");
        depressed.Visible = true;
        inactive.Visible = false;
        actuate_anim.Play("Rise");
    }
    
    private void OnBodyExited(Node2D node)
	{
		GD.Print($"Body '{node.Name}' exited");
        depressed.Visible = false;
        inactive.Visible = true;
        actuate_anim.PlayBackwards("Rise");
	}
}