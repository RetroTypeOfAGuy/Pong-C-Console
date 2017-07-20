using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public abstract class GameElement
    {
        public IRenderer Renderer { get; set; }
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public int Hight { get; set; }
        public int Width { get; set; }

        public GameElement(IRenderer rend,Direction dir, Position pos)
        {
            this.Direction = dir;
            this.Position = pos;
            this.Renderer = rend;
        }

        public abstract void Draw();
        public abstract void Remove();
        public abstract void ChangePosition();

    }
}
