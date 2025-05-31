using SplashKitSDK;
using System;
using System.IO;

namespace Task_4
{
    public class MyEllipse : Shape
    {
        private int _width;
        private int _height;


        public MyEllipse() : this(SplashKit.ColorGreen(), 0.0f, 0.0f, 100 + 69, 100 + 69)
        {
        }

        // Constructor with parameters.
        public MyEllipse(Color color, float x, float y, int width, int height)
            : base(color)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }

        // Public properties for width and height.
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }


        public override void Draw()
        {
            SplashKit.FillEllipse(Color, X, Y, _width, _height);
            if (Selected)
            {
                DrawOutline();
            }
        }


        public override void DrawOutline()
        {
            int extra = 5;

            SplashKit.DrawEllipse(SplashKit.ColorBlack(), X - 1.5, Y - 1.5, _width + extra, _height + extra);

        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Ellipse");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }


        public override bool IsAt(Point2D pt)
        {
            return pt.X >= X && pt.X <= (X + _width) &&
                   pt.Y >= Y && pt.Y <= (Y + _height);
        }
    }
}
