using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Diagnostics;
using System.IO;


/// <summary>
/// Summary description for Form1.
/// </summary>
public class DirectoryForm : System.Windows.Forms.Form
{
	private System.Windows.Forms.Label lblSearch;
	private System.Windows.Forms.Button btnDir;
	private System.Windows.Forms.TextBox txtSearch;
	private System.Windows.Forms.RichTextBox txtDir;

	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.Container components = null;

	public DirectoryForm()
	{
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		//
		// TODO: Add any constructor code after InitializeComponent call
		//
	}

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	protected override void Dispose( bool disposing )
	{
		if( disposing )
		{
			if (components != null) 
			{
				components.Dispose();
			}
		}
		base.Dispose( disposing );
	}

	#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
        this.lblSearch = new System.Windows.Forms.Label();
        this.txtSearch = new System.Windows.Forms.TextBox();
        this.btnDir = new System.Windows.Forms.Button();
        this.txtDir = new System.Windows.Forms.RichTextBox();
        this.SuspendLayout();
        this.ResumeLayout(false);

	}
	#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new DirectoryForm());
	}

	private void btnDir_Click(object sender, System.EventArgs e)
	{
		// Create the process start info object with command and arguments
		ProcessStartInfo si=new ProcessStartInfo("cmd.exe", @"/C dir " + txtSearch.Text);

		// Disables dos box window
		si.CreateNoWindow=true;

		// Enable redirection of standard output
		si.RedirectStandardOutput=true;
		si.UseShellExecute=false;

		// Start the process
		Process p=Process.Start(si);

		// Read process output
		txtDir.Text=p.StandardOutput.ReadToEnd();
	}

    private void DirectoryForm_Load(object sender, EventArgs e)
    {

    }
}
