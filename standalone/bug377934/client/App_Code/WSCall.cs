// WSCall.cs created with MonoDevelop
// User: hubert at 10:04 10/04/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace TestMDWS
{
	
	
	public class WSCall
	{
		
		public WSCall()
		{
		}
		
		public static string GetResult()
		{
			 com.w3schools.www.TempConvert tempConvert = new com.w3schools.www.TempConvert();
			string tempfahr=tempConvert.CelsiusToFahrenheit("20");
			return tempfahr;
		}
	}
}
