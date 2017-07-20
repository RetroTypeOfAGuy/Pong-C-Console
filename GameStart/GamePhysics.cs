using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public class GamePhysics
    {
        public GameElement Pad1 { get; set; }
        public GameElement Pad2 { get; set; }
        public GameElement Ball { get; set; }
        public GameElement Border { get; set; }
        GameElement Pad { get; set; }

        public GamePhysics(GameElement pad1, GameElement pad2, GameElement Ball, GameElement border)
        {
            this.Pad1 = pad1;
            this.Pad2 = pad2;
            this.Ball = Ball;
            this.Border = border;
            BallReset();
        }

        public void BorderBounce()
        {
            if (this.Ball.Direction.Dir == "diagonalUpLeft" && this.Ball.Position.Y == 1)
                this.Ball.Direction.Dir = "diagonalDownLeft";
            if (this.Ball.Direction.Dir == "diagonalUpRight" && this.Ball.Position.Y == 1)
                this.Ball.Direction.Dir = "diagonalDownRight";
            if (this.Ball.Direction.Dir == "diagonalDownLeft" && this.Ball.Position.Y == this.Border.Position.Y - 2)
                this.Ball.Direction.Dir = "diagonalUpLeft";
            if (this.Ball.Direction.Dir == "diagonalDownRight" && this.Ball.Position.Y == this.Border.Position.Y - 2)
                this.Ball.Direction.Dir = "diagonalUpRight";
        }

        public void PadBounce(GameElement pad)
        {
            this.Pad = pad;   
            for (int i = 0; i < Pad1.Hight; i++)
            {
                if (this.Ball.Position.Y == this.Pad.Position.Y + i) 
                {
                    switch(this.Ball.Direction.Dir)
                    {
                        case "diagonalUpLeft":
                            this.Ball.Direction.Dir = "diagonalUpRight";
                            break;
                        case "diagonalUpRight":
                            this.Ball.Direction.Dir = "diagonalUpLeft";
                            break;
                        case "diagonalDownLeft":
                            this.Ball.Direction.Dir = "diagonalDownRight";
                            break;
                        case "diagonalDownRight":
                            this.Ball.Direction.Dir = "diagonalDownLeft";
                            break;
                    }
                }
            }
        }

        public void BallReset()
        {
            if (this.Ball.Position.X == 1 || this.Ball.Position.X == this.Border.Position.X - 2)
            {
                this.Ball.Position = new Position(this.Border.Position.Y / 2, this.Border.Position.X / 2);
                this.Ball.Direction.Stop();
            }
        }

        

        

    }
}
