using Godot;
using System;

public class togg : KinematicBody2D
{
    Vector2 velocity = new Vector2();
    RayCast2D rcUp;
    KinematicBody2D pluer;
    public override void _Ready()
    {
        rcUp = GetNode<RayCast2D>("rcUp");
        pluer = GetNode<KinematicBody2D>("../Player");
    }

    public override void _PhysicsProcess(float delta)
    {
        if(!(rcUp.GetCollider() == pluer))
        {
            if(pluer.Position.x < this.Position.x)
            {
                RotationDegrees -= 1f;
            } else {
                RotationDegrees += 1f;
            }
        GD.Print("nerede bu");
        } else {
        GD.Print("gordum");
        }
    } 
}
