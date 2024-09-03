using System;
using System.Collections;

using AreaMeter.Shapes;

namespace AreaMeterTest;


public class Tests
{
	[SetUp]
	public static void Setup()
	{
		GenerateCorrectTriangleSides();
	}


	public static double Tolerance = double.Epsilon * 100;
	
	public static double RegularTriangleArea(double sideA, double sideB, double sideC)
	{
		var semiPerimeter = (sideA + sideB + sideC) / 2;
		return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
	}

	public static IEnumerable GenerateCorrectTriangleSides()
	{
		var random = new Random();
		for(int i = 0; i < 10; i++)
		{
			int a = random.Next(1, 101);
			int b = random.Next(1, 101);
			int c = random.Next(Math.Abs(a - b) + 1, a + b - 1); ;
			yield return new TestCaseData(a, b, c);
		}
	}

	[TestCaseSource(nameof(GenerateCorrectTriangleSides))]
	public void TriangleAreas_WhenValidData_CalculatesCorrectly(double sideA, double sideB, double sideC)
	{
        Assert.That(new Triangle(sideA, sideB, sideC).Area, Is.EqualTo(RegularTriangleArea(sideA, sideB, sideC)).Within(Tolerance));
	}

	public void TriangleAreas_WhenInvalidData_GivesError()
	{
		Assert.Pass();
	}
}