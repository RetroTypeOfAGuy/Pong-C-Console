using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    class Ball:GameElement
    {
        string Color { get; set; }
        GameElement Pad { get; set; }
        public Ball(IRenderer rend,Direction dir,Position pos,string color):base(rend,dir,pos)
        {
            this.Color = color;
        }
        public override void Draw()
        {
            this.Renderer.DrawAt(this.Position, this.Color);
        }

        public override void Remove()
        {
            this.Renderer.DrawAt(this.Position, "Black");
        }

        public override void ChangePosition()
        {
            this.Position = this.Direction.ChangeToPosition(this.Position);
        }      
    }
}
