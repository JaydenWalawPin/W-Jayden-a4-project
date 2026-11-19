using System;
using System.Numerics;

namespace MohawkGame2D;

public class Walls
{

    public void Update()
    {
    }

    public string LeftWallDirect(string PrevDirect) // Sends ball to the right direction after collission with left wall
    {
        if (PrevDirect == "UpLeft") {return "UpRight";} else {return "DownRight";}
    }

    public string RightWallDirect(string PrevDirect) // Sends ball to the right direction after collission with right wall
    {
        if (PrevDirect == "UpRight") {return "UpLeft";} else {return "DownLeft";}
    }

    public bool LeftWallCollide(Vector2 PosOfBall) // Checks collission for left wall
    {
        if (PosOfBall.X < 0) {return true;} else {return false;}
    }

    public bool RightWallCollide(Vector2 PosOfBall) // Checks collission for right wall
    {
        if (PosOfBall.X > 600) {return true;} else {return false;}
    }

    public bool TopWallCollide(Vector2 PosOfBall) // Check collission for top wall
    {
        if (PosOfBall.Y < 0) {return true;} else {return false;}
    }

    public string TopWallDirect(string PrevDirect) // sends ball to the right direction after collission with top wall
    {
        if (PrevDirect == "UpRight") {return "DownRight";}
        else if (PrevDirect == "Up") {return "Down"; }
        else {return "DownLeft";}
    }

    public bool BottomWallCollide(Vector2 PosOfBall) // Check if Ball was lost in play area
    {
        if (PosOfBall.Y > 800) {return true;} else {return false;}
    }
}