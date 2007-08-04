using System;

public class NullableArrayParseBug
{
	public void Foo<T> () where T : struct
	{
		object o = null;
		int? [] intArray;

		T? [] array1;
		Nullable<T> [] array2;

		array1 = (Nullable<T> []) o;
		intArray = (int? []) o;
		array1 = (T? []) o;
	}
}
