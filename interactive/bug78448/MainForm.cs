using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace RoundedButton
{
	public class MainForm : Form
	{
		public MainForm ()
		{
			ComponentResourceManager resources = new ComponentResourceManager (typeof (MainForm));
			SuspendLayout ();
			// 
			// _roundedButton1
			// 
			_roundedButton1 = new RoundedButton ();
			_roundedButton1.BackColor = Color.DarkOrchid;
			_roundedButton1.BorderColor = Color.White;
			_roundedButton1.Font = new Font ("Mistral", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (0)));
			_roundedButton1.HighlightColor = Color.Red;
			_roundedButton1.Location = new Point (60, 10);
			_roundedButton1.SelectedColor = Color.DarkRed;
			_roundedButton1.Size = new Size (167, 26);
			_roundedButton1.TabIndex = 0;
			_roundedButton1.Text = "Press Here";
			_roundedButton1.UseVisualStyleBackColor = false;
			_roundedButton1.Click += new EventHandler (RoundedButton1_Click);
			Controls.Add (_roundedButton1);
			// 
			// _roundedButton2
			// 
			_roundedButton2 = new RoundedButton ();
			_roundedButton2.BorderColor = Color.Red;
			_roundedButton2.HighlightColor = Color.Red;
			_roundedButton2.Location = new Point (238, 10);
			_roundedButton2.SelectedColor = Color.DarkRed;
			_roundedButton2.Size = new Size (166, 62);
			_roundedButton2.TabIndex = 2;
			_roundedButton2.Text = "Or Here";
			_roundedButton2.UseVisualStyleBackColor = true;
			_roundedButton2.Click += new EventHandler (RoundedButton2_Click);
			Controls.Add (_roundedButton2);
			// 
			// _tabControl
			// 
			_tabControl = new TabControl ();
			_tabControl.Dock = DockStyle.Bottom;
			_tabControl.Height = 150;
			Controls.Add (_tabControl);
			// 
			// _bugDescriptionText1
			// 
			_bugDescriptionText1 = new TextBox ();
			_bugDescriptionText1.Multiline = true;
			_bugDescriptionText1.Location = new Point (8, 8);
			_bugDescriptionText1.Dock = DockStyle.Fill;
			_bugDescriptionText1.Text = string.Format (CultureInfo.InvariantCulture,
				"Expected result:{0}{0}" +
				"1. A form is displayed with a red background image.{0}{0}" +
				"2. The buttons are rounded.{0}{0}" +
				"3. Moving the mouse pointer over the buttons causes their " +
				"color to change.",
				Environment.NewLine);
			// 
			// _tabPage1
			// 
			_tabPage1 = new TabPage ();
			_tabPage1.Text = "#1";
			_tabPage1.Controls.Add (_bugDescriptionText1);
			_tabControl.Controls.Add (_tabPage1);
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF (6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = ((Image) (resources.GetObject ("$this.BackgroundImage")));
			ClientSize = new Size (470, 315);
			StartPosition = FormStartPosition.CenterScreen;
			Text = "bug #78448";
			ResumeLayout (false);
		}

		[STAThread]
		static void Main (string [] args)
		{
			MainForm f = new MainForm ();
			f.ShowDialog ();
		}

		void RoundedButton2_Click (object sender, EventArgs e)
		{
			MessageBox.Show ("You clicked Button #2");
		}

		void RoundedButton1_Click (object sender, EventArgs e)
		{
			MessageBox.Show ("You clicked Button #1");
		}

		private RoundedButton _roundedButton1;
		private RoundedButton _roundedButton2;
		private TextBox _bugDescriptionText1;
		private TabControl _tabControl;
		private TabPage _tabPage1;
	}

	public class RoundedButton : Button
	{
		int _BorderWidth = 2;
		Color _BorderColor = Color.White;
		Color _SelectedColor = Color.DarkRed;
		Color _HighlightColor = Color.Red;
		bool _bHighlight;
		bool _bMousePressed;

		public RoundedButton ()
		{
		}

		[Description ("Set the Border Color of the Button.")]
		[Category ("Appearance")]
		public Color BorderColor {
			get { return _BorderColor; }
			set { _BorderColor = value; }
		}

		[Description ("Set the Color of the Button when selected.")]
		[Category ("Appearance")]
		public Color SelectedColor {
			get { return _SelectedColor; }
			set { _SelectedColor = value; }
		}

		[Description ("Set the Color of the Button when highlighted.")]
		[Category ("Appearance")]
		public Color HighlightColor {
			get { return _HighlightColor; }
			set { _HighlightColor = value; }
		}

		[Description ("Set the Border Width of the Button.")]
		[Category ("Appearance")]
		[DefaultValue (2)]
		public int BorderWidth {
			get { return _BorderWidth; }
			set { _BorderWidth = value; }
		}

		public bool IsMousePressed {
			get {
				return _bMousePressed;
			}
		}

		public bool IsHighlighted {
			get {
				return _bHighlight;
			}
		}

		protected override void OnMouseDown (MouseEventArgs e)
		{
			base.OnMouseDown (e);
			_bHighlight = true;
			_bMousePressed = true;
		}

		protected override void OnMouseLeave (EventArgs e)
		{
			base.OnMouseLeave (e);
			_bHighlight = false;
			_bMousePressed = false;
		}

		protected override void OnMouseUp (MouseEventArgs e)
		{
			base.OnMouseUp (e);
			_bHighlight = true;
			_bMousePressed = false;
			this.Invalidate ();
		}

		protected override void OnMouseEnter (EventArgs e)
		{
			base.OnMouseEnter (e);
			_bHighlight = true;
			_bMousePressed = false;
		}

		protected override void OnPaint (PaintEventArgs pe)
		{
			int offset = (this.BorderWidth + 1) / 2;
			int radius = (this.Height + 1) / 2;
			int offsetX2 = 2 * offset;

			GraphicsPath gp = new GraphicsPath ();

			Rectangle r = new Rectangle (offset, offset, this.Height, this.Height - offsetX2);
			gp.AddArc (r, 90, 180);

			gp.AddLine (radius, offset, Width - radius, offset);

			Rectangle l = new Rectangle (this.Width - this.Height - offset, offset, this.Height, this.Height - offsetX2);
			gp.AddArc (l, 270, 180);

			gp.AddLine (Width - radius, this.Height - offset, radius, this.Height - offset);

			PaintParentBackground (pe);

			Color bcolor;
			if (!_bHighlight)
				bcolor = this.BackColor;
			else {
				if (_bMousePressed)
					bcolor = this.SelectedColor;
				else
					bcolor = this.HighlightColor;
			}

			Brush b = null;
			Pen p = null;
			try {
				b = new System.Drawing.SolidBrush (bcolor);
				pe.Graphics.FillPath (b, gp);
			} finally {
				if (b != null) b.Dispose ();
				b = null;
			}

			try {
				p = new Pen (this.BorderColor);
				p.Width = this.BorderWidth;

				pe.Graphics.DrawPath (p, gp);
			} finally {
				if (p != null) p.Dispose ();
				p = null;
			}

			DrawText (pe.Graphics);
		}

		private void PaintParentBackground (PaintEventArgs e)
		{
			if (Parent != null) {
				Rectangle rect = new Rectangle (Left, Top, Width, Height);
				e.Graphics.TranslateTransform (-rect.X, -rect.Y);
				try {
					using (PaintEventArgs pea = new PaintEventArgs (e.Graphics, rect)) {
						pea.Graphics.SetClip (rect);
						InvokePaintBackground (Parent, pea);
						InvokePaint (Parent, pea);
					}
				} finally {
					e.Graphics.TranslateTransform ((float) rect.X, (float) rect.Y, MatrixOrder.Append);
				}
			} else {
				e.Graphics.FillRectangle (SystemBrushes.Control, ClientRectangle);
			}
		}

		protected virtual void DrawText (Graphics g)
		{
			if (this.Text.Length > 0) {
				SizeF size = g.MeasureString (this.Text, this.Font);

				g.DrawString (this.Text, this.Font, new SolidBrush (this.ForeColor),
					(this.Width - size.Width) / 2, (this.Height - size.Height) / 2);
			}
		}
	}
}
