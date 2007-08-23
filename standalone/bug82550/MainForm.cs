using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Threading;

[assembly: AssemblyDelaySign (false)]
[assembly: AssemblyKeyFile ("")]
[assembly: AssemblyKeyName ("")]

namespace LocalizationTest
{
	public class MainForm : Form
	{
		private Button button1;
		private Container components = null;

		public MainForm ()
		{
			ResourceManager resources = new ResourceManager (typeof (MainForm));
			button1 = new Button ();
			SuspendLayout ();
			// 
			// button1
			// 
			button1.AccessibleDescription = resources.GetString ("button1.AccessibleDescription");
			button1.AccessibleName = resources.GetString ("button1.AccessibleName");
			button1.Anchor = ((AnchorStyles) (resources.GetObject ("button1.Anchor")));
			button1.BackgroundImage = ((Image) (resources.GetObject ("button1.BackgroundImage")));
			button1.Dock = ((DockStyle) (resources.GetObject ("button1.Dock")));
			button1.Enabled = ((bool) (resources.GetObject ("button1.Enabled")));
			button1.FlatStyle = ((FlatStyle) (resources.GetObject ("button1.FlatStyle")));
			button1.Font = ((Font) (resources.GetObject ("button1.Font")));
			button1.Image = ((Image) (resources.GetObject ("button1.Image")));
			button1.ImageAlign = ((ContentAlignment) (resources.GetObject ("button1.ImageAlign")));
			button1.ImageIndex = ((int) (resources.GetObject ("button1.ImageIndex")));
			button1.ImeMode = ((ImeMode) (resources.GetObject ("button1.ImeMode")));
			button1.Location = ((Point) (resources.GetObject ("button1.Location")));
			button1.Name = "button1";
			button1.RightToLeft = ((RightToLeft) (resources.GetObject ("button1.RightToLeft")));
			button1.Size = ((Size) (resources.GetObject ("button1.Size")));
			button1.TabIndex = ((int) (resources.GetObject ("button1.TabIndex")));
			button1.Text = resources.GetString ("button1.Text");
			button1.TextAlign = ((ContentAlignment) (resources.GetObject ("button1.TextAlign")));
			button1.Visible = ((bool) (resources.GetObject ("button1.Visible")));
			// 
			// MainForm
			// 
			AccessibleDescription = resources.GetString ("$this.AccessibleDescription");
			AccessibleName = resources.GetString ("$this.AccessibleName");
			AutoScaleBaseSize = ((Size) (resources.GetObject ("$this.AutoScaleBaseSize")));
			AutoScroll = ((bool) (resources.GetObject ("$this.AutoScroll")));
			AutoScrollMargin = ((Size) (resources.GetObject ("$this.AutoScrollMargin")));
			AutoScrollMinSize = ((Size) (resources.GetObject ("$this.AutoScrollMinSize")));
			BackgroundImage = ((Image) (resources.GetObject ("$this.BackgroundImage")));
			ClientSize = ((Size) (resources.GetObject ("$this.ClientSize")));
			Controls.Add (button1);
			Enabled = ((bool) (resources.GetObject ("$this.Enabled")));
			Font = ((Font) (resources.GetObject ("$this.Font")));
			Icon = ((Icon) (resources.GetObject ("$this.Icon")));
			ImeMode = ((ImeMode) (resources.GetObject ("$this.ImeMode")));
			Location = ((Point) (resources.GetObject ("$this.Location")));
			MaximumSize = ((Size) (resources.GetObject ("$this.MaximumSize")));
			MinimumSize = ((Size) (resources.GetObject ("$this.MinimumSize")));
			Name = "bug #82550";
			RightToLeft = ((RightToLeft) (resources.GetObject ("$this.RightToLeft")));
			StartPosition = ((FormStartPosition) (resources.GetObject ("$this.StartPosition")));
			Text = resources.GetString ("$this.Text");
			ResumeLayout (false);
			Load += new EventHandler (MainForm_Load);
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose ();
				}
			}
			base.Dispose (disposing);
		}

		[STAThread]
		static void Main ()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture ("en");
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

			Application.Run (new MainForm ());
		}

		void MainForm_Load (object sender, EventArgs e)
		{
			Close ();
		}
	}
}
