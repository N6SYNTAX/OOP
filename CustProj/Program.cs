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
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    Console.WriteLine("Key R Pressed");

                    Random rnd = new Random();

                    int numshape = rnd.Next(0, 20);

                    int i = 0;

                    while (i < numshape)
                    {
                        int shapetype = rnd.Next(0, 5);
                        float mouseX = rnd.Next(100, 700);
                        float mouseY = rnd.Next(100, 500);

                        Shape newShape = null;
                        switch (shapetype)
                        {
                            case 1:
                                newShape = new MyRectangle(SplashKit.RandomColor(), mouseX, mouseY, 100, 100);
                                break;
                            case 2:

                                newShape = new MyCircle(SplashKit.RandomColor(), mouseX, mouseY, 50);
                                break;
                            case 3:

                                newShape = new MyLine(SplashKit.RandomColor(), mouseX, mouseY, mouseX + 100, mouseY + 100);
                                break;
                            case 4:

                                newShape = new MyEllipse(SplashKit.RandomColor(), mouseX, mouseY, 100, 200);
                                break;
                        }
                        if (newShape != null)
                        {
                            myDrawing.AddShape(newShape);
                        }
                        i++;
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


