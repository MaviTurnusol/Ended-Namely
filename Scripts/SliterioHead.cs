using Godot;
using System;

public class SliterioHead : KinematicBody2D
{
    public KinematicBody2D player;
    float speed = 0f;
    Vector2 velocity;

    public override void _PhysicsProcess(float delta)
    {
        player = GetNode<KinematicBody2D>("../../Player");

        if (player.Position.x < 0)
        {
            speed = -7f;
        }
        else
        {
            speed = 7f;
        }
        velocity = MoveAndSlide(new Vector2(speed* 50, velocity.y));
    }
}
