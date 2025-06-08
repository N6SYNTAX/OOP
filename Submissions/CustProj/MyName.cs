using SplashKitSDK;
using System;
using System.IO;

namespace Task_4
{
    public class MyName : Shape
    {
        // Letter dimensions and spacing:
        private const float LetterWidth = 60f;
        private const float LetterHeight = 100f;
        private const float StrokeThickness = 15f;
        private const float GapBetweenLetters = 20f;




        public MyName() : this(SplashKit.ColorPurple(), 0f, 0f) { }

        // Constructor that accepts a color and an (x, y) origin
        public MyName(Color color, float x, float y) : base(color)
        {
            X = x;
            Y = y;
        }


        public override void Draw()
        {
            float x0 = X;
            float y0 = Y;
            Color c = Color;

            // 1) Top horizontal bar
            SplashKit.FillRectangle(
                c,
                x0, y0,
                LetterWidth, StrokeThickness
            );

            // 2) Upper left vertical
            SplashKit.FillRectangle(
                c,
                x0, y0,
                StrokeThickness, LetterHeight / 2f
            );

            // 3) Middle horizontal
            SplashKit.FillRectangle(
                c,
                x0,
                y0 + (LetterHeight / 2f) - (StrokeThickness / 2f),
                LetterWidth,
                StrokeThickness
            );

            // 4) Lower right vertical
            SplashKit.FillRectangle(
                c,
                x0 + LetterWidth - StrokeThickness,
                y0 + (LetterHeight / 2f),
                StrokeThickness,
                LetterHeight / 2f
            );

            // 5) Bottom horizontal
            SplashKit.FillRectangle(
                c,
                x0,
                y0 + LetterHeight - StrokeThickness,
                LetterWidth,
                StrokeThickness
            );
            if (Selected)
            {
                DrawOutline();
            }

        }



        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= X)
                && (pt.X <= X + LetterWidth)
                && (pt.Y >= Y)
                && (pt.Y <= Y + LetterHeight);
        }


        public override void DrawOutline()
        {
            // 2px margin so the outline doesn’t overlap exactly
            float outlineMargin = 2f;

            SplashKit.DrawRectangle(
            SplashKit.ColorBlack(),
            X - outlineMargin,
            Y - outlineMargin,
            LetterWidth + (outlineMargin * 2f),
            LetterHeight + (outlineMargin * 2f)
        );
        }


        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("MyName");
            base.SaveTo(writer);   // Writes color, then X, then Y
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);

        }
    }
}
