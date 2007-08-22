using System;

class Program
{
	public struct Vector
	{
		public double X, Y, Z;

		public Vector (double x, double y, double z)
		{
			X = x; Y = y; Z = z;
		}

		public static Vector Min (Vector a, Vector b)
		{
			return new Vector (
				Math.Min (a.X, b.X),
				Math.Min (a.Y, b.Y),
				Math.Min (a.Z, b.Z));
		}

		public static Vector Max (Vector a, Vector b)
		{
			return new Vector (
				Math.Max (a.X, b.X),
				Math.Max (a.Y, b.Y),
				Math.Max (a.Z, b.Z));
		}

		public static Vector operator - (Vector a, Vector b)
		{
			return new Vector (a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}
	}

	public struct Box
	{
		public Vector Position;
		public Vector Size;

		public Box (Vector position, Vector size)
		{
			Position = position;
			Size = size;
		}
	}

	public struct Face
	{
		private Vector u, v, w;

		public Face (Vector u, Vector v, Vector w)
		{
			this.u = u; this.v = v; this.w = w;
		}

		public Box BoundingBox {
			get {
				Vector pos = Vector.Min (u, Vector.Min (v, w));
				return new Box (pos, Vector.Max (u - pos, Vector.Max (v - pos, w - pos)));
			}
		}
	}

	static int Main ()
	{
		Vector a, b, c;
		a = new Vector (0, 0, 0);
		b = new Vector (0, 1, 0);
		c = new Vector (1, 1, 0);
		Face f = new Face (a, b, c);
		if (f.BoundingBox.ToString () != "Program+Box")
			return 1;
		return 0;
	}
}

