using SplashKitSDK;
using System;
using System.IO;

namespace Task_4
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;


        public MyRectangle() : this(SplashKit.ColorGreen(), 0.0f, 0.0f, 100 + 69, 100 + 69)
        {
        }

        // Constructor with parameters.
        public MyRectangle(Color color, float x, float y, int width, int height)
            : base(color)
        {
            X = x;
            Y = y;
            _width = 100;
            _height = 200;
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



            SplashKit.FillEllipse(Color, X - (_width / 2.0f), Y - (_height / 2.0f), _width, _height);
            if (Selected)
            {
                DrawOutline();
            }
        }


        public override void DrawOutline()
        {
            int extra = 5;
            SplashKit.DrawRectangle(SplashKit.ColorBlack(), X - extra, Y - extra, _width + 2 * extra, _height + 2 * extra);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
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
