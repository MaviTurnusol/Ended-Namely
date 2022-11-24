using Godot;
using System;

public class Sliterio : KinematicBody2D
{
    public RigidBody2D popo;
    
    public override void _PhysicsProcess(float delta)
    {
        this.GlobalPosition = GetGlobalMousePosition();

     //   Rotation = (GetGlobalMousePosition() - GlobalPosition).Angle();


        //  this.GlobalRotation += (float)0.05;

        Update();

    }

   // public override void _Draw()
  //  {
   //     popo = GetNode<RigidBody2D>("../RigidBody2D");
        
        
    //    Vector2 a = this.GlobalPosition;
    //    Vector2 b = popo.GlobalPosition;

    //    Color colour = new Color(0,0,0);
    //    DrawLine(b,a, colour , 5);


  //  }
}
