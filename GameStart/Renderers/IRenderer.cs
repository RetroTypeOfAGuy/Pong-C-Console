using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public interface IRenderer
    {
        void DrawAt(Position position, string color);

    }
}
