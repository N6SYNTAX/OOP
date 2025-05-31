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

        // The total width of “SEAN” = 4 letters + 3 gaps:
        private static readonly float TotalWidth =
            (4 * LetterWidth) + (3 * GapBetweenLetters);

        // Default constructor: purple at (0,0)
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

            // Letter 'S':
            // 1) Top horizontal bar
            SplashKit.FillRectangle(c,
                x0, y0,
                LetterWidth, StrokeThickness);

            // 2) Upper left vertical
            SplashKit.FillRectangle(c,
                x0, y0,
                StrokeThickness, LetterHeight / 2f);

            // 3) Middle horizontal
            SplashKit.FillRectangle(c,
                x0, y0 + (LetterHeight / 2f) - (StrokeThickness / 2f),
                LetterWidth, StrokeThickness);

            // 4) Lower right vertical
            SplashKit.FillRectangle(c,
                x0 + LetterWidth - StrokeThickness, y0 + (LetterHeight / 2f),
                StrokeThickness, LetterHeight / 2f);

            // 5) Bottom horizontal
            SplashKit.FillRectangle(c,
                x0, y0 + LetterHeight - StrokeThickness,
                LetterWidth, StrokeThickness);


            // Letter 'E':
            float x1 = x0 + LetterWidth + GapBetweenLetters;
            SplashKit.FillRectangle(c,
                x1, y0,
                StrokeThickness, LetterHeight);                // Left vertical
            SplashKit.FillRectangle(c,
                x1, y0,
                LetterWidth, StrokeThickness);                   // Top bar
            SplashKit.FillRectangle(c,
                x1, y0 + (LetterHeight / 2f) - (StrokeThickness / 2f),
                LetterWidth - (StrokeThickness * 1.5f), StrokeThickness); // Middle bar
            SplashKit.FillRectangle(c,
                x1, y0 + LetterHeight - StrokeThickness,
                LetterWidth, StrokeThickness);                   // Bottom bar


            // Letter 'A':
            float x2 = x1 + LetterWidth + GapBetweenLetters;
            SplashKit.FillRectangle(c,
                x2, y0,
                StrokeThickness, LetterHeight);                // Left vertical of A
            SplashKit.FillRectangle(c,
                x2 + LetterWidth - StrokeThickness, y0,
                StrokeThickness, LetterHeight);               // Right vertical of A
            SplashKit.FillRectangle(c,
                x2 + (StrokeThickness / 2f), y0 + (LetterHeight / 2f) - (StrokeThickness / 2f),
                LetterWidth - StrokeThickness, StrokeThickness); // Crossbar of A


            // Letter 'N':
            float x3 = x2 + LetterWidth + GapBetweenLetters;
            SplashKit.FillRectangle(c,
                x3, y0,
                StrokeThickness, LetterHeight);                // Left vertical of N
            SplashKit.FillRectangle(c,
                x3 + LetterWidth - StrokeThickness, y0,
                StrokeThickness, LetterHeight);               // Right vertical of N

            // // Diagonal from top‐left to bottom‐right:
            // // Simply set the global LineWidth, then call DrawLine without extra params.
            // SplashKit.LineWidth = StrokeThickness;
            // SplashKit.DrawLine(
            //     c,
            //     x3 + StrokeThickness,       // startX
            //     y0,                         // startY
            //     x3 + LetterWidth - StrokeThickness, // endX
            //     y0 + LetterHeight           // endY
            // );

        }


        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= X)
                && (pt.X <= X + TotalWidth)
                && (pt.Y >= Y)
                && (pt.Y <= Y + LetterHeight);
        }


        public override void DrawOutline()
        {
            // A 2px “margin” so the outline stroke doesn’t overlap fill edges exactly:
            float outlineMargin = 2f;

            SplashKit.DrawRectangle(
                SplashKit.ColorBlack(),
                X - outlineMargin,
                Y - outlineMargin,
                TotalWidth + (outlineMargin * 2f),
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
