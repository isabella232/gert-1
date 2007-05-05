using System;
using System.IO;
using System.Reflection;

public class Test {
	static int Main () {
		FileNotFoundException fnf = null;

		fnf = new FileNotFoundException ();
		if (fnf.Message != "Unable to find the specified file.") {
			Console.WriteLine ("#A1:" + fnf.Message);
			return 1;
		}
		if (fnf.ToString () != "System.IO.FileNotFoundException: Unable to find the specified file.") {
			Console.WriteLine ("#A2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException ("message");
		if (fnf.Message != "message") {
			Console.WriteLine ("#B1:" + fnf.Message);
			return 1;
		}
		if (fnf.ToString () != "System.IO.FileNotFoundException: message") {
			Console.WriteLine ("#B2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException ("message", new ArithmeticException ());
		if (fnf.Message != "message") {
			Console.WriteLine ("#C1:" + fnf.Message);
			return 1;
		}
		if (fnf.ToString () != "System.IO.FileNotFoundException: message ---> System.ArithmeticException: Overflow or underflow in the arithmetic operation.") {
			Console.WriteLine ("#C2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException ("message", "file.txt");
		if (fnf.Message != "message") {
			Console.WriteLine ("#D1:" + fnf.Message);
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != ("System.IO.FileNotFoundException: message" + Environment.NewLine + "File name: 'file.txt'")) {
#else
		if (fnf.ToString () != ("System.IO.FileNotFoundException: message" + Environment.NewLine + "File name: \"file.txt\"")) {
#endif
			Console.WriteLine ("#D2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException ("message", "file.txt", new ArithmeticException ());
		if (fnf.Message != "message") {
			Console.WriteLine ("#E1");
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != ("System.IO.FileNotFoundException: message" + Environment.NewLine + "File name: 'file.txt' ---> System.ArithmeticException: Overflow or underflow in the arithmetic operation.")) {
#else
		if (fnf.ToString () != ("System.IO.FileNotFoundException: message" + Environment.NewLine + "File name: \"file.txt\" ---> System.ArithmeticException: Overflow or underflow in the arithmetic operation.")) {
#endif
			Console.WriteLine ("#E2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException (null);
#if NET_2_0
		if (fnf.Message != null) {
#else
		if (fnf.Message != "File or assembly name (null), or one of its dependencies, was not found.") {
#endif
			Console.WriteLine ("#F1:" + fnf.Message);
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != "System.IO.FileNotFoundException: ") {
#else
		if (fnf.ToString () != "System.IO.FileNotFoundException: File or assembly name (null), or one of its dependencies, was not found.") {
#endif
			Console.WriteLine ("#F2");
			return 1;
		}

		fnf = new FileNotFoundException (null, "file.txt");
#if NET_2_0
		if (fnf.Message != "Could not load file or assembly 'file.txt' or one of its dependencies. The system cannot find the file specified.") {
#else
		if (fnf.Message != "File or assembly name file.txt, or one of its dependencies, was not found.") {
#endif
			Console.WriteLine ("#G1: " + fnf.Message);
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != ("System.IO.FileNotFoundException: Could not load file or assembly 'file.txt' or one of its dependencies. The system cannot find the file specified." + Environment.NewLine + "File name: 'file.txt'")) {
#else
		if (fnf.ToString () != ("System.IO.FileNotFoundException: File or assembly name file.txt, or one of its dependencies, was not found." + Environment.NewLine + "File name: \"file.txt\"")) {
#endif
			Console.WriteLine ("#G2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException (null, (string) null);
#if NET_2_0
		if (fnf.Message != null) {
#else
		if (fnf.Message != "File or assembly name (null), or one of its dependencies, was not found.") {
#endif
			Console.WriteLine ("#H1: " + fnf.Message);
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != "System.IO.FileNotFoundException: ") {
#else
		if (fnf.ToString () != "System.IO.FileNotFoundException: File or assembly name (null), or one of its dependencies, was not found.") {
#endif
			Console.WriteLine ("#H2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException (null, string.Empty);
#if NET_2_0
		if (fnf.Message != "Could not load file or assembly '' or one of its dependencies. The system cannot find the file specified.") {
#else
		if (fnf.Message != "File or assembly name , or one of its dependencies, was not found.") {
#endif
			Console.WriteLine ("#I1: " + fnf.Message);
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != "System.IO.FileNotFoundException: Could not load file or assembly '' or one of its dependencies. The system cannot find the file specified.") {
#else
		if (fnf.ToString () != "System.IO.FileNotFoundException: File or assembly name , or one of its dependencies, was not found.") {
#endif
			Console.WriteLine ("#I2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException (string.Empty, string.Empty);
#if NET_2_0
		if (fnf.Message != string.Empty) {
#else
		if (fnf.Message != string.Empty) {
#endif
			Console.WriteLine ("#J1: " + fnf.Message);
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != "System.IO.FileNotFoundException: ") {
#else
		if (fnf.ToString () != "System.IO.FileNotFoundException: ") {
#endif
			Console.WriteLine ("#J2: " + fnf.ToString ());
			return 1;
		}

		fnf = new FileNotFoundException (string.Empty, (string) null);
#if NET_2_0
		if (fnf.Message != string.Empty) {
#else
		if (fnf.Message != string.Empty) {
#endif
			Console.WriteLine ("#K1: " + fnf.Message);
			return 1;
		}
#if NET_2_0
		if (fnf.ToString () != "System.IO.FileNotFoundException: ") {
#else
		if (fnf.ToString () != "System.IO.FileNotFoundException: ") {
#endif
			Console.WriteLine ("#K2: " + fnf.ToString ());
			return 1;
		}

		try {
			Assembly.LoadFrom ("b.dll");
			return 1;
		} catch (FileNotFoundException ex) {
			if (ex.Message == null) {
				Console.WriteLine ("#L1");
				return 1;
			}
#if NET_2_0
			if (ex.Message != "Could not load file or assembly 'b.dll' or one of its dependencies. The system cannot find the file specified.") {
#else
			if (ex.Message != "File or assembly name b.dll, or one of its dependencies, was not found.") {
#endif
				Console.WriteLine ("#L2: " + ex.Message);
				return 1;
			}
			if (ex.FileName == null) {
				Console.WriteLine ("#L3");
				return 1;
			}
			if (ex.FileName != "b.dll") {
				Console.WriteLine ("#L4");
				return 1;
			}
		}

		try {
			Assembly.Load ("whatever");
			return 1;
		} catch (FileNotFoundException ex) {
			if (ex.Message == null) {
				Console.WriteLine ("#M1");
				return 1;
			}
#if NET_2_0
			if (ex.Message != "Could not load file or assembly 'whatever' or one of its dependencies. The system cannot find the file specified.") {
#else
			if (ex.Message != "File or assembly name whatever, or one of its dependencies, was not found.") {
#endif
				Console.WriteLine ("#M2: " + ex.Message);
				return 1;
			}
			if (ex.FileName == null) {
				Console.WriteLine ("#M3");
				return 1;
			}
			if (ex.FileName != "whatever") {
				Console.WriteLine ("#M4");
				return 1;
			}
		}

		try {
			AppDomain.CurrentDomain.ExecuteAssembly ("c.dll");
			return 1;
		} catch (FileNotFoundException ex) {
			if (ex.Message == null) {
				Console.WriteLine ("#N1");
				return 1;
			}
#if NET_2_0
			if (ex.Message != "Could not load file or assembly 'c.dll' or one of its dependencies. The system cannot find the file specified.") {
#else
			if (ex.Message != "File or assembly name c.dll, or one of its dependencies, was not found.") {
#endif
				Console.WriteLine ("#N2: " + ex.Message);
				return 1;
			}
			if (ex.FileName == null) {
				Console.WriteLine ("#N3");
				return 1;
			}
			if (ex.FileName != "c.dll") {
				Console.WriteLine ("#N4");
				return 1;
			}
		}
		return 0;
	}
}
