using Godot;
using System;

public class NlSpawner : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RigidBody2D rig1 = new RigidBody2D();
        RigidBody2D rig2 = new RigidBody2D();
        RigidBody2D rig3 = new RigidBody2D();
        RigidBody2D rig4 = new RigidBody2D();

        Sprite spr1 = new Sprite();
        Sprite spr2 = new Sprite();
        Sprite spr3 = new Sprite();
        Sprite spr4 = new Sprite();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
