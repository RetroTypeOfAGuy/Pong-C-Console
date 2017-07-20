using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    class Pad:GameElement
    {
        Position MaxPosition { get; set; }
        public string Color { get; set; }
        public Pad(IRenderer rend,Direction dir, Position pos, int hight, string color,Position max)
            :base(rend,dir,pos)
        {
            this.Hight = hight;
            this.Color = color;
            this.MaxPosition = max;

        }
        public override void Draw()
        {

            Position DrawPosition = new Position(this.Position.Y, this.Position.X);
            for (int i = 0; i < this.Hight; i++)
            {
                this.Renderer.DrawAt(DrawPosition = new Position(DrawPosition.Y + 1, DrawPosition.X), this.Color);
            }
        
            
        }

        public override void ChangePosition()
        {
            if (this.Position.Y == this.MaxPosition.Y-2-Hight && this.Direction.Dir == "down")
            {
                
            }
            else if (this.Position.Y == 0 && this.Direction.Dir == "up")
            {
                
            }
            else
            {
                this.Position = this.Direction.ChangeToPosition(this.Position);
            }
        }

        public override void Remove()
        {
            Position DrawPosition = new Position(this.Position.Y, this.Position.X);
            for (int i = 0; i < this.Hight; i++)
            {
                this.Renderer.DrawAt(DrawPosition = new Position(DrawPosition.Y+1,DrawPosition.X), "Black");
            }
            
        }


        
    }
}
