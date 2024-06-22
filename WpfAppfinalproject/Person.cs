using System;

namespace WpfAppfinalproject
{
    public class Person : Figure
	{
		int head_h;
		Circle head;
		Rect body;
		LittleCircle nose;
		public Person(int head_h, int x, int y) : base(x, y)
		{
			this.head_h = head_h;
			head = new Circle(head_h, x, y);
			int body_x = x;
			int body_y = y + 3 * head_h;
			int body_w = 2 * head_h;
			int body_h = 4 * head_h;
			body = new Rect(body_w, body_h, body_x, body_y);
			nose = new LittleCircle(x + head_h + 2, y);
		}
		public override void Show(System.Drawing.Graphics g, System.Drawing.Pen pen, System.Drawing.Brush brush)
		{
			int h = Convert.ToInt32(head_h * scale);
			int top_x = center.X - h;
			int top_y = center.Y - h;
			g.DrawEllipse(pen, top_x, top_y, 2 * h, 2 * h);
			g.FillEllipse(brush, top_x, top_y, 2 * h, 2 * h);
			top_y += 2 * h;
			g.DrawRectangle(pen, top_x, top_y, 2 * h, 4 * h);
			g.FillRectangle(brush, top_x, top_y, 2 * h, 4 * h);
			top_y -= h;
			top_x += 2 * h;
			g.DrawEllipse(pen, top_x, top_y, 8, 8);
			g.FillEllipse(brush, top_x, top_y, 8, 8);
		}
		public override System.Drawing.Rectangle
			Region_Capture()
		{
			int h = Convert.ToInt32(head_h * scale);
			int top_x = center.X - h;
			int top_y = center.Y - h;
			return new
				System.Drawing.Rectangle(top_x, top_y, 2 * h, 2 * h);
		}
	}
}

