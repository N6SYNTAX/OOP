using System.Diagnostics.Contracts;
public class Counter
{
    private long _count;  // Stores the count value
    private string _name; // Stores the name of the counter

    // Constructor: Initializes the Counter with a name and count set to 0
    public Counter(string name)
    {
        _name = name;
        _count = 0;
    }

    // Property: Gets or sets the name of the counter
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    // Property: Read-only, returns the count value
    public long Ticks
    {
        get { return _count; }
    }

    // Method: Increments the count by 1
    public void Increment()
    {
        checked // Prevent overflow errors
        {
            _count++;
        }
    }

    // Method: Resets the count to 0
    public void Reset()
    {
        _count = 0;
    }

    // Additional Method
    public void ResetByDefault()
    {
        _count = 214748368669;
    }

    // Additional: Increments count by 5 (for testing overflow handling)
    public void IncrementByFive()
    {
        checked
        {
            _count += 5;
        }
    }
}

