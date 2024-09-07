using AreaMeter.Shapes;

namespace Demo;
internal class Program
{
	static void Main(string[] args)
	{
		RegularShapesExample();
		CustomShapeExample();
		RuntimeAreaCalculation();
	}

	//Расчитывание площади стандартных фигур
	static void RegularShapesExample()
	{
		var circle = new Circle(10);
		var triangle = new Triangle(10, 10, 12);

		Console.WriteLine($"Площадь круга: {circle.Area}");
		Console.WriteLine($"Площадь треугольника: {triangle.Area}");
    }

	//Создание новой фигуры и расчет ее площади
	static void CustomShapeExample()
	{
		var square = new Square(10);
        Console.WriteLine($"Площадь квадрата: {square.Area}");
    }

	//Случайный выбор фигуры и вычисление ее площади в рантайме
	static void RuntimeAreaCalculation()
	{
		IShape unknownShape = Random.Shared.Next(0, 3) switch
		{
			0 => new Circle(5),
			1 => new Triangle(3, 4, 5),
			2 => new Square(5),
			_ => new Circle(10)
		};

        Console.WriteLine($"Площадь {unknownShape} = {unknownShape.Area}");
    }
}

//Кастомная фигура
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
