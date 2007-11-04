using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Threading;

public class Program
{
	static void Main ()
	{
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		DynamicMethod method = new DynamicMethod("func", typeof(void),
			 new Type[0], typeof(Program));
		ILGenerator ilgen = method.GetILGenerator();
		try {
			ilgen.Emit (OpCodes.Ldftn, method);
			Assert.Fail ("#A1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#A2");
			Assert.IsNull (ex.InnerException, "#A3");
			Assert.IsNotNull (ex.Message, "#A4");
			Assert.AreEqual ("Ldtoken, Ldftn and Ldvirtftn OpCodes cannot target DynamicMethods.", ex.Message, "#A5");
			Assert.IsNull (ex.ParamName, "#A6");
		}

		try {
			ilgen.Emit (OpCodes.Ldtoken, method);
			Assert.Fail ("#B1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
			Assert.AreEqual ("Ldtoken, Ldftn and Ldvirtftn OpCodes cannot target DynamicMethods.", ex.Message, "#B5");
			Assert.IsNull (ex.ParamName, "#B6");
		}

		try {
			ilgen.Emit (OpCodes.Ldvirtftn, method);
			Assert.Fail ("#C1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#C2");
			Assert.IsNull (ex.InnerException, "#C3");
			Assert.IsNotNull (ex.Message, "#C4");
			Assert.AreEqual ("Ldtoken, Ldftn and Ldvirtftn OpCodes cannot target DynamicMethods.", ex.Message, "#C5");
			Assert.IsNull (ex.ParamName, "#C6");
		}
	}
}
