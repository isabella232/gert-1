public interface ISequence
{
	object this [int index]
	{
		get;
	}
}

public interface IMutableSequence : ISequence
{
	new object this [int index]
	{
		get;
		set;
	}
}
