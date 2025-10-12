using Godot;
using System;

public partial class DepressButton : StaticBody2D
{
    [Export]
    private StaticBody2D actuate_obj_body;
    [Export]
    private int toggle_layer;
    
    private Node2D actuate_obj_unop;
    private Node2D actuate_obj_open;
    private Node2D depressed;
    private Node2D inactive;

    public override void _Ready()
    {
        actuate_obj_unop = actuate_obj_body.GetChild<Node2D>(1);
        actuate_obj_open = actuate_obj_body.GetChild<Node2D>(2);
        depressed = GetNode<Node2D>("Depressed");
        inactive = GetNode<Node2D>("Ready");
    }
    
    private void OnBodyEntered(Node2D node)
    {
        GD.Print($"Body '{node.Name}' entered");
        actuate_obj_unop.Visible = false;
		actuate_obj_open.Visible = true;
        actuate_obj_body.CollisionLayer &= ~(1u << (toggle_layer - 1));
        depressed.Visible = true;
        inactive.Visible = false;
    }
}