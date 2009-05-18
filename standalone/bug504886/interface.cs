using System;

public interface ITest
{
	string Execute (IWhatever whatever);
	IWhatever Do (int version);

}

public interface IWhatever
{
	string Execute ();
}
