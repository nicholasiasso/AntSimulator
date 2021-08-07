using Godot;
using System;

public class Game : Node2D
{
    private PackedScene antScene = (PackedScene)ResourceLoader.Load("res://Ant.tscn");
    private Node ants;
    private Hill hill;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.ants = GetNode<Node>("Ants");
        this.hill = GetNode<Hill>("Hill");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var ant = (Ant)antScene.Instance();
        ant.GlobalPosition = hill.GlobalPosition;
        ant.ZIndex = 1;
        ants.AddChild(ant, true);
    }
}
