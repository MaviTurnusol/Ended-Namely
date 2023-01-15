using Godot;
using System;

public class Map : Node2D
{
    PackedScene Koridorscene;
    PackedScene Merdivenscene;
    RandomNumberGenerator rng;
    int i;
    int merdivenyonu = 1;

    int xvector = 0;
    int yvector = 0;

    public override void _Ready()
    {
        Koridorscene = GD.Load<PackedScene>("res://Map/Koridor.tscn");
        Merdivenscene = GD.Load<PackedScene>("res://Map/Merdiven.tscn");

        rng = new RandomNumberGenerator();
        rng.Randomize();



        //merdiven vectorx
    //    merdivenyerx = 64*(-7 - merdiven.i);
    //    //merdiven vectory
    //    merdivenyery = 64*(merdiven.i - 1);
        //merdiven yer
     //   merdiven.GlobalPosition = new Vector2(merdivenyerx,merdivenyery);

        for(i = 0;i <= 9;i++)
        {
            //koridor
            Koridor koridor = (Koridor)Koridorscene.Instance();
            koridor.Position = new Vector2(xvector,yvector);
            AddChild(koridor);

            xvector += koridor.i * 64;

            Merdiven merdiven = (Merdiven)Merdivenscene.Instance();
            //normal merdiven
            if (merdivenyonu == 1){
                AddChild(merdiven);
                merdiven.Scale = new Vector2(1,1);
                merdiven.Position = new Vector2(xvector,yvector);
                xvector += (merdiven.i + 7) * 64;
                yvector -= (merdiven.i - 1) * 64;
            }
            //alt merdiven
            else{
                AddChild(merdiven);
                merdiven.Scale = new Vector2(-1,1);
                merdiven.Position = new Vector2(xvector + ((merdiven.i + 7) * 64),yvector + ((merdiven.i - 1)* 64));
                xvector += (merdiven.i + 7) * 64;
                yvector += (merdiven.i - 1) * 64;
            }

            merdivenyonu = rng.RandiRange(1, 2);
        }
    }
}