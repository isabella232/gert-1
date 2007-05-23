using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

class Program
{
	static int Main ()
	{
		PreviewPrintController printController = new PreviewPrintController ();
		MyPrintDocument doc = new MyPrintDocument ();
		doc.PrintController = printController;
		doc.Print ();

		if (doc.Matrix.Elements.Length != 6)
			return 1;
		if (doc.Matrix.Elements [0] != 1)
			return 2;
		if (doc.Matrix.Elements [1] != 0)
			return 3;
		if (doc.Matrix.Elements [2] != 0)
			return 4;
		if (doc.Matrix.Elements [3] != 1)
			return 5;
		if (doc.Matrix.Elements [4] != 0)
			return 6;
		if (doc.Matrix.Elements [5] != 0)
			return 7;
		return 0;
	}
}

public class MyPrintDocument : PrintDocument
{
	public MyPrintDocument ()
	{
	}

	protected override void OnPrintPage (PrintPageEventArgs e)
	{
		base.OnPrintPage (e);

		Graphics g = e.Graphics;
		Matrix mx = g.Transform;
		_matrix = mx;

		RectangleF rec = g.ClipBounds;
		if (rec == RectangleF.Empty)
			Environment.Exit (10);

		e.HasMorePages = false;
		e.Cancel = true;
	}

	public Matrix Matrix {
		get { return _matrix; }
	}

	private Matrix _matrix;
}
