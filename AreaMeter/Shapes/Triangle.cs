using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaMeter.Shapes;
public class Triangle : IShape
{
    private readonly double[] _sides;

    public double SideA => _sides[0];
    public double SideB => _sides[1];
    public double SideC => _sides[2];

    public double Perimeter => _sides.Sum();
    public double SemiPerimeter => Perimeter / 2;

	public double Area
	{
        get
        {
            if(IsRightAngled())
				return SideA * SideB / 2;

            return Math.Sqrt(SemiPerimeter * (SemiPerimeter - SideA) * (SemiPerimeter - SideB) * (SemiPerimeter - SideC));
		}
    }

	public Triangle(double sideA, double sideB, double sideC)
    {
        if(sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Все стороны треугольника должны быть длиной больше 0");

        if(sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            throw new ArgumentException("Треугольник с такими сторонами существовать не может");

		//компановка длин сторон треугольника в массив и его сортировка
		//для упрощения дальнейших действий
		_sides = [sideA, sideB, sideC];
        Array.Sort(_sides);
    }

    public bool IsRightAngled()
    {
		//из-за вероятности возникновения погрешности при вычислениях 
		//производится сравнение результата разности не с нулем, а с небольшим числом 
		return Math.Abs(Math.Pow(SideC, 2) - (Math.Pow(SideA, 2) + Math.Pow(SideB, 2))) <= double.Epsilon * 100;
    }
}
