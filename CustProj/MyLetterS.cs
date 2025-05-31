using SplashKitSDK;
using System;
using System.IO;

namespace Task_4
{
    public class MyLetterS : Shape
    {
        private const float Width = 60;
        private const float Thickness = 10;
        private const float Height = 80;

        public MyLetterS() : this(SplashKit.ColorBlack(), 100, 100) { }

        public MyLetterS(Color color, float x, float y) : base(color)
        {
            X = x;
            Y = y;
        }

        public override void Draw()
        {
            // Top bar
            SplashKit.FillRectangle(Color, X, Y, Width, Thickness);

            // Top left vertical
            SplashKit.FillRectangle(Color, X, Y, Thickness, Height / 2);

            // Middle bar
            SplashKit.FillRectangle(Color, X, Y + Height / 2 - Thickness / 2, Width, Thickness);

            // Bottom right vertical
            SplashKit.FillRectangle(Color, X + Width - Thickness, Y + Height / 2, Thickness, Height / 2);

            // Bottom bar
            SplashKit.FillRectangle(Color, X, Y + Height - Thickness, Width, Thickness);

            if (Selected)
                DrawOutline();
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(SplashKit.ColorRed(), X - 5, Y - 5, Width + 10, Height + 10);
        }

        public override bool IsAt(Point2D pt)
        {
            return pt.X >= X && pt.X <= (X + Width) &&
                   pt.Y >= Y && pt.Y <= (Y + Height);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("LetterS");
            base.SaveTo(writer);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
        }
    }
}
