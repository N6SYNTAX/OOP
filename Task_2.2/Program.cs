Shape myShape = new Shape(69);
Shape myShape2 = new Shape(20);



myShape.Draw();
myShape2.DisplayCentre();


bool isInside = myShape.IsAt(50, 50);
Console.WriteLine($"Is point (50,50) inside the shape? {isInside}");