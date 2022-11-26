using Godot;
using System;

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
    }

    public override void _Process(float delta)
    {
        if(rcU.IsColliding() == false)
        {

        }
    }
}
