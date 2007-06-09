using System;

class Program
{
	static int Main ()
	{
		TestEnum? testEnum = TestEnum.Value1;
		switch (testEnum) {
		case TestEnum.Value1:
			return 0;
		}
		return 1;
	}
}

public enum TestEnum
{
	Value1,
	Value2
}
