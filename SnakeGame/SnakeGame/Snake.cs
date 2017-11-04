using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Helper;

namespace SnakeHelper
{
    class Snake : Figur
    {
        Direction d;
        List<Point> t;
        Vector2 v;
        int l;

        public Snake(Vector2 _v, Direction _d, int _l, char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black) : base(_ch, _c, _bgC)
        {
            v = _v;
            d = _d;
            l = _l;
            t = new List<Point>();
        }

        private Point[,] GetTail()
        {
            if (d == Direction.up || d == Direction.down)
            {
                ch = '|';
            }
            else
            {
                ch = '-';
            }

            Point[,] p = new Point[1, l];

            for (int i = 0; i < l; i++)
            {
                Point p1 = new Point(new Vector2(v.x, v.y), ch);
                p1.Move(i, d);
                t.Add(p1);
                p[0, i] = new Point(p1);
            }

            return p;
        }

        public void Draw()
        {
            DrawFigur(GetTail());
        }
    }
}