using System;

public class TestAttribute : Attribute
{
	object type;
	public object Type
	{
		get { return type; }
		set { type = value; }
	}
	public TestAttribute () { }
	public TestAttribute (Type type)
	{
		this.type = type;
	}
}

namespace N
{
	class C<T>
	{
		[Test (Type = typeof (C<>))] //this shouldn't fail
		public void Bar () { }

		[Test (typeof (C<>))]     // this shouldn't fail
		public void BarFoo () { }
	}
}
