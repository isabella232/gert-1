public class A
{
	public override string ToString ()
	{
		return "Av2";
	}
}

public class Vehicle
{
	public virtual string Run ()
	{
		return "Vehicle";
	}
}

public class Car : Vehicle
{
	public string AvoidWarning ()
	{
		return Run ();
	}

	private new string Run ()
	{
		return "Car";
	}
}
