
using System;

using System.Collections.Generic;

namespace AntDownloader
{
	public class Combination : List<Value>
	{
		private Combination():base()
		{
		}
	
		public Combination(Value oValue):this()
		{
			this.Add(oValue);
		}

		public Combination Conc(Value oNewValue)
		{
			foreach(Value oValue in this)
			{
				if (oValue.Number == oNewValue.Number)
				{
					throw new Exception(
						"A combination should have different Value object types");
				}
			}
			
			Combination oNewComb = new Combination(oNewValue);
			foreach(Value oValue in this)
			{
				oNewComb.Add(oValue);
			}
			
			return oNewComb;
		}
		
		
		public string Apply(string sBaseUrl)
		{
		
			string sResult = sBaseUrl;
			foreach(Value oValue in this)
			{
				sResult =
				    sResult.Replace("{"+oValue.Number+"}", oValue.StringValue);
			}
			
			return sResult;
		}
	}
}
