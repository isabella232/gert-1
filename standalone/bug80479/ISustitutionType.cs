
using System;

using System.Collections.Generic;
using System.Xml.Serialization;

namespace AntDownloader
{
	public interface ISustitutionType
	{
		List<string> PossibleValues();
	}
}
