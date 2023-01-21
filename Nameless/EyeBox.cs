using Godot;
using System;

public class EyeBox : StaticBody2D
{
    KinematicBody2D pluer;
    RayCast2D rcUp;
    Sprite Cornea;
    Vector2 CorneaPos;
    Sprite Unlem;
    Timer tyler;
    PackedScene UnlemScene;
    float alpha;
    bool unlemCD = false;
    bool unlemCDCD;

    double tanalan(Vector2 thispos, Vector2 playerpos)
    {
        double tandir = Math.Atan2(thispos.y - playerpos.y, thispos.x - playerpos.x);
        tandir = tandir * 180 / Math.PI;
        return tandir;
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        pluer = GetNode<KinematicBody2D>("../Player");
        rcUp = GetNode<RayCast2D>("rcUp");
        Cornea = GetNode<Sprite>("Box/Cornea");
        tyler = GetNode<Timer>("Tyler");
        CorneaPos = Cornea.Position;
        UnlemScene = GD.Load<PackedScene>("res://Scenes/Unlem.tscn");

        tyler.Connect("timeout", this, "on_timeout");
        tyler.WaitTime = 10f;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        alpha = (float)tanalan(this.Position, pluer.Position)+90;
        CorneaPos = new Vector2((float)Math.Sin(rcUp.Rotation)*-10 + 2.5f,(float)Math.Cos(rcUp.Rotation)*10 + 12f);
        Cornea.Position = CorneaPos;
        //Raycast Donme
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
        }
        else if(!unlemCD) {
        Unlem unlem = (Unlem)UnlemScene.Instance();
        AddChild(unlem);
        tyler.Start();
        unlem.Position -= new Vector2(0, 40);
        GD.Print(unlem.GlobalPosition);
        unlemCD = true;
        }
        if((alpha <= rcUp.RotationDegrees) && (alpha - rcUp.RotationDegrees <= 180))
        {
                rcUp.RotationDegrees-=1.2f;
            }
            else if((alpha <= rcUp.RotationDegrees) && !(alpha - rcUp.RotationDegrees <= 180))
            {
                rcUp.RotationDegrees+=1.2f;
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
    void on_timeout()
    {
        unlemCD = false;
    }
}
