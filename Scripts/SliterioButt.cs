using Godot;
using System;

public class SliterioButt : KinematicBody2D
{
    //  public KinematicBody2D kafa; 
    float hspeed = 0f;
    float _vspeed = 0f;
    Vector2 velocity;
    float gravity = 0f;

    public override void _Ready()
    {

    }


    public override void _Process(float delta)
    {
        var kafa = GetNode<SliterioHead>("../SliterioHead");

        if (!kafa.right)
        {
            hspeed = -3;
        }
        else
        {
            hspeed = 3;
        }

        //aralarindaki mesafeyi ayarlama
        if (kafa.GlobalPosition.x - this.GlobalPosition.x > 185 && kafa.right)
        {
            hspeed += 2;
        }
        if (kafa.GlobalPosition.x - this.GlobalPosition.x < 155 && kafa.right)
        {
            hspeed -= 2;
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
