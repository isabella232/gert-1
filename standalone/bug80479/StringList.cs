
using System;

using System.Collections.Generic;

namespace AntDownloader
{
	public class StringList : List<string>, ISustitutionType
	{
		public StringList():base()
		{
		}
		
		public List<string> PossibleValues()
		{
			return this;
		}
	}
}
