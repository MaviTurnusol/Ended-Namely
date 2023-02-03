using Godot;
using System;

public class togg : KinematicBody2D
{
    float hspeed = 5f;
    float vspeed;
    string mstate = "sag";

    Vector2 velocity;
    KinematicCollision2D colinfo;

    RayCast2D rcUp;
    RayCast2D rcRight;
    RayCast2D rcLeft;

    KinematicBody2D pluer;

    public override void _Ready()
    {
        rcUp = GetNode<RayCast2D>("rcUp");
        rcRight = GetNode<RayCast2D>("rcRight");
        rcLeft = GetNode<RayCast2D>("rcLeft");
        pluer = GetNode<KinematicBody2D>("../Player");

        rcLeft.AddException();
    }

    public override void _PhysicsProcess(float delta)
    {
        if(rcUp.IsColliding() == true)
        {
            vspeed = 0f;
        } else {
            vspeed = -5f;
        }

        velocity.x = hspeed;
        velocity.y = vspeed;
        velocity = MoveAndSlide(velocity * 25);

        if(rcRight.GetCollider() != pluer && rcRight.GetCollider() != null)
        {
            mstate = "sol";
            hspeed = -5f;
        }
        if(rcLeft.GetCollider() != pluer && rcLeft.GetCollider() != null)
        {
            mstate = "sol";
            hspeed = 5f;
        }
    }
}   
