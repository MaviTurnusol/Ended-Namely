using Godot;
using System;

public class Koridor : Node2D
{
    public int i;

    int boyut;
    RandomNumberGenerator rng;

    public override void _Ready()
    {
        TileMap tileMap = GetNode<TileMap>("YerTavan");

        rng = new RandomNumberGenerator();
        rng.Randomize();
        boyut = rng.RandiRange(30, 100);

        for (i = 0; i <= boyut; i++)
        {
            //tavan
            tileMap.SetCell(i, 0, 0);
            tileMap.SetCell(i, 1, 0);
            //yer
            tileMap.SetCell(i, 7, 0);
            tileMap.SetCell(i, 8, 0);

        }
    }
}
