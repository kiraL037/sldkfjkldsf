using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class CPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CPoint()
        {

        }
        public CPoint(int x, int y)
        {
            X = x;
            Y = y; 
        }
        public override string ToString()
        {
            return "{X=" + X + ", Y=" + Y + "}";
        }
    }
}
