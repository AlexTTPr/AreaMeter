using AreaMeter.Shapes;

namespace Demo;
internal class Program
{
	static void Main(string[] args)
	{
		RegularShapesExample();
		CustomShapeExample();
	}

	static void RegularShapesExample()
	{
		var circle = new Circle(10);
		var triangle = new Triangle(10, 10, 12);

		Console.WriteLine($"Площадь круга: {circle.Area}");
		Console.WriteLine($"Площадь треугольника: {triangle.Area}");
    }

	static void CustomShapeExample()
	{
		var square = new Square(10);
        Console.WriteLine($"Площадь квадрата: {square.Area}");
    }
}


public class Square : IShape
{
	public double Side { get; }
	public double Area => Math.Pow(Side, 2);

    public Square(double side)
    {
        if(side <= 0)
			throw new ArgumentException("Сторона должен быть больше 0");

		Side = side;
	}
}
