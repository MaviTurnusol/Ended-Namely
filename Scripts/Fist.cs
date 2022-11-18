using Godot;
using System;

public class Fist : Node2D
{
    public override void _PhysicsProcess(float delta)
    {
        var player = GetNode<Player>("../Player");

        Position = player.Position;


        if (player.rightleft)
        {
            RotationDegrees = 180;
        }
        else
        {
            RotationDegrees = 0;
        }

        if (player.yumrukvar == false)
        {
            QueueFree();
        }
    }

    public override void _Ready()
    {
        
    }

    public void on_timeout()
    {
        
    }
}
