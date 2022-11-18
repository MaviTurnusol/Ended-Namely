using Godot;
using System;

public class Player : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    PackedScene Fistscene;

   public float _hspeed = 0f;
    float _dspeed = 0f;
    float _fspeed = 0f;
    float _vspeed = 16f;
    float gravity = 0f;
    Vector2 velocity;
    bool dashready = true;
    string state = "idle";
    bool fistis = true;
    public bool rightleft;
    double addtime = 0;
    bool koyun;
    public bool yumrukvar;
    bool fistchargevar;
    bool cekti = true;
    bool fistcharge = false;


    Vector2 upDirection = Vector2.Up;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Fistscene = GD.Load<PackedScene>("res://Scenes/Fist.tscn");

        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = (float) 0.5f;
        timer.Connect("timeout", this, "on_timeout");

        Timer timer2 = this.GetNode<Timer>("Timer2");
        timer2.Connect("timeout", this, "on_timeout2");

        Timer timer3 = this.GetNode<Timer>("Timer3");
        timer3.WaitTime = (float)1;
        timer3.OneShot = true;
        timer3.Connect("timeout", this, "on_timeout3");

        TextureProgress stamina = GetParent().GetNode<CanvasLayer>("CanvasLayer").GetChild<TextureProgress>(0);
        stamina.Value = 1000.0;
    }

    void valgetter(double val)
    {
        TextureProgress stamina = GetParent().GetNode<CanvasLayer>("CanvasLayer").GetChild<TextureProgress>(0);
        stamina.Value = val;
    }

    public override void _PhysicsProcess(float delta)
    {
        TextureProgress stamina = GetParent().GetNode<CanvasLayer>("CanvasLayer").GetChild<TextureProgress>(0);
        CanvasLayer canvasex = GetParent().GetNode<CanvasLayer>("CanvasLayer");
        Tween twink = GetParent().GetNode<Tween>("twink");
        stamina.Value += 1;

        if (!fistcharge)
        {
            if (Input.IsActionPressed("ui_left"))
            {
                _hspeed = -10f;
                rightleft = true;
            }
            else if (Input.IsActionPressed("ui_right"))
            {
                _hspeed = 10f;
                rightleft = false;
            }
            else if (_hspeed > 0)
            {
                _hspeed -= 0.5f;
            }
            else if (_hspeed < 0)
            {
                _hspeed += 0.5f;
            }
        }
        if(IsOnFloor())
        {
           // GD.Print(_hspeed);
        }

        
        //jump
      //  if (Input.IsKeyPressed((int)KeyList.X) && IsOnFloor() == true)
       // {
      //       _vspeed = -1400f;
      //  }
      //  if (Input.IsKeyPressed((int)KeyList.Down))
      //  {
      //      _vspeed = 0f;
      //  }

        //dash
        Timer timer = this.GetNode<Timer>("Timer");
        if(Input.IsActionJustPressed("dash") && dashready == true && stamina.Value > 333)
        {
            twink.InterpolateMethod(this, "valgetter", stamina.Value, stamina.Value - 333, 0.5f, Tween.TransitionType.Expo, Tween.EaseType.InOut);
            twink.Start();
            if(_hspeed >= 0f)
            _dspeed = 10f;
            else {_dspeed = -10f;}
            dashready = false;
            state = "dashing";
            gravity = 0f;
            timer.Start();
        }

        //gravity
        if(!IsOnFloor() && gravity < 640f)
        {
            gravity += 6f;
            _vspeed = 0f;
        } else {
            gravity = 640f;
            if(_vspeed < 0)
            {
                _vspeed += 24f;
            }
        }

        velocity = MoveAndSlide(new Vector2((_hspeed + _dspeed + _fspeed) * 50, (_vspeed + gravity)), Vector2.Up);

        Timer timer3 = this.GetNode<Timer>("Timer3");

        if (timer3.TimeLeft > 0 )
        {            
           addtime += 0.1;           
        }
        
      //  GD.Print(_fspeed);
    }

    public void on_timeout()
    {
        if(state == "dashing")
        {
            _dspeed = 0f;
            state = "idle";
            gravity = 640f;
        }

        if(IsOnFloor())
        {
            dashready = true;
        }
    }
    public void on_timeout2()
    {
        _fspeed = 0f;
        GD.Print("tim2");
    }
    public void on_timeout3()
    {
        fistchargevar = false;
      //  fistis = true;
        GD.Print("tim3");
    }



    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);
        if (@event is InputEventKey eventKey)
        {
            if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.X && IsOnFloor() == true)
            {
                _vspeed = -1400f;
            }
            if (eventKey.IsActionReleased("Jump") && eventKey.Scancode == (int)KeyList.X)
            {
                _vspeed = 0f;
            }
            if (eventKey.Pressed && eventKey.Scancode == (int)KeyList.C && fistis && cekti)
            {
                Timer timer3 = this.GetNode<Timer>("Timer3");

                Fist fist = (Fist)Fistscene.Instance();
                fist.Position = Position;
                fist.Rotation = Rotation;
                GetParent().AddChild(fist);
                GetTree().SetInputAsHandled();
                fistchargevar = true;
                addtime = 0;
                timer3.Start();
                _hspeed = 0f;
                fistcharge = true;
                koyun = true;
                fistis = false;
            }
            if (eventKey.Pressed == false && eventKey.Scancode == (int)KeyList.C && koyun)
            {
                GD.Print(addtime);
                if (addtime > 2.3)
                {
                    addtime = 2.3;
                }

                Timer timer2 = this.GetNode<Timer>("Timer2");
                timer2.WaitTime = (float)addtime / 15;
                timer2.OneShot = true;
            //    GD.Print(timer2.WaitTime);
                Timer timer3 = this.GetNode<Timer>("Timer3");

                if(timer2.WaitTime < 0.1)
                {
                    if (fistchargevar)
                    {
                        if (rightleft)
                        {
                            _fspeed -= 20f ;
                        }
                        else
                        {
                            _fspeed += 20f ;
                        }
                        timer3.Stop();
                        timer2.Start();
                    }
                }
                if (timer2.WaitTime > 0.1)
                {
                    if (fistchargevar)
                    {
                        if (rightleft)
                        {
                            _fspeed -= 50f;
                        }
                        else
                        {
                            _fspeed += 50f;
                        }
                        timer3.Stop();
                        timer2.Start();
                    }
                }

                cekti = true;
                yumrukvar = false;
                koyun = false;
                fistis = true;
                fistcharge = false;
            }
        }

    }
}
