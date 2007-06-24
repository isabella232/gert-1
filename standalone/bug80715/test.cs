using System;

class bug80715
{
	void aaaa ()
	{
		if (1 == 0) {
			try {
			} catch (TestException tex) {
				int x = (int) tex.SocketErrorCode;
			}
		}
	}
}

class TestException : Exception
{
}
