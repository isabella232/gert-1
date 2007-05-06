
using System;

namespace AntDownloader
{
	public class Value
	{
		public Value(int iNumber, string sStringValue)
		{
			this.iNumber = iNumber;
			this.sStringValue = sStringValue;
		}
		
		private string sStringValue;
		public string StringValue {
		  get { return this.sStringValue; }
		  set { this.sStringValue = value; }
		}
		
		private int iNumber;
		public int Number {
		  get { return this.iNumber; }
		  set { this.iNumber = value; }
		}
	}
}
