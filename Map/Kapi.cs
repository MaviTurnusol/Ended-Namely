using Godot;
using System;

public class Kapi : Node2D
{
    PackedScene Odascene;
    int boyut = 15;
    RandomNumberGenerator rng;
    bool kapiteleport = false;
    bool altta;
    int odanum;

     public override void _Ready()
    {
        TileMap tileMap = GetNode<TileMap>("TileMap");
        Sprite altsprite = GetNode<Sprite>("Altsprite");
        var koridor = GetNode<Koridor>("../../Koridor");
        var map = GetNode<Map>("../../../Map");

        //odasayısı
        rng = new RandomNumberGenerator();
        rng.Randomize();
        odanum = rng.RandiRange(0,0);
        
        //odaspawn
        Odascene = GD.Load<PackedScene>("res://Map/Oda/Oda"+ odanum.ToString()+".tscn");
        Node2D odascene = (Node2D)Odascene.Instance();
        AddChild(odascene);

        //pozisyonlar (sorunlu)
        odascene.Position += new Vector2(0,(50 *64 + map.kapimiktari * 20*64));

        altsprite.Position = new Vector2(3*64 + 32 ,(57 *64 + map.kapimiktari * 20*64) -64);

        GD.Print(map.kapimiktari);
    }

    public override void _Process(float delta)
    {

        if (Input.IsActionJustPressed("opendoor") && kapiteleport && !altta)
        {

        var player = GetNode<Player>("../../../Player");
        var altsprite = GetNode<Sprite>("Altsprite");
        player.GlobalPosition = altsprite.GlobalPosition;     
        }

        if (Input.IsActionJustPressed("opendoor") && kapiteleport && altta)
        {

        var player = GetNode<Player>("../../../Player");
        var kapi = GetNode<Sprite>("Sprite");
        player.GlobalPosition = kapi.GlobalPosition;
        }
    }

    public void _on_Area2D_area_entered(KinematicBody2D with)
    {
        altta = false;
        kapiteleport = true;
    }

    public void _on_Area2D_area_exited(KinematicBody2D with)
    {
        kapiteleport = false;
    }

    public void _alt_on_Area2D_area_entered(KinematicBody2D with)
    {
        altta = true;
        kapiteleport = true;
    }

    public void _alt_on_Area2D_area_exited(KinematicBody2D with)
    {
        kapiteleport = false;
    }
}
