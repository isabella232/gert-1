using System;

class Program
{
	static int Main ()
	{
		if (typeof (int).GUID != new Guid ("a310fadd-7c33-377c-9d6b-599b0317d7f2"))
			return 1;

		if (typeof (string).GUID != new Guid ("296afbff-1b0b-3ff5-9d6c-4e7e599f8b57"))
			return 2;

		if (typeof (Test).GUID != new Guid ("2632d937-461e-38f3-9939-c110f0107e4f"))
			return 3;

		return 0;
	}
}
