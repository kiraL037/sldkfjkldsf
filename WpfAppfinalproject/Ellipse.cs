using System;
using System.Drawing;

namespace WpfAppfinalproject
{
    public class Ellipse : Figure
    {
        int axisA, axisB;
        Rectangle rect;
        public Ellipse(int A, int B, int x, int y) : base(x, y)
        {
            axisA = A; axisB = B;
            rect = Init();
        }
        public override void Show(Graphics g, Pen pen, Brush brush)
        {
            rect = Init();
            g.DrawEllipse(pen, rect);
            g.FillEllipse(brush, rect);
        }
        public override Rectangle Region_Capture()
        {
            rect = Init();
            return rect;
        }
        Rectangle Init()
        {
            int a = Convert.ToInt32(axisA * scale);
            int b = Convert.ToInt32(axisB * scale);
            int leftupX = center.X - a;
            int leftupY = center.Y - b;
            return new Rectangle(leftupX, leftupY, 2 * a, 2 * b);
        }
    }
}

