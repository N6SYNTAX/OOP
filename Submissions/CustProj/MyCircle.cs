using SplashKitSDK;
using System;
using System.IO;

namespace Task_4
{
    public class MyCircle : Shape
    {
        private int _radius;


        public MyCircle() : this(SplashKit.ColorBlue(), 0.0f, 0.0f, 50 + 69) { }


        public MyCircle(Color color, float x, float y, int radius)
            : base(color)
        {
            X = x;
            Y = y;
            _radius = radius;
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, _radius);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {

            SplashKit.DrawCircle(SplashKit.ColorBlack(), X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            double dx = pt.X - X;
            double dy = pt.Y - Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            return distance <= _radius;
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }

    }
}
