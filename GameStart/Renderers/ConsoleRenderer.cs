using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public class ConsoleRenderer : IRenderer
    {
        public ConsoleColor Color { get; set; }
        public Dictionary<string, ConsoleColor> colors = new Dictionary<string, ConsoleColor>();

        public ConsoleRenderer()
        {
            
            Type type = typeof(ConsoleColor);
            foreach (var name in Enum.GetNames(type))
            {
                this.colors.Add(name, (ConsoleColor)Enum.Parse(type, name));
            }

        }


        private void DetectColor(string color)
        {
            foreach (KeyValuePair<string,ConsoleColor> pair in this.colors)
            {
                if (pair.Key == color)
                {
                    this.Color = pair.Value;
                    break;
                }
            }
        }


        public void DrawAt(Position position, string color)
        {
            DetectColor(color);
            Console.SetCursorPosition(position.X, position.Y);
            Console.BackgroundColor = this.Color;            
            Console.Write(' ');      
        }
    }
}