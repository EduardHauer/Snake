using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(0, 0, 'E', ConsoleColor.Blue, ConsoleColor.DarkGray);
            p.Paint();

            Console.ReadLine();
        }
    }
}
