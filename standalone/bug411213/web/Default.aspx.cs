using System;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class _Default : Page
{
	private static int _beginRequestCounter;
	private static int _endRequestCounter;

	protected Label BeginRequestCountLabel;
	protected Label EndRequestCountLabel;

	protected override void OnInit (EventArgs e)
	{
		BeginRequestCountLabel.Text = _beginRequestCounter.ToString (
			CultureInfo.InvariantCulture);
		EndRequestCountLabel.Text = _endRequestCounter.ToString (
			CultureInfo.InvariantCulture);
		base.OnInit (e);
	}

	public static void BeginRequest ()
	{
		_beginRequestCounter++;
	}

	public static void EndRequest ()
	{
		_endRequestCounter++;
	}
}
