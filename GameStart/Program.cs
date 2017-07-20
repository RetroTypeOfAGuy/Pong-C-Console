using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    class Program
    {
        static void Main(string[] args)
        {
            IControls color = new ConsoleControls();

            IRenderer renderer = new ConsoleRenderer();

            Direction direction = new Direction();

            GameEngins engine = new ConsoleEngine(renderer, color, direction);

            engine.GameStart();
            engine.GameOver();

            
        }
    }
}
