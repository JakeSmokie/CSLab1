using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLab1.Tools
{
    static class Interface
    {
        public static void CleanPreviousLine(int offset)
        {
            Console.CursorTop -= 1;
            Console.MoveBufferArea(offset, Console.CursorTop, Console.BufferWidth - offset, 1, Console.BufferWidth, Console.CursorTop, ' ', Console.ForegroundColor, Console.BackgroundColor);
            Console.CursorLeft = offset;
        }
    }
}
