using System;
using System.Numerics;

namespace MohawkGame2D;

public class Ball
{
    int debugcontroller = 0;
    Player Player = new Player();
    Walls Wall = new Walls();
    public Vector2 Ballposition;
    public Boolean Started = false;

    public string Direction = "none";

    public int Speed = 0;
    public int BallRadius = 15;
    public int AmountOfBall = 5;

    public void Update()
    {
        StartBall(Started);
        GameBall(Started);
        Player.Update();
        DirectionDirector();
        BouncePlayer();
        BounceWall();
        DebugRotate();
        LostBallCheck();
    }

    void StartBall(Boolean start) //starting sequence to send ball
    {
        if (start == false)
        {
            //attaches ball to player
            Ballposition.X = Player.position.X;
            Ballposition.Y = 650;

            //draws ball
            Draw.FillColor = Color.Red;
            Draw.Circle(Ballposition, BallRadius);

            if (Input.IsMouseButtonPressed(MouseButton.Left) == true)
            {
                // sends ball going weeeeee
                Direction = "Up";
                Speed = 200;
                Started = true;

            }

           
        }
    }

    void GameBall(Boolean started) //draws ball
    {
        if (started == true)
        {
            //draws ball
            Draw.FillColor = Color.Red;
            Draw.Circle(Ballposition, BallRadius);
        }
    }

    void BouncePlayer()
    {
        if (Player.HasCollided(Started, Ballposition) == true) //Checks if game started and collision
        {
            Direction = Player.WhichSide(Ballposition); //Sets direction
            Speed += 20; //Sends ball
        }
    }

    void BounceWall()
    {
        if (Wall.LeftWallCollide(Ballposition) == true) {Direction = Wall.LeftWallDirect(Direction);}
        if (Wall.RightWallCollide(Ballposition) == true) {Direction = Wall.RightWallDirect(Direction);}
        if (Wall.TopWallCollide(Ballposition) == true) {Direction = Wall.TopWallDirect(Direction);}
    }

    void LostBallCheck()
    {
        if (Wall.BottomWallCollide(Ballposition) == true)
        {
            Started = false;
            AmountOfBall -= 1;
        }
    }

        void DirectionDirector() // Sends the ball to where it must go
    {
        if (Direction == "Up")
        {
            Ballposition.Y -= Speed * Time.DeltaTime;
        }

        if (Direction == "Down")
        {
            Ballposition.Y += Speed * Time.DeltaTime;
        }

        if (Direction == "Right")
        {
            Ballposition.X += Speed * Time.DeltaTime;
        }

        if (Direction == "Left")
        {
            Ballposition.X -= Speed * Time.DeltaTime;
        }

        if (Direction == "UpRight")
        {
            Ballposition.Y -= Speed * Time.DeltaTime;
            Ballposition.X += Speed * Time.DeltaTime;
        }

        if (Direction == "UpLeft")
        {
            Ballposition.Y -= Speed * Time.DeltaTime;
            Ballposition.X -= Speed * Time.DeltaTime;
        }

        if (Direction == "DownRight")
        {
            Ballposition.Y += Speed * Time.DeltaTime;
            Ballposition.X += Speed * Time.DeltaTime;
        }

        if (Direction == "DownLeft")
        {
            Ballposition.Y += Speed * Time.DeltaTime;
            Ballposition.X -= Speed * Time.DeltaTime;
        }
    }

    void DebugRotate()
    {
        string[] debugcycle = new string[8];
        debugcycle[0] = "Up";
        debugcycle[1] = "Down";
        debugcycle[2] = "Right";
        debugcycle[3] = "Left";
        debugcycle[4] = "UpRight";
        debugcycle[5] = "UpLeft";
        debugcycle[6] = "DownRight";
        debugcycle[7] = "DownLeft";

        if (Input.IsKeyboardKeyPressed(KeyboardKey.Space) == true) {debugcontroller += 1;}
        if (debugcontroller == 8) { debugcontroller = 0; }


        if (Input.IsKeyboardKeyPressed(KeyboardKey.Space) == true) { Direction = debugcycle[debugcontroller];}
    }
}