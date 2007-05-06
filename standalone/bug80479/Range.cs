
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AntDownloader
{
	public class Range : ISustitutionType
	{

		public Range ()
		{
		}

		private string sLowerLimit;
		public string LowerLimit
		{
			get { return this.sLowerLimit; }
			set { this.sLowerLimit = value; }
		}

		private string sHigherLimit;
		public string HigherLimit
		{
			get { return this.sHigherLimit; }
			set { this.sHigherLimit = value; }
		}

		public List<string> PossibleValues ()
		{
			List<string> aResult = new List<string> ();
			int? iLowerLimit, iHigherLimit = null;

			iLowerLimit = int.Parse (this.sLowerLimit);
			if (!String.IsNullOrEmpty (this.sHigherLimit)) {
				iHigherLimit = int.Parse (this.sHigherLimit);
			}
			int iLowerLimitDigits = this.sLowerLimit.Length;

			for (int? i = iLowerLimit; i <= iHigherLimit; i++) {
				string sNumber = i.ToString ();
				int iDigitsDifference = iLowerLimitDigits - sNumber.Length;
				if (iDigitsDifference < 0) {
					iDigitsDifference = 0;
				}

				aResult.Add (new String ('0', iDigitsDifference) + sNumber);
			}

			return aResult;
		}
	}
}
