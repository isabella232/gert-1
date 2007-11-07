using System;

public enum TestEnumBI64 : long
{
	AL = Int64.MaxValue, BL = 1000
}

public interface TestService
{
	TestEnumBI64 Echo (TestEnumBI64 arg);
}
