using Godot;
using System;

public class NlSpawner : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    PackedScene NlSprScene;

    static float r1;
    static float r2;
    static Sprite spr0;
    static Sprite spr1;
    static Sprite spr2;
    static Sprite spr3;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RigidBody2D rig1 = new RigidBody2D();
        RigidBody2D rig2 = new RigidBody2D();
        RigidBody2D rig3 = new RigidBody2D();
        RigidBody2D rig4 = new RigidBody2D();

        NlSprScene = GD.Load<PackedScene>("res://Nameless/NlCircleSprite.tscn");
        
        spr0 = GetChild<Sprite>(0);
        spr1 = GetChild<Sprite>(1);
        spr2 = GetChild<Sprite>(2);
        spr3 = GetChild<Sprite>(3);

        RandomNumberGenerator rng = new RandomNumberGenerator();
        
        rng.Randomize();
        r1 = rng.RandfRange(0.5f, 3);
        r2 = rng.RandfRange(0.5f, 3);
        float body1 = rng.RandfRange(30, 100);
        float leg1 = rng.RandfRange(20, 120);
        float leg2 = rng.RandfRange(20, 120);
        float reddit = rng.RandfRange(0, 1);
        float greendit = rng.RandfRange(0, 1);
        float bluedit = rng.RandfRange(0, 1);

        spr0.Scale = new Vector2(r1, r1);
        spr1.Scale = new Vector2(r1/1.5f, r1/1.5f);
        spr2.Scale = new Vector2(r2, r2);
        spr3.Scale = new Vector2(r2/1.5f, r2/1.5f);

        spr0.Modulate = new Color(reddit, greendit, bluedit);
        spr1.Modulate = new Color(reddit, greendit, bluedit);
        spr2.Modulate = new Color(reddit, greendit, bluedit);
        spr3.Modulate = new Color(reddit, greendit, bluedit);

        spr0.Position = Position;
        spr2.Position = Position + new Vector2(body1, 0);
        spr1.Position = Position + new Vector2(0, leg1);
        spr3.Position = Position + new Vector2(body1, leg2);
    }

    public override void _Draw()
    {
        Vector2[] points = new Vector2[] 
        {
            new Vector2(spr0.Position.x, spr0.Position.y - 16*r1), 
            new Vector2(spr2.Position.x, spr2.Position.y - 16*r2),
            new Vector2(spr2.Position.x, spr2.Position.y + 16*r2),
            new Vector2(spr0.Position.x, spr0.Position.y + 16*r1),
        };
        Color[] colour = new Color[] {spr0.Modulate};
        DrawPolygon(points, colour);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Update();
    }
}
