using Godot;
using System;

public class SliterioHead : KinematicBody2D
{
    public KinematicBody2D player;
    public RigidBody2D kardes;
    public KinematicBody2D popo;
    float hspeed = 0f;
    float _vspeed = 0f;
    Vector2 velocity;
    public bool right;
    float gravity = 0f;
    public bool popokafayakin;

    public override void _Ready()
    {

    }

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
            hspeed = 3;
        }
        else
        {
            hspeed = -3;
        }

        //aralarindaki mesafeyi ayarlama
        if (this.GlobalPosition.x - popo.GlobalPosition.x > 185 && !right)
        {
            hspeed -= 2;
        }
        if (this.GlobalPosition.x - popo.GlobalPosition.x < 155 && !right)
        {
            hspeed += 2;
        }

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
        velocity = MoveAndSlide(new Vector2(hspeed * 50, (_vspeed + gravity)), Vector2.Up);
    }
}
