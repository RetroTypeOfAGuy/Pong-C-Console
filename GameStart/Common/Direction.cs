using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public class Direction
    {
        public string Dir { get; set; }

        public void MoveLeft()
        {
            this.Dir = "left";
        }
        public void MoveRight()
        {
            this.Dir = "right";
        }
        public void MoveUp()
        {
            this.Dir = "up";
        }
        public void MoveDown()
        {
            this.Dir = "down";
        }
        public void Stop()
        {
            this.Dir = "noMove";
        }

        public Position ChangeToPosition(Position pos)
        {
            switch(this.Dir)
            {
                case "left":
                    pos = new Position(pos.Y, pos.X-1);
                    break;
                case "right":
                    pos = new Position(pos.Y, pos.X+1);
                    break;
                case "up":
                    pos = new Position(pos.Y-1, pos.X);
                    break;
                case "down":
                    pos = new Position(pos.Y+1, pos.X);
                    break;
                case "diagonalUpRight":
                    pos = new Position(pos.Y-1, pos.X + 1);
                    break;
                case "diagonalUpLeft":
                    pos = new Position(pos.Y-1, pos.X - 1);
                    break;
                case "diagonalDownRight":
                    pos = new Position(pos.Y + 1, pos.X + 1);
                    break;
                case "diagonalDownLeft":
                    pos = new Position(pos.Y + 1, pos.X - 1);
                    break;
                
            }
                    return pos;
            
        }

        public void RandomDiag()
        {
            Random rnd = new Random();
            int random = rnd.Next(1,4);

            switch(random)
            {
                case 1:
                    this.Dir = "diagonalUpLeft";
                    break;
                case 2:
                    this.Dir = "diagonalUpRight";
                    break;
                case 3:
                    this.Dir = "diagonalDownLeft";
                    break;
                case 4:
                    this.Dir = "diagonalDownRight";
                    break;
                default:
                    break;
            }
        }
    }
}
