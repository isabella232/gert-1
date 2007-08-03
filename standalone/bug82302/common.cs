using System;
using System.Runtime.Serialization;

public interface IRemoteLoggingSink : ITest
{
}

public interface ITest
{
	IPerson GetPerson ();
	IPerson GetPerson (string name);
}

public interface IPerson
{
	void Call ();
	void Call (string name);
}
