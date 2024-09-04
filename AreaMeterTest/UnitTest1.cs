using System;
using System.Collections;
using System.Dynamic;

using AreaMeter.Shapes;

using NUnit.Framework.Internal;

namespace AreaMeterTest;


public class Tests
{
	public static readonly Randomizer Random = TestContext.CurrentContext.Random;

	public static double Tolerance = 1d / 100000000000d;

	public const int NumberOfTests = 100;

	#region Triangles
	public static double RegularTriangleArea(double sideA, double sideB, double sideC)
	{
		var semiPerimeter = (sideA + sideB + sideC) / 2;
		return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
	}

	public static IEnumerable GenerateCorrectTriangleSides()
	{
		for(int i = 0; i < NumberOfTests; i++)
		{
			var a = Random.NextDouble(1, 100);
			var b = Random.NextDouble(1, 100);
			var c = Random.NextDouble(Math.Abs(a - b), a + b);
			yield return new TestCaseData(a, b, c);
		}
	}

	public static IEnumerable GenerateIncorrectTriangleSides()
	{
		for(int i = 0; i < NumberOfTests; i++)
		{
			var a = Random.NextDouble(1, 100);
			var b = Random.NextDouble(1, 100);
			var c = Random.NextDouble(200, 1000);
			yield return new TestCaseData(a, b, c);
		}
	}

	public static IEnumerable GenerateRightAngleTriangleSides()
	{
		for(int i = 0; i < NumberOfTests; i++)
		{
			var a = Random.NextDouble(1, 100);
			var b = Random.NextDouble(1, 100);
			var c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
			yield return new TestCaseData(a, b, c);
		}
	}

	public static IEnumerable GenerateNotRightAngleTriangleSides()
	{
		for(int i = 0; i < NumberOfTests; i++)
		{
			var a = Random.NextDouble(1, 100);
			var b = Random.NextDouble(1, 100);
			var c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 10);
			yield return new TestCaseData(a, b, c);
		}
	}

	[TestCaseSource(nameof(GenerateCorrectTriangleSides))]
	public void TriangleAreas_WhenValidData_CalculatesCorrectly(double sideA, double sideB, double sideC)
	{
		Assert.That(new Triangle(sideA, sideB, sideC).Area,
			Is.EqualTo(RegularTriangleArea(sideA, sideB, sideC))
				.Within(Tolerance));
	}

	[TestCaseSource(nameof(GenerateIncorrectTriangleSides))]
	public void TriangleAreas_WhenInvalidData_ThrowsException(double sideA, double sideB, double sideC)
	{
		Assert.That(() => new Triangle(sideA, sideB, sideC),
			Throws.TypeOf<ArgumentException>());
	}

	[TestCaseSource(nameof(GenerateRightAngleTriangleSides))]
	public void ThiangleIsRightAngled_WhenValidData_ReturnTrue(double sideA, double sideB, double sideC)
	{
		Assert.That(new Triangle(sideA, sideB, sideC).IsRightAngled(),
			Is.True);
	}

	[TestCaseSource(nameof(GenerateNotRightAngleTriangleSides))]
	public void ThiangleIsRightAngled_WhenInvaludData_ReturnFalse(double sideA, double sideB, double sideC)
	{
		Assert.That(new Triangle(sideA, sideB, sideC).IsRightAngled(),
			Is.False);
	}
	#endregion

	#region Circles
	public static double CircleArea(double radius)
	{
		return Math.Pow(radius, 2) * Math.PI;
	}

	public static IEnumerable GenerateCorrectCircleRadius()
	{
		for(int i = 0; i < NumberOfTests; i++)
		{
			yield return new TestCaseData(Random.NextDouble(1, 100));
		}
	}

	public static IEnumerable GenerateIncorrectCircleRadius()
	{
		for(int i = 0; i < NumberOfTests; i++)
		{
			yield return new TestCaseData(Random.NextDouble(-100, -1));
		}
	}

	[TestCaseSource(nameof(GenerateCorrectCircleRadius))]
	public void CircleAreas_WhenValidData_CalculatesCorrectly(double radius)
	{
		Assert.That(new Circle(radius).Area,
			Is.EqualTo(CircleArea(radius))
				.Within(Tolerance));
	}

	[TestCaseSource(nameof(GenerateIncorrectCircleRadius))]
	public void CircleAreas_WhenInvalidData_ThrowsException(double radius)
	{
		Assert.That(() => new Circle(radius),
			Throws.TypeOf<ArgumentException>());
	} 
	#endregion
}