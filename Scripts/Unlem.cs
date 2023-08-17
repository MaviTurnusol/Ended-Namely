using Godot;
using System;

public class Unlem : Sprite
{
    Timer unlemTimer;
    Color unlemSolduran;
    bool sureDoldu = false;
    public override void _Ready()
    {
        unlemTimer = GetNode<Timer>("UnlemTimer");
        unlemTimer.Connect("timeout", this, "on_timeout");
        unlemTimer.WaitTime = 0.35f;
        unlemTimer.Start();

        unlemSolduran = new Color(1,1,1,1);
    }
    public override void _Process(float delta)
    {
        this.Position -= new Vector2(0, 0.5f);
        this.Modulate = unlemSolduran;
        if(sureDoldu) {unlemSolduran.a8-=10;}
        if(unlemSolduran.a8 < 0)this.QueueFree();
    }

    void on_timeout()
    {
        sureDoldu = true;
    }
}
