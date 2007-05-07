using System;

public partial class Index : BasePage
{
	protected void Page_Load (object sender, EventArgs e)
	{
		testLiteral.Text = CustomValue;
		myEnumLiteral.Text = MyEnum.ToString ();
	}
}
