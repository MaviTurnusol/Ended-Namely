using Godot;
using System;

public class togg : KinematicBody2D
{
    private Vector2 _velocity = new Vector2(0, 0);
    private int speed = 300;
    Tween omega;
    RayCast2D rcUp;
    KinematicBody2D pluer;
    Vector2 hakikivel;
    KinematicCollision2D Colintel;
    Timer tyler;
    
    bool beta = false;
    float alpha;

    double tanalan(Vector2 thispos, Vector2 playerpos)
    {
        double tandir = Math.Atan2(thispos.y - playerpos.y + 150, thispos.x - playerpos.x);
        tandir = tandir * 180 / Math.PI;
        return tandir;
    }
    public override void _Ready()
    {
        rcUp = GetNode<RayCast2D>("rcUp");
        pluer = GetNode<KinematicBody2D>("../Player");
        tyler = GetNode<Timer>("Tyler");
        omega = GetNode<Tween>("omega");

        tyler.WaitTime = (float)1f;
        tyler.Connect("timeout", this, "zamandolduyarak");
    }
    void omegahgetter(int homal)
    {
        speed = homal;
    }

    public override void _PhysicsProcess(float delta)
    {
        alpha = (float)tanalan(this.Position, pluer.Position);

        var rotation = rcUp.RotationDegrees;
        var radians = rotation * Math.PI / 180;
        var velocity_x = -speed * Math.Cos(radians);
        var velocity_y = -speed * Math.Sin(radians);

        if(IsOnWall()) {
            rcUp.RotationDegrees = alpha;
        }if(IsOnCeiling()){
            rcUp.RotationDegrees = alpha;
        }

        _velocity = new Vector2((float)velocity_x, (float)velocity_y);

        for (int index = 0; index < GetSlideCount(); index++)
        {
        KinematicCollision2D collision = GetSlideCollision(0);
        if (collision.Collider != pluer)
            {
            rcUp.RotationDegrees = alpha;
            }
        }
        hakikivel = MoveAndSlide(_velocity);

        if(!(rcUp.GetCollider() == pluer))
        {
            if((alpha > rcUp.RotationDegrees) && (alpha - rcUp.RotationDegrees <= 180))
            {
                rcUp.RotationDegrees+=1.2f;
            }
            else if((alpha > rcUp.RotationDegrees) && !(alpha - rcUp.RotationDegrees <= 180))
            {
                rcUp.RotationDegrees-=1.2f;
            }

            if((alpha <= rcUp.RotationDegrees) && (alpha - rcUp.RotationDegrees <= 180))
            {
                rcUp.RotationDegrees-=1.2f;
            }
            else if((alpha <= rcUp.RotationDegrees) && !(alpha - rcUp.RotationDegrees <= 180))
            {
                rcUp.RotationDegrees+=1.2f;
            }
        }
        rcUp.RotationDegrees = (float)Math.Round(rcUp.RotationDegrees, 2, MidpointRounding.ToEven);
        if(rcUp.RotationDegrees < -360)
        {
            rcUp.RotationDegrees = 360 - rcUp.RotationDegrees;
        }
        else if(rcUp.RotationDegrees >= 360)
        {
            rcUp.RotationDegrees = rcUp.RotationDegrees - 360;
        }
    }
}   
