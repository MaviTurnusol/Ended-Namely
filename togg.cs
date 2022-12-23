using Godot;
using System;

public class togg : KinematicBody2D
{
    Vector2 velocity = new Vector2();
    RayCast2D rcUp;
    KinematicBody2D pluer;

    float alpha;

    double tanalan(Vector2 thispos, Vector2 playerpos)
    {
        double tandir = Math.Atan2(thispos.y - playerpos.y, thispos.x - playerpos.x);
        tandir = tandir * 180 / Math.PI;
        return tandir;
    }
    public override void _Ready()
    {
        rcUp = GetNode<RayCast2D>("rcUp");
        pluer = GetNode<KinematicBody2D>("../Player");
    }

    public override void _PhysicsProcess(float delta)
    {
        alpha = (float)tanalan(this.Position, pluer.Position);

        if(!(rcUp.GetCollider() == pluer))
        {
            if((alpha > this.RotationDegrees) && (alpha - this.RotationDegrees <= 180))
            {
                RotationDegrees++;
            }
            else if((alpha > this.RotationDegrees) && !(alpha - this.RotationDegrees <= 180))
            {
                RotationDegrees--;
            }

            if((alpha <= this.RotationDegrees) && (alpha - this.RotationDegrees <= 180))
            {
                RotationDegrees--;
            }
            else if((alpha <= this.RotationDegrees) && !(alpha - this.RotationDegrees <= 180))
            {
                RotationDegrees++;
            }
        }
    }
}
