using System;
using System.Collections;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Mono.Web
{
	public class _Default : Page
	{
		protected Label Label1;
		protected Button SubmitButton;
		protected TextBox TextBox1;

		void Page_Load (object sender, System.EventArgs e)
		{
			Label1.Text = "Page Loaded";
		}

		override protected void OnInit (EventArgs e)
		{
			InitializeComponent ();
			base.OnInit (e);
		}

		void InitializeComponent ()
		{
			SubmitButton.Click += new EventHandler (SubmitButton_Click);
			Load += new EventHandler (Page_Load);
		}

		void SubmitButton_Click (object sender, EventArgs e)
		{
			Label1.Text = TextBox1.Text;
		}
	}
}
