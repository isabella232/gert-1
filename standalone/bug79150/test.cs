using System;

public class TypedReferenceTypeCodeTest
{
	static int Main ()
	{
		TypeCode tc = Type.GetTypeCode (typeof (TypedReference));
		if (tc != TypeCode.Object) {
			Console.WriteLine ("Expected 'Object', but was '"
				+ tc + "'.");
			return 1;
		}
		return 0;
	}
}
