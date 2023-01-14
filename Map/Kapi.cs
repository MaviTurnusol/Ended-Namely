using Godot;
using System;

public class Kapi : Node2D
{
    PackedScene Odascene;
    int i;
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

        rng = new RandomNumberGenerator();
        rng.Randomize();
        boyut = rng.RandiRange(15, 30);

        odanum = rng.RandiRange(0,0);
        Odascene = GD.Load<PackedScene>("res://Map/Oda/Oda"+ odanum.ToString()+".tscn");
      //  odascene = (Odascene)odascene.Instance();
       // AddChild(Odascene);

        altsprite.Position = new Vector2(2*64 + 32 ,(57 *64 + koridor.a * 10*64) -64);

        



     /*   for (i = 0; i <= boyut; i++)
        {
            //tavan
            tileMap.SetCell(i, 50 + koridor.a * 10, 0);
            tileMap.SetCell(i, 51 + koridor.a * 10, 0);
            //yer
            tileMap.SetCell(i, 57 + koridor.a * 10, 0);
            tileMap.SetCell(i, 58 + koridor.a * 10, 0);
        }
        //solduvar
        tileMap.SetCell(0,52 + koridor.a * 10,0);
        tileMap.SetCell(0,53 + koridor.a * 10,0);
        tileMap.SetCell(0,54 + koridor.a * 10,0);
        tileMap.SetCell(0,55 + koridor.a * 10,0);
        tileMap.SetCell(0,56 + koridor.a * 10,0);

        tileMap.SetCell(-1,50 + koridor.a * 10,0);
        tileMap.SetCell(-1,51 + koridor.a * 10,0);
        tileMap.SetCell(-1,52 + koridor.a * 10,0);
        tileMap.SetCell(-1,53 + koridor.a * 10,0);
        tileMap.SetCell(-1,54 + koridor.a * 10,0);
        tileMap.SetCell(-1,55 + koridor.a * 10,0);
        tileMap.SetCell(-1,56 + koridor.a * 10,0);
        tileMap.SetCell(-1,57 + koridor.a * 10,0);
        tileMap.SetCell(-1,58 + koridor.a * 10,0);
        //sagduvar
        tileMap.SetCell(boyut,52 + koridor.a * 10,0);
        tileMap.SetCell(boyut,53 + koridor.a * 10,0);
        tileMap.SetCell(boyut,54 + koridor.a * 10,0);
        tileMap.SetCell(boyut,55 + koridor.a * 10,0);
        tileMap.SetCell(boyut,56 + koridor.a * 10,0);
        
        tileMap.SetCell(boyut + 1,50 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,51 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,52 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,53 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,54 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,55 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,56 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,57 + koridor.a * 10,0);
        tileMap.SetCell(boyut + 1,58 + koridor.a * 10,0);
        */
    }

    public override void _Process(float delta)
    {
        if (Input.IsKeyPressed((int)KeyList.Up) && kapiteleport && !altta)
        {
        var altsprite = GetNode<Sprite>("Altsprite");

        GetNode<KinematicBody2D>("../../Player").GlobalPosition = altsprite.GlobalPosition;
        }

        if (Input.IsKeyPressed((int)KeyList.Up) && kapiteleport && altta)
        {
        var kapi = GetNode<Sprite>("Sprite");

        GetNode<KinematicBody2D>("../../Player").GlobalPosition = kapi.GlobalPosition;
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
