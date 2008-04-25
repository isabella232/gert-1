using System;

namespace WindowsAppli
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		private void InitializeComponent ()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView ();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn ();
			((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit ();
			this.SuspendLayout ();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange (new System.Windows.Forms.DataGridViewColumn [] { this.Column1});
			this.dataGridView1.Location = new System.Drawing.Point (12, 115);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 21;
			this.dataGridView1.Size = new System.Drawing.Size (268, 146);
			this.dataGridView1.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "金額";
			this.Column1.Name = "Column1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size (292, 273);
			this.Controls.Add (this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit ();
			this.ResumeLayout (false);
			Load += new EventHandler (Form1_Load);
		}

		void Form1_Load (object sender, EventArgs e)
		{
			Close ();
		}

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
	}
}

