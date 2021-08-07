using Godot;
using System;

public class Ant : Node2D
{

    private Vector2 target;

    private const float speed = 1;
    private const float targetSizeSquared = 64;

    private const float maxTargetAngle = Godot.Mathf.Pi / 3;
    private const float minTargetDist = 64;
    private const float maxTargetDist = 128;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.Rotation = GD.Randf() * Mathf.Pi * 2;
        this.target = this.GlobalPosition;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if ((target - this.GlobalPosition).DistanceSquaredTo(new Vector2(0, 0)) < targetSizeSquared)
        {
            var newRelTarget = new Vector2(1, 0).Rotated(this.Rotation);
            newRelTarget = newRelTarget.Rotated((GD.Randf() - 0.5f) * 2 * maxTargetAngle);
            newRelTarget = newRelTarget * (minTargetDist + GD.Randf() * (maxTargetDist - minTargetDist));
            this.target = new Vector2(this.GlobalPosition.x + newRelTarget.x, this.GlobalPosition.y + newRelTarget.y);
        }

        this.MoveTowards(target, speed);
    }

    private void MoveTowards(Vector2 target_, float speed_)
    {
        this.LookAt(target_);
        // this.GetNode<Sprite>("Sprite").FlipH = (this.Rotation > 0 && this.Rotation < Godot.Mathf.Pi);
        this.Position += new Vector2(1, 0).Rotated(this.Rotation) * speed_;
    }
}
