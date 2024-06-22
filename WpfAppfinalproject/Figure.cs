using System.Drawing;

namespace WpfAppfinalproject
{
	abstract public class Figure
    {
        protected Point center;
		protected double scale;
		protected bool dragged;
		protected Color color;
		public Point center_figure
		{
			get { return (center); }
			set { center = value; }
		}
		public double scale_figure
		{
			get { return (scale); }
			set { scale = value; }
		}
		public bool dragged_figure
		{
			get { return (dragged); }
			set { dragged = value; }
		}
		public Color color_figure
		{
			get { return (color); }
			set { color = value; }
		}
		public Figure(int x, int y)
		{
			center = new Point(x, y);
			scale = 1;
			dragged = false;
			color = Color.ForestGreen;
		}
		public void Move(int a, int b)
		{
			center.X += a; center.Y += b;
		}
		public void Scale(double s)
		{
			scale *= s;
		}
		public abstract void Show(Graphics g, Pen pen, Brush brush);
		public abstract Rectangle Region_Capture();
	}
}

