using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MonoLab
{
	[Serializable]
	public class MonoItem
	{
		private string _Name;
		private int _Id;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		public MonoItem(string name, int id)
		{
			_Name = name;
			_Id = id;
		}
	}
}
