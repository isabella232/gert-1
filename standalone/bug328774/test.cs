using System;

class Program
{
	static int Main ()
	{
		Program p = new Program ();
		p.Do ("a", "b", "c");
		if (p._text != "starta,b,c")
			return 1;
		return 0;
	}

	void Do (string a, string b, string c)
	{
		_text += a + "," + b + "," + c;
	}

	private string _text = "start";
}
