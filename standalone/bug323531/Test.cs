using System;

namespace Bug80846
{
	public class Test: TestBase
	{
		public override string ID {
			get { return base.ID; }
			set { base.ID = value; }
		}
	}
}
