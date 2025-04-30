using SplashKitSDK;
using System;
using System.IO;

namespace Task_4
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;


        public MyLine() : this(SplashKit.ColorRed(), 0.0f, 0.0f, 100.0f, 100.0f) { }


        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        public override void Draw()
        {
            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
            if (Selected)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {

            SplashKit.DrawCircle(SplashKit.ColorBlack(), X, Y, 3);
            SplashKit.DrawCircle(SplashKit.ColorBlack(), _endX, _endY, 3);
        }

        public override bool IsAt(Point2D pt)
        {

            double distance = PointToLineDistance(pt, new Point2D { X = X, Y = Y }, new Point2D { X = _endX, Y = _endY });

            return distance <= 5;
        }


        private double PointToLineDistance(Point2D p, Point2D a, Point2D b)
        {
            double A = p.X - a.X;
            double B = p.Y - a.Y;
            double C = b.X - a.X;
            double D = b.Y - a.Y;
            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = (len_sq != 0) ? dot / len_sq : -1;
            double xx, yy;

            if (param < 0)
            {
                xx = a.X;
                yy = a.Y;
            }
            else if (param > 1)
            {
                xx = b.X;
                yy = b.Y;
            }
            else
            {
                xx = a.X + param * C;
                yy = a.Y + param * D;
            }

            double dx = p.X - xx;
            double dy = p.Y - yy;
            return Math.Sqrt(dx * dx + dy * dy);


        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_endX);
            writer.WriteLine(_endY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _endX = reader.ReadSingle();
            _endY = reader.ReadSingle();
        }
    }
}
