using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStart
{
    public class ConsoleControls:IControls
    {
        public string GetControlKey()
        {
            return Console.Read().ToString();
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
