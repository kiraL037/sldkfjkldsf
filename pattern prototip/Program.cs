using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace pattern_prototip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prototip");
            IFigure figure1 = new Rectangle(30, 40);
            IFigure clonedFigure = figure1.Clone();
            figure1.GetInfo();
            clonedFigure.GetInfo();

            figure1 = new Circle(30);
            clonedFigure = figure1.Clone();
            figure1.GetInfo();
            clonedFigure.GetInfo();

            Console.WriteLine("Prototip 2");
            Circle2 figure2 = new Circle2(30, 50, 60);
            Circle2 clonedFigure2 = figure2.DeepCopy() as Circle2;
            figure2.Point2.X = 100;
            figure2.GetInfo2();
            clonedFigure2.GetInfo2();

            Console.Read();
        }
    }
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0}", radius);
        }
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", height, width);
        }
    }
}
    interface IFigure2
    {
        IFigure2 Clone2();
        void GetInfo2();
    }
    [Serializable]
        class Point2
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
[Serializable]
class Circle2 : IFigure2
{
    int radius2;
    public Point2 Point2 { get; set; }
    public Circle2(int r, int x, int y)
    {
        radius2 = r;
        this.Point2 = new Point2 { X = x, Y = y };
    }
    public IFigure2 Clone2()
    {
        return this.MemberwiseClone() as IFigure2;
    }
    public object DeepCopy()
    {
        object figure2 = null;
        using (MemoryStream tempStream = new MemoryStream())
        {
            BinaryFormatter binFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));

            binFormatter.Serialize(tempStream, this);
            tempStream.Seek(0, SeekOrigin.Begin);

            figure2 = binFormatter.Deserialize(tempStream);
        }
        return figure2;
    }
    public void GetInfo2()
    {
        Console.WriteLine("Круг радиусом {0} и центром в точке ({1}, {2})", radius2, Point2.X, Point2.Y);
    }
}
