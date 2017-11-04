using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper;
using SnakeHelper;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);

            Rectangle r = new Rectangle(39, 24, '#');
            r.Draw();

            Snake s = new Snake(new Vector2(20, 12), Direction.left, 6, '-');
            s.Draw();

            Console.ReadLine();
        }
    }
}
