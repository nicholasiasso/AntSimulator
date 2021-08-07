using Godot;
using System.Collections.Generic;

public class Pheromone : Node2D
{

    public enum PheromoneType {
        TOHILL = 0,
        TOFOOD = 1,
    }

    private static Dictionary<PheromoneType, Color> Colors = new Dictionary<PheromoneType, Color> ()
    {
        {PheromoneType.TOHILL, new Color(79f, 56f, 36f)},
        {PheromoneType.TOFOOD, new Color(108f, 174f, 117f)},
    };

    private static Dictionary<PheromoneType, float> LifespanInSeconds = new Dictionary<PheromoneType, float> ()
    {
        {PheromoneType.TOHILL, 10f},
        {PheromoneType.TOFOOD, 10f},
    };
        

    private PheromoneType type = PheromoneType.TOHILL;
    private float timeAlive = 0;

    public Pheromone init(PheromoneType pheromoneType) {
        this.type = pheromoneType;
        this.timeAlive = 0;
        return this;
    }

    public override void _Ready()
    {
        this.ShowBehindParent = true;
    }

    public override void _Draw()
    {
        var timeLeft = Pheromone.LifespanInSeconds[this.type] - this.timeAlive;
        var radius = 2 * (timeLeft / Pheromone.LifespanInSeconds[this.type]);
        DrawCircle(Vector2.Zero, radius, Pheromone.Colors[this.type]);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        this.timeAlive += delta;
        if (this.timeAlive >= Pheromone.LifespanInSeconds[this.type]) {
            this.QueueFree();
            return;
        }

        // Redraw
        this.Update();
    }
}
