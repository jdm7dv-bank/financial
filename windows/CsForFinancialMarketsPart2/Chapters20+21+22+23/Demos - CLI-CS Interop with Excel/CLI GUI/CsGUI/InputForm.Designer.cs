namespace CsGUI
{
	partial class InputForm
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label lbl_percentageMovement;
			this.lbl_r = new System.Windows.Forms.Label();
			this.txt_r = new System.Windows.Forms.TextBox();
			this.txt_sig = new System.Windows.Forms.TextBox();
			this.lbl_sig = new System.Windows.Forms.Label();
			this.txt_K = new System.Windows.Forms.TextBox();
			this.lbl_K = new System.Windows.Forms.Label();
			this.txt_T = new System.Windows.Forms.TextBox();
			this.lbl_T = new System.Windows.Forms.Label();
			this.txt_U = new System.Windows.Forms.TextBox();
			this.lbl_U = new System.Windows.Forms.Label();
			this.txt_b = new System.Windows.Forms.TextBox();
			this.lbl_b = new System.Windows.Forms.Label();
			this.cb_otyp = new System.Windows.Forms.ComboBox();
			this.lbl_otyp = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.chkOutputToExcel = new System.Windows.Forms.CheckBox();
			this.txt_percentageMovement = new System.Windows.Forms.TextBox();
			this.rtfAbout = new System.Windows.Forms.RichTextBox();
			this.lblHeader = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			lbl_percentageMovement = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// lbl_percentageMovement
			// 
			lbl_percentageMovement.AutoSize = true;
			lbl_percentageMovement.Location = new System.Drawing.Point(171, 423);
			lbl_percentageMovement.Name = "lbl_percentageMovement";
			lbl_percentageMovement.Size = new System.Drawing.Size(175, 13);
			lbl_percentageMovement.TabIndex = 16;
			lbl_percentageMovement.Text = "Percentage movement for elasticity:";
			// 
			// lbl_r
			// 
			this.lbl_r.AutoSize = true;
			this.lbl_r.Location = new System.Drawing.Point(12, 344);
			this.lbl_r.Name = "lbl_r";
			this.lbl_r.Size = new System.Drawing.Size(78, 13);
			this.lbl_r.TabIndex = 3;
			this.lbl_r.Text = "Interest rate (r):";
			// 
			// txt_r
			// 
			this.txt_r.Location = new System.Drawing.Point(124, 341);
			this.txt_r.Name = "txt_r";
			this.txt_r.Size = new System.Drawing.Size(121, 20);
			this.txt_r.TabIndex = 4;
			this.txt_r.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// txt_sig
			// 
			this.txt_sig.Location = new System.Drawing.Point(352, 341);
			this.txt_sig.Name = "txt_sig";
			this.txt_sig.Size = new System.Drawing.Size(121, 20);
			this.txt_sig.TabIndex = 6;
			this.txt_sig.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lbl_sig
			// 
			this.lbl_sig.AutoSize = true;
			this.lbl_sig.Location = new System.Drawing.Point(264, 344);
			this.lbl_sig.Name = "lbl_sig";
			this.lbl_sig.Size = new System.Drawing.Size(70, 13);
			this.lbl_sig.TabIndex = 5;
			this.lbl_sig.Text = "Volatility (sig):";
			// 
			// txt_K
			// 
			this.txt_K.Location = new System.Drawing.Point(124, 367);
			this.txt_K.Name = "txt_K";
			this.txt_K.Size = new System.Drawing.Size(121, 20);
			this.txt_K.TabIndex = 8;
			this.txt_K.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lbl_K
			// 
			this.lbl_K.AutoSize = true;
			this.lbl_K.Location = new System.Drawing.Point(12, 370);
			this.lbl_K.Name = "lbl_K";
			this.lbl_K.Size = new System.Drawing.Size(79, 13);
			this.lbl_K.TabIndex = 7;
			this.lbl_K.Text = "Strike price (K):";
			// 
			// txt_T
			// 
			this.txt_T.Location = new System.Drawing.Point(352, 367);
			this.txt_T.Name = "txt_T";
			this.txt_T.Size = new System.Drawing.Size(121, 20);
			this.txt_T.TabIndex = 10;
			this.txt_T.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lbl_T
			// 
			this.lbl_T.AutoSize = true;
			this.lbl_T.Location = new System.Drawing.Point(264, 370);
			this.lbl_T.Name = "lbl_T";
			this.lbl_T.Size = new System.Drawing.Size(78, 13);
			this.lbl_T.TabIndex = 9;
			this.lbl_T.Text = "Expiry date (T):";
			// 
			// txt_U
			// 
			this.txt_U.Location = new System.Drawing.Point(124, 393);
			this.txt_U.Name = "txt_U";
			this.txt_U.Size = new System.Drawing.Size(121, 20);
			this.txt_U.TabIndex = 12;
			this.txt_U.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lbl_U
			// 
			this.lbl_U.AutoSize = true;
			this.lbl_U.Location = new System.Drawing.Point(12, 396);
			this.lbl_U.Name = "lbl_U";
			this.lbl_U.Size = new System.Drawing.Size(103, 13);
			this.lbl_U.TabIndex = 11;
			this.lbl_U.Text = "Underlying price (U):";
			// 
			// txt_b
			// 
			this.txt_b.Location = new System.Drawing.Point(352, 393);
			this.txt_b.Name = "txt_b";
			this.txt_b.Size = new System.Drawing.Size(121, 20);
			this.txt_b.TabIndex = 14;
			this.txt_b.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lbl_b
			// 
			this.lbl_b.AutoSize = true;
			this.lbl_b.Location = new System.Drawing.Point(264, 396);
			this.lbl_b.Name = "lbl_b";
			this.lbl_b.Size = new System.Drawing.Size(84, 13);
			this.lbl_b.TabIndex = 13;
			this.lbl_b.Text = "Cost of carry (b):";
			// 
			// cb_otyp
			// 
			this.cb_otyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_otyp.FormattingEnabled = true;
			this.cb_otyp.Location = new System.Drawing.Point(124, 314);
			this.cb_otyp.Name = "cb_otyp";
			this.cb_otyp.Size = new System.Drawing.Size(349, 21);
			this.cb_otyp.TabIndex = 2;
			// 
			// lbl_otyp
			// 
			this.lbl_otyp.AutoSize = true;
			this.lbl_otyp.Location = new System.Drawing.Point(12, 317);
			this.lbl_otyp.Name = "lbl_otyp";
			this.lbl_otyp.Size = new System.Drawing.Size(64, 13);
			this.lbl_otyp.TabIndex = 1;
			this.lbl_otyp.Text = "Option type:";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(317, 455);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 18;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(398, 455);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 19;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// chkOutputToExcel
			// 
			this.chkOutputToExcel.AutoSize = true;
			this.chkOutputToExcel.Location = new System.Drawing.Point(15, 423);
			this.chkOutputToExcel.Name = "chkOutputToExcel";
			this.chkOutputToExcel.Size = new System.Drawing.Size(126, 17);
			this.chkOutputToExcel.TabIndex = 15;
			this.chkOutputToExcel.Text = "Output to Excel 2007";
			this.chkOutputToExcel.UseVisualStyleBackColor = true;
			// 
			// txt_percentageMovement
			// 
			this.txt_percentageMovement.Location = new System.Drawing.Point(352, 420);
			this.txt_percentageMovement.Name = "txt_percentageMovement";
			this.txt_percentageMovement.Size = new System.Drawing.Size(121, 20);
			this.txt_percentageMovement.TabIndex = 17;
			this.txt_percentageMovement.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// rtfAbout
			// 
			this.rtfAbout.BackColor = System.Drawing.SystemColors.Window;
			this.rtfAbout.Location = new System.Drawing.Point(12, 36);
			this.rtfAbout.Name = "rtfAbout";
			this.rtfAbout.ReadOnly = true;
			this.rtfAbout.Size = new System.Drawing.Size(461, 219);
			this.rtfAbout.TabIndex = 21;
			this.rtfAbout.Text = "";
			// 
			// lblHeader
			// 
			this.lblHeader.AutoSize = true;
			this.lblHeader.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHeader.Location = new System.Drawing.Point(12, 275);
			this.lblHeader.Name = "lblHeader";
			this.lblHeader.Size = new System.Drawing.Size(301, 24);
			this.lblHeader.TabIndex = 22;
			this.lblHeader.Text = "Extended Option Parameters";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 24);
			this.label1.TabIndex = 23;
			this.label1.Text = "About";
			// 
			// InputForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(485, 490);
			this.Controls.Add(this.rtfAbout);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblHeader);
			this.Controls.Add(this.txt_percentageMovement);
			this.Controls.Add(lbl_percentageMovement);
			this.Controls.Add(this.chkOutputToExcel);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lbl_otyp);
			this.Controls.Add(this.cb_otyp);
			this.Controls.Add(this.txt_b);
			this.Controls.Add(this.lbl_b);
			this.Controls.Add(this.txt_U);
			this.Controls.Add(this.lbl_U);
			this.Controls.Add(this.txt_T);
			this.Controls.Add(this.lbl_T);
			this.Controls.Add(this.txt_K);
			this.Controls.Add(this.lbl_K);
			this.Controls.Add(this.txt_sig);
			this.Controls.Add(this.lbl_sig);
			this.Controls.Add(this.txt_r);
			this.Controls.Add(this.lbl_r);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputForm";
			this.Text = "Extended Option Parameters";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_r;
		private System.Windows.Forms.TextBox txt_r;
		private System.Windows.Forms.TextBox txt_sig;
		private System.Windows.Forms.Label lbl_sig;
		private System.Windows.Forms.TextBox txt_K;
		private System.Windows.Forms.Label lbl_K;
		private System.Windows.Forms.TextBox txt_T;
		private System.Windows.Forms.Label lbl_T;
		private System.Windows.Forms.TextBox txt_U;
		private System.Windows.Forms.Label lbl_U;
		private System.Windows.Forms.TextBox txt_b;
		private System.Windows.Forms.Label lbl_b;
		private System.Windows.Forms.ComboBox cb_otyp;
		private System.Windows.Forms.Label lbl_otyp;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.CheckBox chkOutputToExcel;
		private System.Windows.Forms.TextBox txt_percentageMovement;
		private System.Windows.Forms.RichTextBox rtfAbout;
		private System.Windows.Forms.Label lblHeader;
		private System.Windows.Forms.Label label1;
	}
}