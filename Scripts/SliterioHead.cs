using Godot;
using System;

public class SliterioHead : KinematicBody2D
{
    public KinematicBody2D player;
    public RigidBody2D kardes;
    public KinematicBody2D popo;
    float speed = 0f;
    float _vspeed = 0f;
    float aramesafe = 0;
    Vector2 velocity;
    public bool right;
    float gravity = 0f;
    public bool popokafayakin;

    public override void _PhysicsProcess(float delta)
    {
        player = GetNode<KinematicBody2D>("../../Player");
        popo = GetNode<KinematicBody2D>("../SliterioButt");
        kardes = GetNode<RigidBody2D>("../SliterioBody2");

        if (player.GlobalPosition.x < kardes.GlobalPosition.x && player.Position.x != -42)
        {
            right = false;
        }
        else
        {
            right = true;
        }

        if (right)
        {
            speed = 3;
        }
        else
        {
            speed = -3;
        }

        //170
        //aralarindaki mesafeyi ayarlama
        //  if(this.GlobalPosition.x - popo.GlobalPosition.x > 170)
        //  {

        //   }

        //gravity
        if (!IsOnFloor() && gravity < 640f)
        {
            gravity += 6f;
            _vspeed = 0f;
        }
        else
        {
            gravity = 640f;
            if (_vspeed < 0)
            {
                _vspeed += 24f;
            }
        }
        velocity = MoveAndSlide(new Vector2(speed * 50, (_vspeed + gravity)), Vector2.Up);
    }
}
