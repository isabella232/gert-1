using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
	public MainForm ()
	{
#if NET_2_0
		_dataGrid = new DataGridView ();
		_column = new DataGridViewTextBoxColumn ();
#else
		_dataGrid = new DataGrid ();
		_column = new DataGridTextBoxColumn ();
#endif
		SuspendLayout ();
		((ISupportInitialize) (_dataGrid)).BeginInit ();
		// 
		// _dataGrid
		// 
#if NET_2_0
		_dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		_dataGrid.Columns.Add (_column);
		_dataGrid.RowTemplate.Height = 21;
#else
		_dataGrid.TableStyles.Add (new DataGridTableStyle ());
		_dataGrid.TableStyles [0].GridColumnStyles.Add (_column);
#endif
		_dataGrid.Location = new Point (12, 115);
		_dataGrid.Size = new Size (268, 146);
		_dataGrid.TabIndex = 0;
		// 
		// _column
		// 
		_column.HeaderText = "Column";
		// 
		// MainForm
		// 
		ClientSize = new Size (292, 273);
		Controls.Add (_dataGrid);
		((ISupportInitialize) (_dataGrid)).EndInit ();
		ResumeLayout (false);
		Load += new EventHandler (MainForm_Load);
	}

	[STAThread]
	static void Main ()
	{
		Application.EnableVisualStyles ();
		Application.Run (new MainForm ());
	}

	void MainForm_Load (object sender, EventArgs e)
	{
		Close ();
	}

#if NET_2_0
	private DataGridView _dataGrid;
	private DataGridViewTextBoxColumn _column;
#else
	private DataGrid _dataGrid;
	private DataGridTextBoxColumn _column;
#endif
}
