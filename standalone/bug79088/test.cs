namespace Test
{
	public class A<TA, TB>
		where TA : A<TA, TB>
		where TB : B<TA, TB>
	{
	}
	public class B<TA, TB>
		where TA : A<TA, TB>
		where TB : B<TA, TB>
	{
	}
}
