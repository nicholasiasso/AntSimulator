using Godot;
using System;

public class Ant : Node2D
{

    private Vector2 target;

    private const float speed = 1;
    private const float targetSize = 8;
    private const float maxTargetDistX = 128;
    private const float maxTargetDistY = 128;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        this.target = this.Position;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if ((target - this.Position).DistanceTo(new Vector2(0, 0)) < targetSize)
        {
            var targetRelX = (GD.Randf() < 0.5f) ? GD.Randf() * maxTargetDistX : GD.Randf() * maxTargetDistX * -1;
            var targetRelY = (GD.Randf() < 0.5f) ? GD.Randf() * maxTargetDistY : GD.Randf() * maxTargetDistY * -1;
            this.target = new Vector2(this.GlobalPosition.x + targetRelX, this.GlobalPosition.y + targetRelY);
            GD.Print(this.target);
        }

        this.MoveTowards(target, speed);
    }

    private void MoveTowards(Vector2 target_, float speed_)
    {
        this.LookAt(target_);
        this.Position += new Vector2(1, 0).Rotated(this.Rotation) * speed_;
    }
}
