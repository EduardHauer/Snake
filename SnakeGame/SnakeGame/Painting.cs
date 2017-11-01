using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Painting
{
    class Point
    {
        public int x;
        public int y;
        public char objChar;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">It's X of symbol</param>
        /// <param name="b">It's Y of symbol</param>
        /// <param name="ch">It's Letter/Nmber/... of symbol</param>
        public Point(int a, int b, char ch)
        {
            x = a;
            y = b;
            objChar = ch;
        }

        /// <summary>
        /// Paint your point
        /// </summary>
        public void Paint()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(objChar);
        }
    }
}