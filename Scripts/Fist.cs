using Godot;
using System;

public class Fist : Node2D
{
    public override void _PhysicsProcess(float delta)
    {
        var player = GetNode<Player>("../Player");

        Position = player.Position;


        if (player.a)
        {
            Rotation = 140;
        }
        else
        {
            Rotation = 0;
        }
    }

    public override void _Ready()
    {
        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = (float)0.3;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();
    }

    public void on_timeout()
    {
        QueueFree();
    }
}
