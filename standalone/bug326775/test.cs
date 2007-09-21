using System;
using System.Configuration;
using System.Diagnostics;

class Program
{
	static int Main (string [] args)
	{
		int test = int.Parse (args [0]);
		switch (test) {
		case 1:
			return Test1 ();
		case 2:
			return Test2 ();
		case 3:
			return Test3 ();
		case 4:
			return Test4 ();
		case 5:
			return Test5 ();
		case 6:
			return Test6 ();
		default:
			return 1;
		}
	}

	static int Test1 ()
	{
		TraceSwitch testSwitch1 = new TraceSwitch ("testSwitch1", null);
		if (testSwitch1.Level != TraceLevel.Verbose)
			return 1;

		TraceSwitch testSwitch2 = new TraceSwitch ("testSwitch2", null);
		if (testSwitch2.Level != TraceLevel.Off)
			return 2;

		TraceSwitch testSwitch3 = new TraceSwitch ("testSwitch3", null);
		if (testSwitch3.Level != TraceLevel.Warning)
			return 3;

		TraceSwitch testSwitch4 = new TraceSwitch ("testSwitch4", null);
		if (testSwitch4.Level != TraceLevel.Info)
			return 4;

		TraceSwitch testSwitch5 = new TraceSwitch ("testSwitch5", null);
		if (testSwitch5.Level != TraceLevel.Verbose)
			return 5;

		TraceSwitch testSwitch6 = new TraceSwitch ("testSwitch6", null);
		if (testSwitch6.Level != TraceLevel.Off)
			return 6;

#if NET_2_0
		TraceSwitch testSwitch7 = new TraceSwitch ("testSwitch7", null);
		if (testSwitch7.Level != TraceLevel.Info)
			return 7;

		TraceSwitch testSwitch8 = new TraceSwitch ("testSwitch8", null);
		if (testSwitch8.Level != TraceLevel.Warning)
			return 8;
#endif

		TraceSwitch testSwitch9 = new TraceSwitch ("testSwitch9", null);
		if (testSwitch9.Level != TraceLevel.Off)
			return 9;

		BooleanSwitch boolSwitch1 = new BooleanSwitch ("boolSwitch1", null);
		if (boolSwitch1.Enabled)
			return 10;

		BooleanSwitch boolSwitch2 = new BooleanSwitch ("boolSwitch2", null);
		if (!boolSwitch2.Enabled)
			return 11;

		BooleanSwitch boolSwitch3 = new BooleanSwitch ("boolSwitch3", null);
		if (!boolSwitch3.Enabled)
			return 12;

		BooleanSwitch boolSwitch4 = new BooleanSwitch ("boolSwitch4", null);
		if (boolSwitch4.Enabled)
			return 13;

#if NET_2_0
		BooleanSwitch boolSwitch5 = new BooleanSwitch ("boolSwitch5", null);
		if (!boolSwitch5.Enabled)
			return 14;

		BooleanSwitch boolSwitch6 = new BooleanSwitch ("boolSwitch6", null);
		if (boolSwitch6.Enabled)
			return 15;

		SourceSwitch sourceSwitch1 = new SourceSwitch ("sourceSwitch1");
		if ((sourceSwitch1.Level & SourceLevels.Critical) == 0)
			return 16;

		SourceSwitch sourceSwitch2 = new SourceSwitch ("sourceSwitch2");
		if ((sourceSwitch2.Level & SourceLevels.Warning) == 0)
			return 17;
		if ((sourceSwitch2.Level & SourceLevels.Error) == 0)
			return 18;

		SourceSwitch sourceSwitch3 = new SourceSwitch ("sourceSwitch3");
		if (sourceSwitch3.Level != SourceLevels.Off)
			return 19;
#endif

		return 0;
	}

	static int Test2 ()
	{
		TraceSwitch testSwitch1 = new TraceSwitch ("testSwitch1", null);

#if NET_2_0
		if (testSwitch1.Level != TraceLevel.Off)
			return 1;

		TraceSwitch testSwitch8 = new TraceSwitch ("testSwitch8", null);
		try {
			Assert.Fail ("#1:" + testSwitch8.Level);
		} catch (ConfigurationErrorsException ex) {
			// The config value for Switch 'testSwitch8' was invalid
			Assert.AreEqual (typeof (ConfigurationErrorsException), ex.GetType (), "#2");
			Assert.IsNotNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.Message, "#4");
			Assert.IsTrue (ex.Message.IndexOf ("'testSwitch8'") != -1, "#5");

			ArgumentException ae = ex.InnerException as ArgumentException;
			Assert.IsNotNull (ae, "#6");
			Assert.IsNotNull (ae.Message, "#7");
			Assert.IsTrue (ae.Message.IndexOf ("'Invalid'") != -1, "#8");
		}
#else
		try {
			Assert.Fail ("#1:" + testSwitch1.Level);
		} catch (ConfigurationException ex) {
			// Error in trace switch 'testSwitch8': The value of a
			// switch must be integral
			Assert.AreEqual (typeof (ConfigurationException), ex.GetType (), "#2");
			Assert.IsNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.Message, "#4");
			Assert.IsTrue (ex.Message.IndexOf ("'testSwitch8'") != -1, "#5");
		}
#endif
		return 0;
	}

	static int Test3 ()
	{
		TraceSwitch testSwitch1 = new TraceSwitch ("testSwitch1", null);
		try {
			Assert.Fail ("#1:" + testSwitch1.Level);
		} catch (ConfigurationException ex) {
			// Required attribute 'value' not found
			Assert.IsNull (ex.InnerException, "#2");
			Assert.IsNotNull (ex.Message, "#3");
			Assert.IsTrue (ex.Message.IndexOf ("'value'") != -1, "#4");
		}
		return 0;
	}

	static int Test4 ()
	{
		TraceSwitch testSwitch1 = new TraceSwitch ("testSwitch1", null);
#if NET_2_0 && !MONO
		if (testSwitch1.Level != TraceLevel.Warning)
			return 1;
#else
		try {
			Assert.Fail ("#A1:" + testSwitch1.Level);
		} catch (ConfigurationException ex) {
			// Required attribute 'value' cannot be empty
			Assert.IsNull (ex.InnerException, "#A2");
			Assert.IsNotNull (ex.Message, "#A3");
			Assert.IsTrue (ex.Message.IndexOf ("'value'") != -1, "#A4");
		}
#endif

#if !MONO
		TraceSwitch testSwitch8 = new TraceSwitch ("testSwitch8", null);
#if NET_2_0
		try {
			Assert.Fail ("#B1:" + testSwitch8.Level);
		} catch (ConfigurationException ex) {
			// The config value for Switch 'testSwitch8' was invalid
			Assert.IsNotNull (ex.InnerException, "#B2");
			Assert.IsNotNull (ex.Message, "#B3");
			Assert.IsTrue (ex.Message.IndexOf ("'testSwitch8'") != -1, "#B4");

			// Must specify valid information for parsing in the string
			ArgumentException ae = ex.InnerException as ArgumentException;
			Assert.IsNotNull (ae, "#B5");
			Assert.IsNull (ae.InnerException, "#B6");
			Assert.IsNotNull (ae.Message, "#B7");
		}
#else
		if (testSwitch8.Level != TraceLevel.Off)
			return 1;
#endif
#endif
		return 0;
	}

	static int Test5 ()
	{
		TraceSwitch testSwitch1 = new TraceSwitch ("testSwitch1", null);
		try {
			Assert.Fail ("#1:" + testSwitch1.Level);
		} catch (ConfigurationException ex) {
			// Unrecognized element 'unexpected'
			Assert.IsNull (ex.InnerException, "#2");
			Assert.IsNotNull (ex.Message, "#3");
#if NET_2_0 || MONO
			Assert.IsTrue (ex.Message.IndexOf ("'unexpected'") != -1, "#4");
#endif
		}
		return 0;
	}

	static int Test6 ()
	{
		BooleanSwitch boolSwitch1 = new BooleanSwitch ("boolSwitch1", null);

#if NET_2_0
		if (boolSwitch1.Enabled)
			return 1;

		BooleanSwitch boolSwitch8 = new BooleanSwitch ("boolSwitch8", null);
		try {
			Assert.Fail ("#1:" + boolSwitch8.Enabled);
		} catch (ConfigurationErrorsException ex) {
			// The config value for Switch 'boolSwitch8' was invalid
			Assert.AreEqual (typeof (ConfigurationErrorsException), ex.GetType (), "#2");
			Assert.IsNotNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.Message, "#4");
			Assert.IsTrue (ex.Message.IndexOf ("'boolSwitch8'") != -1, "#5");

			// Input string was not in a correct format
			FormatException fe = ex.InnerException as FormatException;
			Assert.IsNotNull (fe, "#6");
			Assert.IsNotNull (fe.Message, "#7");
		}
#else
		try {
			Assert.Fail ("#1:" + boolSwitch1.Enabled);
		} catch (ConfigurationException ex) {
			// Error in trace switch 'boolSwitch8': The value of a
			// switch must be integral
			Assert.AreEqual (typeof (ConfigurationException), ex.GetType (), "#2");
			Assert.IsNull (ex.InnerException, "#3");
			Assert.IsNotNull (ex.Message, "#4");
			Assert.IsTrue (ex.Message.IndexOf ("'boolSwitch8'") != -1, "#5");
		}
#endif
		return 0;
	}
}
