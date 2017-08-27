namespace CS_GUI
{
	partial class ResultsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblFormula = new System.Windows.Forms.Label();
			this.grid = new System.Windows.Forms.DataGridView();
			this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.graphPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();
			// 
			// lblFormula
			// 
			this.lblFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFormula.Location = new System.Drawing.Point(12, 9);
			this.lblFormula.Name = "lblFormula";
			this.lblFormula.Size = new System.Drawing.Size(539, 23);
			this.lblFormula.TabIndex = 0;
			this.lblFormula.Text = "Calculated: {0}x²+{1}x+{2}";
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AllowUserToResizeColumns = false;
			this.grid.AllowUserToResizeRows = false;
			this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x,
            this.y});
			this.grid.Location = new System.Drawing.Point(12, 35);
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.RowHeadersVisible = false;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(174, 319);
			this.grid.TabIndex = 1;
			// 
			// x
			// 
			this.x.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.x.HeaderText = "x";
			this.x.Name = "x";
			this.x.ReadOnly = true;
			// 
			// y
			// 
			this.y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.y.HeaderText = "y";
			this.y.Name = "y";
			this.y.ReadOnly = true;
			// 
			// graphPanel
			// 
			this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.graphPanel.BackColor = System.Drawing.Color.White;
			this.graphPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.graphPanel.Location = new System.Drawing.Point(192, 35);
			this.graphPanel.Name = "graphPanel";
			this.graphPanel.Size = new System.Drawing.Size(359, 319);
			this.graphPanel.TabIndex = 2;
			this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanel_Paint);
			this.graphPanel.Resize += new System.EventHandler(this.graphPanel_Resize);
			// 
			// ResultsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 366);
			this.Controls.Add(this.graphPanel);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.lblFormula);
			this.Name = "ResultsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Results";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblFormula;
		private System.Windows.Forms.DataGridView grid;
		private System.Windows.Forms.DataGridViewTextBoxColumn x;
		private System.Windows.Forms.DataGridViewTextBoxColumn y;
		private System.Windows.Forms.Panel graphPanel;
	}
}