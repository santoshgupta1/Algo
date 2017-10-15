using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawHTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(1000, 1000);
            DrawHTree(50, 50, 30, 4);
            Console.ReadKey();
        }

        static void DrawHTree(float x, float y, float length, int depth)
        {
            if(depth == 0)
            {
                return;
            }

            DrawLine(x - length / 2, y, x + length / 2, y);
            DrawLine(x - length / 2, y - (float)(length / 2), x - length / 2, y + (float)(length / 2));
            DrawLine(x + length / 2, y - (float)(length / 2), x + length / 2, y + (float)(length / 2));

            DrawHTree(x - length / 2, y - length / 2, (length/2), depth - 1);
            DrawHTree(x - length / 2, y + length / 2, (length / 2), depth - 1);
            DrawHTree(x + length / 2, y - length / 2, (length / 2), depth - 1);
            DrawHTree(x + length / 2, y + length / 2, (length / 2), depth - 1);
        }

        static void DrawLine(float aX1, float aY1, float aX2, float aY2)
        {
            int x1 = (int)aX1;
            int x2 = (int)aX2;
            int y1 = (int)aY1;
            int y2 = (int)aY2;
            if ((x2!=x1 && y2!= y1) || (x1>x2) || (y1>y2))
            {
                throw new InvalidOperationException("Points not correct");
            }
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            int size = Console.CursorSize;
            Console.CursorLeft = x1;
            Console.CursorTop = y1;
            while(x1 < x2)
            {
                x1++;
                Console.CursorTop = y1;
                Console.Write("-");
            }
            while (y1 < y2)
            {
                y1++;
                Console.CursorLeft = x1;
                Console.Write("|" + "\n");
            }
        }
    }
}
