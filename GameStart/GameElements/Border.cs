using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public  class Border:GameElement
    {
        public IRenderer Renderer { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public Border(IRenderer rend, Direction dir, Position pos):base(rend,dir,pos)
        {
            this.Renderer = rend;
            this.Position = pos;
        }
        public override void Draw()
        {
            Position DrawPosition = new Position(0, 0);
            for (int col = 0; col < this.Position.X; col++)
            {
                for (int row = 0; row < this.Position.Y; row++)
                {
                    if (row == 0 ||  row == this.Position.Y-1 )
                    {
                         DrawPosition = new Position(row, col);
                        this.Renderer.DrawAt(DrawPosition, "Green");
                    }
                    else if (col == this.Position.X-1 || col == 0)
                    {
                         DrawPosition = new Position(row, col);
                        this.Renderer.DrawAt(DrawPosition, "Green");
                    }
                }
            }
        }

        public override void Remove()
        {
            throw new NotImplementedException();
        }

        public override void ChangePosition()
        {
            throw new NotImplementedException();
        }

    }
}
