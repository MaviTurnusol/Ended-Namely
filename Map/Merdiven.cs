using Godot;
using System;

public class Merdiven : Node2D
{
    int i;
    int boyut;
    RandomNumberGenerator rng;
    public Node2D koridor;
    int yalt = 4;
    int xalt = 8;
    int yust = -1;
    int xust = 5;


    public override void _Ready()
    {
        TileMap tileMapmerdiven = GetNode<TileMap>("Merdiven");

        rng = new RandomNumberGenerator();
        rng.Randomize();
        boyut = rng.RandiRange(10, 25);

        for (i = 0; i <= boyut; i++)
        {
            //altmerdiven
            tileMapmerdiven.SetCell(xalt,yalt,0);
            //ustmerdiven
            tileMapmerdiven.SetCell(xust, yust, 0);

            yalt--;
            xalt++;
            yust--;
            xust++;


            if (i == boyut)
            {
                //sontavan
                tileMapmerdiven.SetCell(xust, yust, 1);
                tileMapmerdiven.SetCell(xust + 1, yust, 1);
                tileMapmerdiven.SetCell(xust + 2, yust, 1);
                tileMapmerdiven.SetCell(xust + 3, yust, 1);
                tileMapmerdiven.SetCell(xust + 4, yust, 1);
                //sonyer
                tileMapmerdiven.SetCell(xalt, yalt + 1, 1);
                tileMapmerdiven.SetCell(xalt + 1, yalt + 1, 1);
            }
        }
        //tavan
        tileMapmerdiven.SetCell(3,0,1);
        tileMapmerdiven.SetCell(4,0,1);
        //yer
        tileMapmerdiven.SetCell(3, 5, 1);
        tileMapmerdiven.SetCell(4, 5, 1);
        tileMapmerdiven.SetCell(5, 5, 1);
        tileMapmerdiven.SetCell(6, 5, 1);
        tileMapmerdiven.SetCell(7, 5, 1);
    }

}
