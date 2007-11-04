using System;
using System.ComponentModel;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
		components = new System.ComponentModel.Container ();
		bindingSource1 = new BindingSource (components);
		((System.ComponentModel.ISupportInitialize) (bindingSource1)).BeginInit ();
		SuspendLayout ();
		// 
		// MainForm
		// 
		AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new System.Drawing.Size (292, 266);
		Text = "bug #81148";
		((System.ComponentModel.ISupportInitialize) (bindingSource1)).EndInit ();
		Load += new EventHandler (MainForm_Load);
		ResumeLayout (false);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing && (components != null)) {
			components.Dispose ();
		}
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Close ();
	}

	private IContainer components;
	private BindingSource bindingSource1;
}
