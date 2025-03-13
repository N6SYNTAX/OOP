
// Initializing class (object blueprint)
class Shape
{
    //Fields (Characteristics)
    private string _colour;
    private float _x;
    private float _y;
    private int _width;
    private int _height;

    // Creating constructor 
    public Shape(int param)
    {

        _colour = "Colour.Chocolate";

        // Initialize position and size
        _x = 0.0f;
        _y = 0.0f;
        _width = param;
        _height = param;
    }

    // Initialize method (Actions)
    public void Draw()
    {
        Console.WriteLine("Color is " + _colour);
        Console.WriteLine("Position X is " + _x);
        Console.WriteLine("Position Y is " + _y);
        Console.WriteLine("Width is " + _width);
        Console.WriteLine("Height is " + _height);
    }

    public bool IsAt(int xInput, int yInput)
    {
        return (xInput > _x && xInput < (_x + _width) &&
                yInput > _y && yInput < (_y + _height));
    }

    // Add properties
    public string Color
    {
        get { return _colour; }
        set { _colour = value; }
    }

    public float X
    {
        get { return _x; }
        set { _x = value; }
    }

    public float Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }



}