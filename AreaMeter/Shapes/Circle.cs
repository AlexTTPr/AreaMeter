using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaMeter.Shapes;
public class Circle : IShape
{
	private double _radius;

	public double Area => Math.Pow(_radius, 2) * Math.PI;

    public Circle(double radius)
    {
        if(radius <= 0)
            throw new ArgumentException("Радиус должен быть больше 0");

        _radius = radius;
    }
}
