using Godot;
using System;

public class bbworm : KinematicBody2D
{
    void randomlength()
    {
        RandomNumberGenerator lengthRng = new RandomNumberGenerator();
        lengthRng.Randomize();
        
        int bblength = lengthRng.RandiRange(3, 10);

        for(int i = 0; i < bblength; i++)
        {

        }
    }

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        
    }
}
