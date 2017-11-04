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
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(80, 25);
            Console.SetWindowSize(80, 25);

            Rectangle r = new Rectangle(39, 24, '#');
            r.Draw();

            Console.ReadLine();
        }
    }
}
