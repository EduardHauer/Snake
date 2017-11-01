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
            char[,] m = new char[,]
            {
                { ' ', '#', '#', '#', ' '},
                { '#', ' ', '|', ' ', '#'},
                { '#', '-', ' ', '-', '#'},
                { '#', ' ', '|', ' ', '#'},
                { ' ', '#', '#', '#', ' '}
            };

            Point[,] p = new Point[m.GetLength(0), m.GetLength(1)];

            p = Vector2.GetScene(p, m, new Point(2, 2, 'H'));

            Vector2.DrawScene(p);
            Console.ReadLine();
        }
    }
}
