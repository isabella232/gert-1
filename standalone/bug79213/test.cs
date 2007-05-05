using System;

public struct PointF
{
	private float _x;
	private float _y;

}

public class Program
{
	static void Offset (PointF point, float yOffset)
	{
	}

	static void Main (string [] args)
	{
		float test = 100;

		Offset (new PointF (), -(test));
	}
}
