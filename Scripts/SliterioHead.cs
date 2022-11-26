using Godot;
using System;

public class SliterioHead : KinematicBody2D
{
    public RigidBody2D popo;
    
    public override void _PhysicsProcess(float delta)
    {
        this.GlobalPosition = GetGlobalMousePosition();

     //   Rotation = (GetGlobalMousePosition() - GlobalPosition).Angle();


        //  this.GlobalRotation += (float)0.05;

        Update();

    }
}
