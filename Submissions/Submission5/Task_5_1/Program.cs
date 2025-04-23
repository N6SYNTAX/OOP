using System;
using SplashKitSDK;

namespace Task_4
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            // Create a Drawing using the default constructor (background white)
            Drawing myDrawing = new Drawing();

            // Main event loop
            do
            {
                SplashKit.ProcessEvents();

                // Check for left mouse click: add a new shape at mouse position.
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Create a new shape using a parameter (e.g., 69, or 1XX based on your student ID)
                    Shape newShape = new Shape(69);
                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    newShape.Color = SplashKit.RandomColor();
                    myDrawing.AddShape(newShape);
                }

                // Check if space key is typed: change the drawing background to a random color.
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                // Check for right mouse click: select shapes at mouse position.
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = SplashKit.MousePosition();
                    myDrawing.SelectShapesAt(pt);
                }

                // Check if the Delete or Backspace key is typed: remove selected shapes.
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    // Get the selected shapes and remove each from the drawing.
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                // Draw the drawing (clear screen with background and then draw all shapes)
                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}