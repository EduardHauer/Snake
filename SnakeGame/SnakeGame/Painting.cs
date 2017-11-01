﻿using System;
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
        #endregion

        public static Point[,] GetScene(Point[,] p, char[,] map, params Point[] other)
        {
            int height = map.GetLength(0);
            int lenght = map.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (p[i, j] != null)
                    {
                        p[i, j].objChar = map[i, j];
                        p[i, j].objVector.x = j;
                        p[i, j].objVector.y = i;
                    }
                    else
                    {
                        p[i, j] = new Point(j, i, ' ');
                        p[i, j].objChar = map[i, j];
                    }
                }
            }
            for (int l = 0; l < other.Length; l++)
            {
                p[other[l].objVector.x, other[l].objVector.y].objChar = other[l].objChar;
            }
            return p;
        }
        public static void DrawScene(Point[,] p)
        {
            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    Console.Write("");
                    p[i, j].Draw();
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
    class Point
    {
        public Vector2 objVector;
        public char objChar;
        public ConsoleColor objColor;
        public ConsoleColor backgroundColor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v">It's Vector of symbol</param>
        /// <param name="ch">It's Character of symbol</param>
        /// <param name="c">It's Color of symbol</param>
        /// <param name="bgC">It's BackGroung Color of symbol</param>
        public Point(Vector2 v, char ch, ConsoleColor c = ConsoleColor.White, ConsoleColor bgC = ConsoleColor.Black)
        {
            objVector = v;
            objChar = ch;
            objColor = c;
            backgroundColor = bgC;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">It's X of symbol</param>
        /// <param name="b">It's Y of symbol</param>
        /// <param name="ch">It's Character of symbol</param>
        /// <param name="c">It's Color of symbol</param>
        /// <param name="bgC">It's BackGroung Color of symbol</param>
        public Point(int a, int b, char ch, ConsoleColor c = ConsoleColor.White, ConsoleColor bgC = ConsoleColor.Black)
        {
            objVector = new Vector2(a, b);
            objChar = ch;
            objColor = c;
            backgroundColor = bgC;
        }

        /// <summary>
        /// Paint your point
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(objVector.x * 2, objVector.y);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = objColor;
            Console.Write(objChar);
            Console.ResetColor();
        }
    }
}