using System;
using SplashKitSDK;
using System.IO;

namespace Task_4
{
    public class Program
    {

        private enum ShapeKind { Rectangle, Circle, Line, Ellipse, Sword, Name }

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
                    kindToAdd = ShapeKind.Name;
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
                        case ShapeKind.Name:
                            newShape = new MyName(SplashKit.ColorBlack(), 150, 150);
                            break;
                    }

                    if (newShape != null)
                    {
                        myDrawing.AddShape(newShape);
                    }
                }


                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }




                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D pt = SplashKit.MousePosition();
                    myDrawing.SelectShapesAt(pt);
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(s);
                    }
                }

                // If R key typed a random set of shapes drawn
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    // For verification purposes
                    Console.WriteLine("Key R Pressed");
                    // Using C# build in random function
                    Random rnd = new Random();
                    // Generating number of shapes to be drawn
                    int numshape = rnd.Next(0, 20);

                    int i = 0;
                    // Loops the number of times generated previously
                    while (i < numshape)
                    {
                        // Generating rand attributes for shapetype, and x and y position
                        int shapetype = rnd.Next(0, 5);
                        float mouseX = rnd.Next(100, 700);
                        float mouseY = rnd.Next(100, 500);

                        // Instantiating new shape object
                        Shape newShape = null;
                        // Using a case to print shape depending on the number generated before
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


