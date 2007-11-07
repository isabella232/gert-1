using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm ()
	{
		// 
		// _playButton
		// 
		_playButton = new Button ();
		_playButton.Location = new Point (60, 20);
		_playButton.Size = new Size (60, 20);
		_playButton.Text = "Play";
		_playButton.Click += new EventHandler (PlayButton_Click);
		Controls.Add (_playButton);
		// 
		// _stopButton
		// 
		_stopButton = new Button ();
		_stopButton.Location = new Point (170, 20);
		_stopButton.Size = new Size (60, 20);
		_stopButton.Text = "Stop";
		_stopButton.Click += new EventHandler (StopButton_Click);
		Controls.Add (_stopButton);
		// 
		// _loopingCheckBox
		// 
		_loopingCheckBox = new CheckBox ();
		_loopingCheckBox.Location = new Point (8, 65);
		_loopingCheckBox.Size = new Size (80, 20);
		_loopingCheckBox.Text = "Looping";
		_loopingCheckBox.CheckedChanged += new EventHandler (LoopingCheckBox_CheckedChanged);
		Controls.Add (_loopingCheckBox);
		// 
		// _syncCheckBox
		// 
		_syncCheckBox = new CheckBox ();
		_syncCheckBox.Location = new Point (100, 65);
		_syncCheckBox.Size = new Size (100, 20);
		_syncCheckBox.Text = "Synchronous";
		Controls.Add (_syncCheckBox);
		// 
		// MainForm
		// 
		ClientSize = new Size (300, 90);
		Location = new Point (250, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #338991";
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.Run (new MainForm ());
	}

	protected override void Dispose (bool disposing)
	{
		if (disposing) {
			if (_player != null) {
				Stream s = _player.Stream;
				if (s != null)
					s.Dispose ();
				_player = null;
			}
		}
		base.Dispose (disposing);
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;
		FileStream fs = File.OpenRead (Path.Combine (dir, "Asterisk.wav"));
		_player = new SoundPlayer (fs);

		InstructionsForm instructionsForm = new InstructionsForm ();
		instructionsForm.Show ();
	}

	void PlayButton_Click (object sender, EventArgs e)
	{
		if (_loopingCheckBox.Checked) {
			_player.PlayLooping ();
		} else {
			if (_syncCheckBox.Checked)
				_player.PlaySync ();
			else
				_player.Play ();
		}

		_playButton.Visible = false;
		Thread.Sleep (1000);
		_playButton.Visible = true;
	}

	void StopButton_Click (object sender, EventArgs e)
	{
		_player.Stop ();
	}

	void LoopingCheckBox_CheckedChanged (object sender, EventArgs e)
	{
		_syncCheckBox.Enabled = !_loopingCheckBox.Checked;
	}

	private SoundPlayer _player;
	private Button _playButton;
	private Button _stopButton;
	private CheckBox _loopingCheckBox;
	private CheckBox _syncCheckBox;
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
			"1. Uncheck the Looping checkbox.{0}{0}" +
			"2. Uncheck the Synchronous checkbox.{0}{0}" +
			"3. Click the Play button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The sound immediately plays one time.{0}{0}" +
			"2. The Play button immediately renders invisible " +
			"for a second.",
			Environment.NewLine);
		// 
		// _tabPage1
		// 
		_tabPage1 = new TabPage ();
		_tabPage1.Text = "#1";
		_tabPage1.Controls.Add (_bugDescriptionText1);
		_tabControl.Controls.Add (_tabPage1);
		// 
		// _bugDescriptionText2
		// 
		_bugDescriptionText2 = new TextBox ();
		_bugDescriptionText2.Dock = DockStyle.Fill;
		_bugDescriptionText2.Multiline = true;
		_bugDescriptionText2.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Uncheck the Looping checkbox.{0}{0}" +
			"2. Check the Synchronous checkbox.{0}{0}" +
			"3. Click the Play button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The sound immediately plays one time.{0}{0}" +
			"2. The Play button renders invisible for a second " +
			"after the sound has finished playing.",
			Environment.NewLine);
		// 
		// _tabPage2
		// 
		_tabPage2 = new TabPage ();
		_tabPage2.Text = "#2";
		_tabPage2.Controls.Add (_bugDescriptionText2);
		_tabControl.Controls.Add (_tabPage2);
		// 
		// _bugDescriptionText3
		// 
		_bugDescriptionText3 = new TextBox ();
		_bugDescriptionText3.Dock = DockStyle.Fill;
		_bugDescriptionText3.Multiline = true;
		_bugDescriptionText3.Text = string.Format (CultureInfo.InvariantCulture,
			"Steps to execute:{0}{0}" +
			"1. Check the Looping checkbox.{0}{0}" +
			"2. Click the Play button.{0}{0}" +
			"Expected result:{0}{0}" +
			"1. The Play button immediately renders invisible " +
			"for a second.{0}{0}" +
			"1. The sound immediately starts playing in a loop.",
			Environment.NewLine);
		// 
		// _tabPage3
		// 
		_tabPage3 = new TabPage ();
		_tabPage3.Text = "#3";
		_tabPage3.Controls.Add (_bugDescriptionText3);
		_tabControl.Controls.Add (_tabPage3);
		// 
		// InstructionsForm
		// 
		ClientSize = new Size (300, 240);
		Location = new Point (600, 100);
		StartPosition = FormStartPosition.Manual;
		Text = "Instructions - bug #338991";
	}

	private TextBox _bugDescriptionText1;
	private TextBox _bugDescriptionText2;
	private TextBox _bugDescriptionText3;
	private TabControl _tabControl;
	private TabPage _tabPage1;
	private TabPage _tabPage2;
	private TabPage _tabPage3;
}
