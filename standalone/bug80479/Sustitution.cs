
using System;

using System.Collections.Generic;
using System.Xml.Serialization;

namespace AntDownloader
{
	public class Sustitution : List<ISustitutionType>
	{
		
		public Sustitution()
		{
		}
	
		private int iNumber;
		public int Number {
		  get { return this.iNumber; }
		  set { this.iNumber = value; }
		}
		
		public List<Value> PossibleValues()
		{
		    List<Value> aResult = new List<Value>();
		    foreach(ISustitutionType oSustType in this)
		    {
		        foreach(string sValue in oSustType.PossibleValues()){
		            aResult.Add(new Value(this.iNumber, sValue));
		        }
		    }
		    
		    return aResult;
		}
	}
}
