using System;
using System.Collections.Generic;

namespace Bug80846
{
	public class TestList<Elem>: List<Elem> where Elem: Test
	{
		public Elem FindByID(string ID)
		{
			foreach(Elem elem in this)
			{
				if (elem.ID == ID)
					return elem;
			}
			return null;
		}
	}
}
