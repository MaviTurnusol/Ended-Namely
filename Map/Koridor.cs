using Godot;
using System;

public class Koridor : Node2D
{
    PackedScene Kapiscene;
    public int i;
    public int a;
    int boyut;
    RandomNumberGenerator rng;
    int kapichance = 1;
    public int koridorkapimiktari;

    public override void _Ready()
    {      
        Kapiscene = GD.Load<PackedScene>("res://Map/Kapi.tscn");
        TileMap tileMap = GetNode<TileMap>("YerTavan");
        var map = GetNode<Map>("../../Map");

        rng = new RandomNumberGenerator();
        rng.Randomize();
        boyut = rng.RandiRange(40, 100);

        for (i = 0; i <= boyut; i++)
        {
            //tavan
            tileMap.SetCell(i, 0, 0);
            tileMap.SetCell(i, 1, 0);
            //yer
            tileMap.SetCell(i, 7, 0);
            tileMap.SetCell(i, 8, 0);

        }

        //kapilar 
        for(a = 5; a <= boyut - 5; a += 7)
        {
            if(kapichance == 1){
            Kapi kapi = (Kapi)Kapiscene.Instance();
            AddChild(kapi);
            kapi.Position = new Vector2(a*64,7*64);
            map.mapkapimiktari();
            }

            kapichance = rng.RandiRange(0, 1);

        }

    }
}
