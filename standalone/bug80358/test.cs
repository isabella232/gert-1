using System;
using System.Windows.Forms;

namespace Test.Common
{
	partial class SectionControl<T>
	{
	}
}

namespace Test.Common
{
	public partial class SectionControl<T> : UserControl
	{
		public delegate void DrawItemEventHandler (object sender, DrawItemEventArgs e, T item);
	}
}
