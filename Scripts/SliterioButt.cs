using Godot;
using System;

public class SliterioButt : KinematicBody2D
{
  //  public KinematicBody2D kafa; 
    float speed = 0f;
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
            speed = -3;
        }
        else
        {
            speed = 3;
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
        velocity = MoveAndSlide(new Vector2(speed * 50, (_vspeed + gravity)), Vector2.Up);

    }
}
