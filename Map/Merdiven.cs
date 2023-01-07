using Godot;
using System;

public class Merdiven : Node2D
{
    public int i;
    int boyut;
    RandomNumberGenerator rng;
    int yalt = 7;
    int xalt = 5;
    int yust = 1;
    int xust = 2;

    public override void _Ready()
    {
        TileMap tileMapmerdiven = GetNode<TileMap>("Merdiven");

        rng = new RandomNumberGenerator();
        rng.Randomize();
        boyut = rng.RandiRange(10, 30);

        for (i = 0; i <= boyut; i++)
        {
            //altmerdiven
            tileMapmerdiven.SetCell(xalt,yalt,0);
            //ikili
            tileMapmerdiven.SetCell(xalt,yalt + 1,0);
            //ustmerdiven
            tileMapmerdiven.SetCell(xust, yust, 0);
            //ikili
            tileMapmerdiven.SetCell(xust, yust - 1, 0);

            yalt--;
            xalt++;
            yust--;
            xust++;


            if (i == boyut)
            {
                //sontavan
                tileMapmerdiven.SetCell(xust, yust+1, 1);
                tileMapmerdiven.SetCell(xust + 1, yust+1, 1);
                tileMapmerdiven.SetCell(xust + 2, yust+1, 1);
                tileMapmerdiven.SetCell(xust + 3, yust+1, 1);
                tileMapmerdiven.SetCell(xust + 4, yust+1, 1);
                //ikili
                tileMapmerdiven.SetCell(xust, yust, 1);
                tileMapmerdiven.SetCell(xust + 1, yust, 1);
                tileMapmerdiven.SetCell(xust + 2, yust, 1);
                tileMapmerdiven.SetCell(xust + 3, yust, 1);
                tileMapmerdiven.SetCell(xust + 4, yust, 1);
                //sonyer
                tileMapmerdiven.SetCell(xalt, yalt + 1, 1);
                tileMapmerdiven.SetCell(xalt + 1, yalt + 1, 1);
                //ikili
                tileMapmerdiven.SetCell(xalt, yalt + 2, 1);
                tileMapmerdiven.SetCell(xalt + 1, yalt + 2, 1);

            }
        }
        //tavan
        tileMapmerdiven.SetCell(0,1,1);
        tileMapmerdiven.SetCell(1,1,1);
        //ikili
        tileMapmerdiven.SetCell(0,0,1);
        tileMapmerdiven.SetCell(1,0,1);
        //yer
        tileMapmerdiven.SetCell(0, 7, 1);
        tileMapmerdiven.SetCell(1, 7, 1);
        tileMapmerdiven.SetCell(2, 7, 1);
        tileMapmerdiven.SetCell(3, 7, 1);
        tileMapmerdiven.SetCell(4, 7, 1);
        //ikili
        tileMapmerdiven.SetCell(0, 8, 1);
        tileMapmerdiven.SetCell(1, 8, 1);
        tileMapmerdiven.SetCell(2, 8, 1);
        tileMapmerdiven.SetCell(3, 8, 1);
        tileMapmerdiven.SetCell(4, 8, 1);
    }

}
