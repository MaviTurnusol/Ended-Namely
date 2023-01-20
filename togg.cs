using Godot;
using System;

public class togg : KinematicBody2D
{
    float hspeed;
    float vspeed;


    RayCast2D rcUp;

    public override void _Ready()
    {
        rcUp = GetNode<RayCast2D>("rcUp");
    }

    public override void _PhysicsProcess(float delta)
    {
        if(rcUp.IsColliding() == true)
        {
            vspeed = 0f;
        } else {
            vspeed = -1f;
        }

    }
}   
