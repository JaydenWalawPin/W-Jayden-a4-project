using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

namespace MohawkGame2D;

public class Barriers
{
    // Decides the colour/type of the barrier
    Color BarrierColour = Color.Green;
    // determines barrier health
    Boolean Alive = true;
    int HitPoints = 1;
    // How many points it is worth
    int Value = 10;
    // Positions
    Vector2 Position;
    Vector2 PosLength;
    // Colisions
    Vector2 BarrierTopLeft;
    Vector2 BarrierBottomRight;
    public void Update()
    {
        SetLength(100, 50);
        Position.X = 300;
        Position.Y = 300;
        Barrier(Position);
    }

    public void SetLength(int X, int Y) //Temporary just to test
    {
        PosLength.X = X;
        PosLength.Y = Y;
    }

    public void Barrier(Vector2 BarrierPos) //Creates the barrier
    {
        if (Alive == true)
        {
            Draw.SetLineColor(BarrierColour);
            Draw.SetFillColor(Color.Magenta);
            Draw.Rectangle(BarrierPos, PosLength);
        }
    }

    public string CollisionBounce(string PrevDirect) //Decides how the ball that collides with it bounces
    {
        if (PrevDirect == "UpLeft") { return "DownRight"; }
        else if (PrevDirect == "UpRight") { return "DownLeft"; }
        else if (PrevDirect == "DownLeft") { return "Upright"; }
        else { return "UpLeft"; }
    }

    public void DefineColision()
    {
        BarrierTopLeft.X = Position.X - 100;
        BarrierTopLeft.Y = Position.Y - 50;
        BarrierBottomRight.X = Position.X + 100;
        BarrierBottomRight.Y = Position.Y + 50;
    }

    public bool Collided(Vector2 PosOfBall) // Checks collision with ball
    {
        if (((PosOfBall.X > BarrierTopLeft.X) && (PosOfBall.X < BarrierBottomRight.X) && (PosOfBall.Y < BarrierTopLeft.Y) && (PosOfBall.Y > BarrierBottomRight.Y)) == true) { return true; }
        else { return false; }
    }

    //public void Damage(Boolean hit)
    //{
    //    if (hit == true)
    //    {
    //        HitPoints -= 1;
    //    }
    //
    //    if 
    //}
}