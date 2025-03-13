Shape myShape = new Shape(69);


myShape.Draw();

bool isInside = myShape.IsAt(50, 50);
Console.WriteLine("Is point (50,50) inside the shape? " + isInside);