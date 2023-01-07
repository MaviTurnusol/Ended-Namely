using Godot;
using System;

public class Map : Node2D
{
    float merdivenyerx;
    float merdivenyery;

    public override void _Ready()
    {
        var merdiven = GetNode<Merdiven>("Merdiven"); 
        //merdiven vectorx
        merdivenyerx = 64*(-7 - merdiven.i);
        //merdiven vectory
        merdivenyery = 64*(merdiven.i - 1);
        //merdiven yer
        merdiven.GlobalPosition = new Vector2(merdivenyerx,merdivenyery);
    }
}