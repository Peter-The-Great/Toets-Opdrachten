namespace ConsoleApp1;

class Vector
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Vector operator +(Vector a, Vector b) => new Vector { X = a.X + b.X, Y = a.Y + b.Y };
    public static Vector operator -(Vector a, Vector b) => new Vector { X = a.X + b.X, Y = a.Y + b.Y };
    public static Vector operator *(Vector a, Vector b) => new Vector { X = a.X + b.X, Y = a.Y + b.Y };
    public static Vector operator /(Vector a, Vector b) => new Vector { X = a.X + b.X, Y = a.Y + b.Y };

}