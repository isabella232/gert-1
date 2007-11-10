using System;

namespace Bug80846
{
	public class TestBase: ITest
	{
		private string _ID;

		public virtual string ID {
			get {return _ID;}
			set {_ID = ID;}
		}
	}
}
