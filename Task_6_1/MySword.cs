using SplashKitSDK;
using System;
using System.IO;

namespace Task_4
{
    public class MySword : Shape
    {
        private float _endX;
        private float _endY;


        public MySword() : this(SplashKit.RGBColor(169, 169, 169), 0.0f, 0.0f, 100.0f, 100.0f) { }


        public MySword(Color color, float startX, float startY, float endX, float endY) : base(color)
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
            // Calculate sword vector
            float dx = _endX - X;
            float dy = _endY - Y;
            float length = (float)Math.Sqrt(dx * dx + dy * dy);
            float normX = dx / length;
            float normY = dy / length;

            // Blade width
            float perpX = -normY;
            float perpY = normX;

            // Blade dimensions
            float bladeWidth = 8;
            float bladeLength = 60;

            // Guard dimensions
            float guardWidth = 20;
            float guardHeight = 5;

            // Handle dimensions
            float handleLength = 20;
            float handleWidth = 6;

            // Pommel radius
            float pommelRadius = 5;

            // Calculate points
            float tipX = X + normX * bladeLength;
            float tipY = Y + normY * bladeLength;

            Point2D p1 = new Point2D() { X = X + perpX * (bladeWidth / 2), Y = Y + perpY * (bladeWidth / 2) };
            Point2D p2 = new Point2D() { X = X - perpX * (bladeWidth / 2), Y = Y - perpY * (bladeWidth / 2) };
            Point2D p3 = new Point2D() { X = tipX, Y = tipY };

            // Draw blade (as triangle)
            SplashKit.FillTriangle(Color, p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);

            // Draw guard
            Point2D g1 = new Point2D() { X = X + perpX * (guardWidth / 2), Y = Y + perpY * (guardWidth / 2) };
            Point2D g2 = new Point2D() { X = X - perpX * (guardWidth / 2), Y = Y - perpY * (guardWidth / 2) };
            Point2D g3 = new Point2D() { X = g1.X + normX * guardHeight, Y = g1.Y + normY * guardHeight };
            Point2D g4 = new Point2D() { X = g2.X + normX * guardHeight, Y = g2.Y + normY * guardHeight };
            SplashKit.FillTriangle(Color, g1.X, g1.Y, g2.X, g2.Y, g3.X, g3.Y);
            SplashKit.FillTriangle(Color, g3.X, g3.Y, g2.X, g2.Y, g4.X, g4.Y);

            // Draw handle
            float handleBaseX = X - normX * handleLength;
            float handleBaseY = Y - normY * handleLength;
            Point2D h1 = new Point2D() { X = X + perpX * (handleWidth / 2), Y = Y + perpY * (handleWidth / 2) };
            Point2D h2 = new Point2D() { X = X - perpX * (handleWidth / 2), Y = Y - perpY * (handleWidth / 2) };
            Point2D h3 = new Point2D() { X = handleBaseX - perpX * (handleWidth / 2), Y = handleBaseY - perpY * (handleWidth / 2) };
            Point2D h4 = new Point2D() { X = handleBaseX + perpX * (handleWidth / 2), Y = handleBaseY + perpY * (handleWidth / 2) };
            SplashKit.FillTriangle(Color, h1.X, h1.Y, h2.X, h2.Y, h3.X, h3.Y);
            SplashKit.FillTriangle(Color, h3.X, h3.Y, h4.X, h4.Y, h1.X, h1.Y);

            // Draw pommel
            SplashKit.FillCircle(Color, handleBaseX, handleBaseY, pommelRadius);

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
            writer.WriteLine("Sword");
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
