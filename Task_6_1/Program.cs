using System;
using SplashKitSDK;
using System.IO;

namespace Task_4
{
    public class Program
    {

        private enum ShapeKind { Rectangle, Circle, Line, Ellipse, Sword, LetterS }

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
                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    kindToAdd = ShapeKind.Sword;
                }
                if (SplashKit.KeyTyped(KeyCode.NKey))
                {
                    kindToAdd = ShapeKind.LetterS;
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
                        case ShapeKind.Sword:
                            newShape = new MySword(SplashKit.RGBColor(169, 169, 169), mouseX, mouseY, mouseX - 100, mouseY - 100);
                            break;
                        case ShapeKind.LetterS:
                            newShape = new MyLetterS(SplashKit.ColorBlack(), 150, 150);
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
                // if (SplashKit.KeyTyped(KeyCode.RKey))
                // {
                //     Random rnd = new Random();
                //     int shapeCount = rnd.Next(3, 7); // 3 to 6 shapes

                //     for (int i = 0; i < shapeCount; i++)
                //     {
                //         Color randomColor = SplashKit.RandomRGBColor(255);
                //         float x = rnd.Next(800);
                //         float y = rnd.Next(600);
                //         int shapeType = rnd.Next(3); // 0 = rect, 1 = circle, 2 = line

                //         switch (shapeType)
                //         {
                //             case 0: ShapeKind.Add(new MyRectangle(randomColor, x, y, 60, 40)); break;
                //             case 1: shapes.Add(new MyCircle(randomColor, x, y, 25)); break;
                //             case 2: shapes.Add(new MyLine(randomColor, x, y, x + 50, y + 30)); break;
                //         }
                //     }
                // }




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


