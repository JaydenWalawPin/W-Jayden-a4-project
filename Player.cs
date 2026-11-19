using System;
using System.Numerics;
using System.Runtime.Serialization;

namespace MohawkGame2D;

public class Player
{
    // Position of player
    public Vector2 position;
    public Vector2 HitboxTCL; //Top Corner Left
    public Vector2 HitboxTCR; // Top Corner Right
    public int test = 1;

    public void Setup()
    {

    }

    public void Update()
    {
        Capsule();
        CapsuleBoundaries();
    }

    void Capsule()
    {
        // Set player positon
        position.X = Input.GetMouseX();
        position.Y = Input.GetMouseY();
        // Folow Mouse vertically
        Draw.FillColor = Color.Black;
        Draw.Capsule(position.X - 30, 700, position.X + 30, 700, 20);
    }

    void CapsuleBoundaries()
    {
        //Top Corner Left XY
        HitboxTCL.X = Input.GetMouseX() -30;
        HitboxTCL.Y = 720;
        //Top Corner Right XY
        HitboxTCR.X = Input.GetMouseX() + 30;
        HitboxTCR.Y = 720;
    }
    public bool HasCollided(Boolean Start, Vector2 BallPos) // Determines if the ball has collided with the capsule
    {
        if (Start == true) // Checks if the ball is free
        {
            if ((BallPos.X > HitboxTCL.X) || (BallPos.X < HitboxTCR.X) || (BallPos.Y > 720)) // checks if Ball is colliding with Capsule
            {
                return true; 
            }
            else {return false;}
        }
        else {return false;}
    }
    public string WhichSide(Vector2 PosOfHit) // Determines which side ball bounces when collide
    {
        if (PosOfHit.X > position.X) {return "UpRight";} // if position of hit is to the right of the centre send it UpRight
        else {return "UpLeft";} // if not, send it UpLeft
    }
}