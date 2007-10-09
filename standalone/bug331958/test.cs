class Program
{
	static int Main ()
	{
		X18 x = new X18 ();
		if (x.GetType () != typeof (X18))
			return 1;
		return 0;
	}
}

struct X0 { byte b; }
struct X1 { X0 x1; X0 x2; }
struct X2 { X1 x1; X1 x2; }
struct X3 { X2 x1; X2 x2; }
struct X4 { X3 x1; X3 x2; }
struct X5 { X4 x1; X4 x2; }
struct X6 { X5 x1; X5 x2; }
struct X7 { X6 x1; X6 x2; }
struct X8 { X7 x1; X7 x2; }
struct X9 { X8 x1; X8 x2; }
struct X10 { X9 x1; X9 x2; }
struct X11 { X10 x1; X10 x2; }
struct X12 { X11 x1; X11 x2; }
struct X13 { X12 x1; X12 x2; }
struct X14 { X13 x1; X13 x2; }
struct X15 { X14 x1; X14 x2; }
struct X16 { X15 x1; X15 x2; }
struct X17 { X16 x1; X16 x2; }
struct X18 { X17 x1; X17 x2; }
