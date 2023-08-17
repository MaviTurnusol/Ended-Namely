using Godot;
using System;

public class Line2D : Godot.Line2D
{
    public RigidBody2D popo;
    public KinematicBody2D pipi;

    public override void _PhysicsProcess(float delta)
    {
        Update();
    }

    public override void _Draw()
    {
        popo = GetNode<RigidBody2D>("../RigidBody2D");
        pipi = GetNode<KinematicBody2D>("../Sliterio");


        Vector2 a = pipi.GlobalPosition;
        Vector2 b = popo.GlobalPosition;

        Color colour = new Color(0, 0, 0);
        DrawLine(b, a, colour, 5);


    }
}
