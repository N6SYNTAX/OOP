using System;
using SplashKitSDK;
using System.IO;

namespace Task_4
{
    public class Program
    {

        private enum ShapeKind { Rectangle, Circle, Line, Ellipse }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing();


            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                SplashKit.ProcessEvents();


                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyTyped(KeyCode.EKey))
                {
                    kindToAdd = ShapeKind.Ellipse;
                }


                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    float mouseX = SplashKit.MouseX();
                    float mouseY = SplashKit.MouseY();
                    Shape newShape = null;

                    switch (kindToAdd)
                    {
                        case ShapeKind.Rectangle:

                            newShape = new MyRectangle(SplashKit.RandomColor(), mouseX, mouseY, 100, 100);
                            break;
                        case ShapeKind.Circle:

                            newShape = new MyCircle(SplashKit.RandomColor(), mouseX, mouseY, 50);
                            break;
                        case ShapeKind.Line:

                            newShape = new MyLine(SplashKit.ColorRed(), mouseX, mouseY, mouseX + 100, mouseY + 100);
                            break;
                        case ShapeKind.Ellipse:

                            newShape = new MyEllipse(SplashKit.RandomColor(), mouseX, mouseY, 100, 200);
                            break;
                    }

                    if (newShape != null)
                    {
                        myDrawing.AddShape(newShape);
                    }
                }

                // If space key is pressed, change the drawing background to a random color.
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                // Right mouse click selects shapes at the mouse pointer.
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = SplashKit.MousePosition();
                    myDrawing.SelectShapesAt(pt);
                }

                // Delete selected shapes if Delete or Backspace is pressed.
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    var path = "C:/Users/sk539/Desktop/TestDrawing.txt";
                    myDrawing.Save(path);
                    Console.WriteLine($"Drawing saved to {path}");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    var path = "C:/Users/sk539/Desktop/TestDrawing.txt";
                    myDrawing.Load(path);
                    Console.WriteLine($"Drawing loaded from {path}");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("C:/Users/sk539/Desktop/TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error Loading File: {0}", e.Message);
                    }
                }




                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);



        }
    }
}


