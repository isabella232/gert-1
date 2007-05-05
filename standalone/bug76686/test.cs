using System;
using System.ComponentModel;

class Program
{
	static int Main ()
	{
		int? test = 1;
		
		TypeConverter converter = TypeDescriptor.GetConverter(test);
		if (converter is Int32Converter) {
			return 0;
		}
		
		Console.Error.WriteLine ("Converter is of type \"{0}\".",
			converter.GetType ().FullName);
		return 1;
	}
}
