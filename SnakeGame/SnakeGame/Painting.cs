using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Helper
{
    class Vector2
    {
        public int x;
        public int y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">It's X of Object</param>
        /// <param name="b">It's Y of Object</param>
        public Vector2(int a, int b)
        {
            x = a;
            y = b;
        }

        #region Operators of Vector2
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2(0, 0);
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            return c;
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2(0, 0);
            c.x = a.x - b.x;
            c.y = a.y - b.y;
            return c;
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2(0, 0);
            c.x = a.x * b.x;
            c.y = a.y * b.y;
            return c;
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            Vector2 c = new Vector2(0, 0);
            c.x = a.x / b.x;
            c.y = a.y / b.y;
            return c;
        }

        public static bool operator >(Vector2 a, Vector2 b)
        {
            bool c;
            c = a.x > b.x && a.y > b.y;
            return c;
        }

        public static bool operator <(Vector2 a, Vector2 b)
        {
            bool c;
            c = a.x > b.x && a.y > b.y;
            return c;
        }

        public static bool operator >=(Vector2 a, Vector2 b)
        {
            bool c;
            c = a.x >= b.x && a.y >= b.y;
            return c;
        }

        public static bool operator <=(Vector2 a, Vector2 b)
        {
            bool c;
            c = a.x >= b.x && a.y >= b.y;
            return c;
        }
        #endregion
    }

    class Figur
    {
        public char ch;
        public ConsoleColor c;
        public ConsoleColor bgC;

        public Figur(char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black)
        {
            ch = _ch;
            c = _c;
            bgC = _bgC;
        }

        public void DrawFigur(Point[,] p)
        {
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    if (p[i, j] != null)
                    {
                        p[i, j].Draw();
                    }
                }
            }
        }
    }

    class Point : Figur
    {
        public Vector2 v;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_v">It's Vector of symbol</param>
        /// <param name="_ch">It's Character of symbol</param>
        /// <param name="_c">It's Color of symbol</param>
        /// <param name="_bgC">It's BackGroung Color of symbol</param>
        public Point(Vector2 _v, char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black) : base (_ch, _c, _bgC) { v = _v; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_x">It's X of symbol</param>
        /// <param name="_y">It's Y of symbol</param>
        /// <param name="_ch">It's Character of symbol</param>
        /// <param name="_c">It's Color of symbol</param>
        /// <param name="_bgC">It's BackGroung Color of symbol</param>
        public Point(int _x, int _y, char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black) : base (_ch, _c, _bgC) { v = new Vector2(_x, _y); }

        /// <summary>
        /// Paint your point
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(v.x * 2, v.y);
            Console.BackgroundColor = bgC;
            Console.ForegroundColor = c;
            Console.Write(ch);
            Console.ResetColor();
        }
    }

    class Line : Figur
    {
        public Vector2 v1;
        public Vector2 v2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_v1">It's From Vector of symbol</param>
        /// <param name="_v2">It's To Vector of symbol</param>
        /// <param name="_ch">It's Character of symbol</param>
        /// <param name="_c">It's Color of symbol</param>
        /// <param name="_bgC">It's BackGroung Color of symbol</param>
        public Line(Vector2 _v1, Vector2 _v2, char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black) : base (_ch, _c, _bgC)
        {
            Vector2 v1 = /*_v1 == _v2 ? new Vector2(0, 0) : */_v1;
            v2 = (v1 >= _v2) ? v1 : _v2;
            v1 = (v1 >= _v2) ? v1 : _v1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_x1">It's From X of symbol</param>
        /// <param name="_y1">It's From Y of symbol</param>
        /// <param name="_x2">It's To X of symbol</param>
        /// <param name="_y2">It's To Y of symbol</param>
        /// <param name="_ch">It's Character of symbol</param>
        /// <param name="_c">It's Color of symbol</param>
        /// <param name="_bgC">It's BackGroung Color of symbol</param>
        public Line(int _x1, int _y1, int _x2, int _y2, char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black) : base(_ch, _c, _bgC)
        {
            int x1 = /*_x1 == _x2 ? 0 : */_x1;
            int y1 = /*_y1 == _y1 ? 0 : */_y1;
            Vector2 _v1 = new Vector2(x1, y1);
            Vector2 _v2 = new Vector2(_x2, _y2);
            v2 = (_v1 >= _v2) ? _v1 : _v2;
            v1 = (_v1 >= _v2) ? _v2 : _v1;
        }

        private Point[,] GetLine(Vector2 _v1, Vector2 _v2)
        {
            Vector2 a = _v2 - _v1;
            Point[,] p = new Point[a.x + 1, a.y + 1];

            int x = a.x > a.y ? a.x : a.y;
            int y = a.x > a.y ? a.y : a.x;

            double z = y / x;

            int i = 0;

            for (double j = 0; i <= x; i++, j += z)
            {
                if (x == a.x)
                {
                    p[i, (int)j] = new Point(i + _v1.x, (int)j + _v1.y, ch);
                }
                else
                {
                    p[(int)j, i] = new Point((int)j + _v1.x, i + _v1.y, ch);
                }
            }

            return p;
        }

        public void Draw()
        {
            DrawFigur(GetLine(v1, v2));
        }
    }

    class Rectangle : Figur
    {
        int l;
        int h;

        public Rectangle(Vector2 _v, char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black) : base (_ch, _c, _bgC)
        {
            l = _v.x;
            h = _v.y;
        }

        public Rectangle(int _x, int _y, char _ch, ConsoleColor _c = ConsoleColor.White, ConsoleColor _bgC = ConsoleColor.Black) : base (_ch, _c, _bgC)
        {
            l = _x;
            h = _y;
        }

        public void Draw()
        {
            Line l0 = new Line(0, 0, l, 0, ch);
            l0.Draw();
            Line l1 = new Line(0, 0, 0, h, ch);
            l1.Draw();
            Line l2 = new Line(0, h, l, h, ch);
            l2.Draw();
            Line l3 = new Line(l, 0, l, h, ch);
            l3.Draw();
        }
    }

    enum Direction
    {
        up,
        down,
        right,
        left
    }
}