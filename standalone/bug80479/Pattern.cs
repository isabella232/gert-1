
using System;

using System.Collections.Generic;
using System.Xml.Serialization;

namespace AntDownloader
{
	public class Pattern : List<Sustitution>
	{
		public Pattern()
		{
		}
		
		private string sName;
		public string Name {
		  get { return this.sName; }
		  set { this.sName = value; }
		}
	
		private string sBaseUrl;
		public string BaseUrl {
		  get { return this.sBaseUrl; }
		  set { this.sBaseUrl = value; }
		}
		
		private List<string> aUrls = null;
		
		private List<string> GetAllUrls()
		{
			List<Combination> aCombs = this.GetAllCombinations();
			List<string> aResult = new List<string>();
			
			foreach(Combination oComb in aCombs)
			{
				aResult.Add(oComb.Apply(this.sBaseUrl));
			}
			
			return aResult;
		}
		
		public string GetNextUrl()
		{
			if (aUrls == null)
			{
				iUrlCount = 0;
			    this.aUrls = this.GetAllUrls();
			}
			
			if (this.aUrls.Count > this.iUrlCount)
			{
				return this.aUrls[iUrlCount++];
			}
			
			return null;
		}
		
		private int iUrlCount = 0;
		
		public List<Combination> GetAllCombinations()
		{
			List<Combination> aResult = new List<Combination>();
			if (this.Count == 0)
			{
			    return aResult;
			}
			
			Sustitution oFirstSustitution = this[0];
			
			if (this.Count == 1)
			{
				foreach(Value oValue in oFirstSustitution.PossibleValues())
				{
					aResult.Add(new Combination(oValue));
				}
				return aResult;
			}

			Pattern oSubPatternTail = new Pattern();
			
			for(int i = 1; i < this.Count; i++)
			{
				oSubPatternTail.Add(this[i]);
			}
			
			foreach(Value oValue in oFirstSustitution.PossibleValues())
			{
				foreach(Combination oComb in oSubPatternTail.GetAllCombinations())
				{
					aResult.Add(oComb.Conc(oValue));
				}
			}
			
			return aResult;
		}

	}
}
