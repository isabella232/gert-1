using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _label
		// 
		_label = new Label ();
		_label.AutoSize = true;
		_label.Location = new Point (16, 19);
		_label.Margin = new Padding (4);
		_label.Text = "Ready";
		_label.Size = new Size (36, 17);
		_label.TabIndex = 1;
		Controls.Add (_label);
		// 
		// _button
		// 
		_button = new Button ();
		_button.Location = new Point (130, 12);
		_button.Margin = new Padding (4);
		_button.Size = new Size (91, 28);
		_button.TabIndex = 2;
		_button.Text = "Start";
		_button.UseVisualStyleBackColor = true;
		_button.Click += new EventHandler (Button_Click);
		_button.Visible = true;
		Controls.Add (_button);
		// 
		// _backgroundWorker
		// 
		_backgroundWorker = new BackgroundWorker ();
		_backgroundWorker.WorkerSupportsCancellation = true;
		_backgroundWorker.DoWork += new DoWorkEventHandler (OnDoWork);
		_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler (OnWorkDone);
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF (8F, 16F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size (184, 50);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		Location = new Point (300, 100);
		StartPosition = FormStartPosition.Manual;
		Margin = new Padding (4);
		MaximizeBox = false;
		Text = "bug #373153";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.SetCompatibleTextRenderingDefault (false);
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void UpdateLabel (string text)
	{
		if (_label.InvokeRequired)
			Invoke (new UpdateLabelCallback (UpdateLabel), text);
		else
			_label.Text = text;
	}

	void Button_Click (object sender, EventArgs e)
	{
		if (_button.Text.Equals ("Start"))
			StartTest ();
		else
			StopTest ();
	}

	void StartTest ()
	{
		_button.Text = "Stop";
		_backgroundWorker.RunWorkerAsync ();
	}

	void StopTest ()
	{
		_button.Enabled = false;
		_backgroundWorker.CancelAsync ();
	}

	void OnDoWork (object sender, DoWorkEventArgs e)
	{
		_counter = 0;
		while (!_backgroundWorker.CancellationPending) {
			UpdateLabel (_counter.ToString ());
			Thread.Sleep (1000);
			++_counter;
		}
		e.Cancel = true;
	}

	void OnWorkDone (object sender, RunWorkerCompletedEventArgs e)
	{
		_button.Enabled = true;
		_button.Text = "Start";
		UpdateLabel ("Done!");
	}

	delegate void UpdateLabelCallback (string text);

	private Label _label;
	private Button _button;
	private BackgroundWorker _backgroundWorker;
	private int _counter;
}

public class InstructionsForm : Form
{
	public InstructionsForm ()
	{
		// 
		// _tabControl
		// 
		_tabControl = new TabControl ();
		_tabControl.Dock = DockStyle.Fill;
		Controls.Add (_tabControl);
		// 
		// _bugDescriptionText1
		// 
		_bugDescriptionText1 = new TextBox ();
		_bugDescriptionText1.Dock = DockStyle.Fill;
		_bugDescriptionText1.Multiline = true;
		_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Click the Start button.{0}{0}" +
			"2. Wait a few seconds.{0}{0}" +
			"3. Click the Stop button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. On step 1, the counter increments each second.{0}{0}" +
			"2. On step 3, \"Done!\" is displayed and the counter " +
			"no longer increments.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (320, 230);
		Location = new Point (550, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #373153";
	}

	private TextBox _bugDescriptionText1;
	private TabControl _tabControl;
	private TabPage _tabPage1;
}
