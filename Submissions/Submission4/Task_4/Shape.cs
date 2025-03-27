using SplashKitSDK;
using System;
// Initializing class (object blueprint)

namespace Task_4
{

    class Shape
    {
        //Fields (Characteristics)
        private Color _color;
        private float _x;
        private float _y;
        private int _width;
        private int _height;

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }


        public Shape(int param)
        {
            Color = SplashKit.ColorChocolate();

            // Initialize position and size
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }

        // Initialize method (Actions)
        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            Console.WriteLine("Color is " + _color);
            Console.WriteLine("Position X is " + _x);
            Console.WriteLine("Position Y is " + _y);
            Console.WriteLine("Width is " + _width);
            Console.WriteLine("Height is " + _height);
        }

        public void DisplayCentre()
        {
            _x = 50f;
            _y = 50f;
            Console.WriteLine($"The shape is now centred at x:{_x} and y:{_y} ");
        }


        public bool IsAt(Point2D pt)
        {
            return pt.X >= _x && pt.X <= _x + _width &&
                   pt.Y >= _y && pt.Y <= _y + _height;
        }

        // Add properties

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