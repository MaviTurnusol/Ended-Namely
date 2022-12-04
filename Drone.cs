using Godot;
using System;
using System.Linq;

public class Drone : KinematicBody2D
{
    // Raycastlari tanimlama
    RayCast2D rcU;
    RayCast2D rcUL;
    RayCast2D rcUR;
    RayCast2D rcL;
    RayCast2D rcR;
    RayCast2D rcD;
    RayCast2D rcDL;
    RayCast2D rcDR;

    // Yonleri tanimlama
    Vector2 right;
    Vector2 left;
    Vector2 up;
    Vector2 down;
    Vector2 upleft;
    Vector2 upright;
    Vector2 downleft;
    Vector2 downright;

    KinematicBody2D Player;
    Tween dronetwink;
    Tween yavaslama;

    Vector2 velocity;
    float _hspeed;
    float _vspeed;

    Timer timer;
    bool zamandoldu;

    public override void _Ready()
    {
        //Raycastlari tanimlama
        rcU = GetChild<RayCast2D>(2);
        rcUL = GetChild<RayCast2D>(3);
        rcUR = GetChild<RayCast2D>(4);
        rcL = GetChild<RayCast2D>(5);
        rcR = GetChild<RayCast2D>(6);
        rcD = GetChild<RayCast2D>(7);
        rcDL = GetChild<RayCast2D>(8);
        rcDR = GetChild<RayCast2D>(9);

        //Yonleri tanimlama
        right = new Vector2(this.Position.x + 100, this.Position.y);
        left = new Vector2(this.Position.x - 100, this.Position.y);
        up = new Vector2(this.Position.x, this.Position.y - 100);
        down = new Vector2(this.Position.x, this.Position.y + 100);
        upleft = new Vector2(this.Position.x - 100, this.Position.y - 100);
        upright = new Vector2(this.Position.x + 100, this.Position.y - 100);
        downleft = new Vector2(this.Position.x - 100, this.Position.y + 100);
        downright = new Vector2(this.Position.x + 100, this.Position.y + 100);

        //Oyuncuyu tanimlama
        Player = GetParent().GetNode<KinematicBody2D>("Player");
        dronetwink = GetNode<Tween>("dronetwink");
        yavaslama = GetNode<Tween>("yavaslama");

        _hspeed = 0;
        _vspeed = 0;

        timer = this.GetNode<Timer>("Tyler");
        timer.WaitTime = (float) 1f;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();
    }

    void hgetter(float val)
    {
        _hspeed = val;
    }
    void vgetter(float val)
    {
        _vspeed = val;
    }
    void hvgetter(float val)
    {
        _hspeed = val;
        _vspeed = -val;
    }
    void vhgetter(float val)
    {
        _hspeed = val;
        _vspeed = val;
    }
    

    double DistanceToPlayer(Vector2 cummy)
    {
        double DTP = Math.Sqrt((Player.Position.x - cummy.x) * (Player.Position.x - cummy.x) + (Player.Position.y - cummy.y) * (Player.Position.y - cummy.y));
        return DTP;
    }

    bool ifMin(Vector2 dummy)
    {
        double[] dArray = {DistanceToPlayer(right), DistanceToPlayer(left), DistanceToPlayer(up), DistanceToPlayer(down), DistanceToPlayer(upleft), DistanceToPlayer(upright), DistanceToPlayer(downleft), DistanceToPlayer(downright)};
        double minValue = dArray.Min();
        int minIndex = dArray.ToList().IndexOf(minValue);
        bool IsTrue;

        if(dArray[minIndex] == DistanceToPlayer(dummy))
        {
            IsTrue = true;
        } else { IsTrue = false;}

        return IsTrue;
    }

    public void on_timeout()
    {
        zamandoldu = true;
        _hspeed = 0;
        _vspeed = 0;
    }

    public override void _PhysicsProcess(float delta)
    {
        if(DistanceToPlayer(this.Position) > 10)
        {
            if(rcU.IsColliding() == false && ifMin(up) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "vgetter", 0, - 5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
            }
            if(rcD.IsColliding() == false && ifMin(down) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "vgetter", 0, + 5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
            }
            if(rcL.IsColliding() == false && ifMin(left) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "hgetter", 0, -5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
                GD.Print("solagittim"+ DistanceToPlayer(right) + ",,,," + DistanceToPlayer(left));
            }
            if(rcR.IsColliding() == false && ifMin(right) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "hgetter", 0, 5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
            }
            if(rcUR.IsColliding() == false && ifMin(upright) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "hvgetter", 0, 5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
            }
            if(rcUL.IsColliding() == false && ifMin(upleft) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "vhgetter", 0, -5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
            }
            if(rcDR.IsColliding() == false && ifMin(downright) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "vhgetter", 0, 5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
            }
            if(rcDL.IsColliding() == false && ifMin(downleft) == true && zamandoldu == true)
            {
                dronetwink.InterpolateMethod(this, "hvgetter", 0, -5, 1f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
                dronetwink.Start();
                zamandoldu = false;
                GD.Print("solassagi gittim" + DistanceToPlayer(right) + ",,,," + DistanceToPlayer(downleft));
            }
        } else {
            _hspeed = 0;
            _vspeed = 0;
        }

        velocity = MoveAndSlide(new Vector2(_hspeed * 25, _vspeed * 25));
    }
}
