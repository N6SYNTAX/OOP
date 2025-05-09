using SplashKitSDK;
using System;

namespace Task_4
{
    public class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        // Add the Selected property
        public bool Selected { get; set; } = false;

        public Shape(int param)
        {
            // Default color, position, and dimensions.
            Color = SplashKit.ColorChocolate();
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            string xpoint = Convert.ToString(_x);
            string ypoint = Convert.ToString(_y);
            string points = xpoint + ", " + ypoint;

            SplashKit.DrawText(points, Color.Black, _x, _y);

        }

        public bool IsAt(Point2D pt)
        {
            return pt.X >= _x && pt.X <= _x + _width &&
                   pt.Y >= _y && pt.Y <= _y + _height;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

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
    }
}