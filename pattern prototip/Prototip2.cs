using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace pattern_prototip
{
    class Prototip2
    {
        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
        }
        [Serializable]
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        [Serializable]
        class Circle : IFigure
        {
            int radius;
            public Point Point { get; set; }
            public Circle(int r, int x, int y)
            {
                radius = r;
                this.Point = new Point { X = x, Y = y };
            }

            public IFigure Clone()
            {
                return this.MemberwiseClone() as IFigure;
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
            public void GetInfo()
            {
                Console.WriteLine("Круг радиусом {0} и центром в точке ({1}, {2})", radius, Point.X, Point.Y);
            }
        }

    }
}
