using System;
using System.Drawing;

namespace WpfAppfinalproject
{
    public class Rect : Figure
	{
		int sideA, sideB;
		Rectangle rect;
		public Rect(int sideA, int sideB, int x, int y) : base(x, y)
		{
			this.sideA = sideA; this.sideB = sideB;
			rect = Init();
		}
		public override void Show(Graphics g, Pen pen, Brush brush)
		{
			rect = Init();
			g.DrawRectangle(pen, rect);
			g.FillRectangle(brush, rect);
		}
		public override Rectangle Region_Capture()
		{
			rect = Init();
			return rect;
		}
		Rectangle Init()
		{
			int a = Convert.ToInt32(sideA * scale);
			int b = Convert.ToInt32(sideB * scale);
			int leftupX = center.X - a / 2;
			int leftupY = center.Y - b / 2;
			return new Rectangle(leftupX, leftupY, a, b);
		}
	}
}
