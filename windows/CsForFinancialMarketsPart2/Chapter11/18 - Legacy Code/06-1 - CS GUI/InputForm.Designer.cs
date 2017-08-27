namespace CS_GUI
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
			this.lblA = new System.Windows.Forms.Label();
			this.txtA = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.lblInfo = new System.Windows.Forms.Label();
			this.txtB = new System.Windows.Forms.TextBox();
			this.lbl_b = new System.Windows.Forms.Label();
			this.txtC = new System.Windows.Forms.TextBox();
			this.lblC = new System.Windows.Forms.Label();
			this.txtXMin = new System.Windows.Forms.TextBox();
			this.lbXMin = new System.Windows.Forms.Label();
			this.txtXMax = new System.Windows.Forms.TextBox();
			this.lblXMax = new System.Windows.Forms.Label();
			this.txtStep = new System.Windows.Forms.TextBox();
			this.lblStep = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// lblA
			// 
			this.lblA.AutoSize = true;
			this.lblA.Location = new System.Drawing.Point(12, 48);
			this.lblA.Name = "lblA";
			this.lblA.Size = new System.Drawing.Size(13, 13);
			this.lblA.TabIndex = 2;
			this.lblA.Text = "a";
			// 
			// txtA
			// 
			this.txtA.Location = new System.Drawing.Point(52, 45);
			this.txtA.Name = "txtA";
			this.txtA.Size = new System.Drawing.Size(118, 20);
			this.txtA.TabIndex = 3;
			this.txtA.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// lblInfo
			// 
			this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInfo.Location = new System.Drawing.Point(12, 9);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(334, 23);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Text = "Calculate: a.x²+b.x+c";
			// 
			// txtB
			// 
			this.txtB.Location = new System.Drawing.Point(52, 71);
			this.txtB.Name = "txtB";
			this.txtB.Size = new System.Drawing.Size(118, 20);
			this.txtB.TabIndex = 5;
			this.txtB.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lbl_b
			// 
			this.lbl_b.AutoSize = true;
			this.lbl_b.Location = new System.Drawing.Point(12, 74);
			this.lbl_b.Name = "lbl_b";
			this.lbl_b.Size = new System.Drawing.Size(13, 13);
			this.lbl_b.TabIndex = 4;
			this.lbl_b.Text = "b";
			// 
			// txtC
			// 
			this.txtC.Location = new System.Drawing.Point(52, 97);
			this.txtC.Name = "txtC";
			this.txtC.Size = new System.Drawing.Size(118, 20);
			this.txtC.TabIndex = 7;
			this.txtC.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lblC
			// 
			this.lblC.AutoSize = true;
			this.lblC.Location = new System.Drawing.Point(12, 100);
			this.lblC.Name = "lblC";
			this.lblC.Size = new System.Drawing.Size(13, 13);
			this.lblC.TabIndex = 6;
			this.lblC.Text = "c";
			// 
			// txtXMin
			// 
			this.txtXMin.Location = new System.Drawing.Point(229, 45);
			this.txtXMin.Name = "txtXMin";
			this.txtXMin.Size = new System.Drawing.Size(117, 20);
			this.txtXMin.TabIndex = 9;
			this.txtXMin.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lbXMin
			// 
			this.lbXMin.AutoSize = true;
			this.lbXMin.Location = new System.Drawing.Point(189, 48);
			this.lbXMin.Name = "lbXMin";
			this.lbXMin.Size = new System.Drawing.Size(31, 13);
			this.lbXMin.TabIndex = 8;
			this.lbXMin.Text = "x-min";
			// 
			// txtXMax
			// 
			this.txtXMax.Location = new System.Drawing.Point(229, 71);
			this.txtXMax.Name = "txtXMax";
			this.txtXMax.Size = new System.Drawing.Size(117, 20);
			this.txtXMax.TabIndex = 11;
			this.txtXMax.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lblXMax
			// 
			this.lblXMax.AutoSize = true;
			this.lblXMax.Location = new System.Drawing.Point(189, 74);
			this.lblXMax.Name = "lblXMax";
			this.lblXMax.Size = new System.Drawing.Size(34, 13);
			this.lblXMax.TabIndex = 10;
			this.lblXMax.Text = "x-max";
			// 
			// txtStep
			// 
			this.txtStep.Location = new System.Drawing.Point(229, 97);
			this.txtStep.Name = "txtStep";
			this.txtStep.Size = new System.Drawing.Size(117, 20);
			this.txtStep.TabIndex = 13;
			this.txtStep.Validating += new System.ComponentModel.CancelEventHandler(this.ValidatingDoube);
			// 
			// lblStep
			// 
			this.lblStep.AutoSize = true;
			this.lblStep.Location = new System.Drawing.Point(189, 100);
			this.lblStep.Name = "lblStep";
			this.lblStep.Size = new System.Drawing.Size(27, 13);
			this.lblStep.TabIndex = 12;
			this.lblStep.Text = "step";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(271, 139);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(190, 139);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 14;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// InputForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(358, 176);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtStep);
			this.Controls.Add(this.lblStep);
			this.Controls.Add(this.txtXMax);
			this.Controls.Add(this.lblXMax);
			this.Controls.Add(this.txtXMin);
			this.Controls.Add(this.lbXMin);
			this.Controls.Add(this.txtC);
			this.Controls.Add(this.lblC);
			this.Controls.Add(this.txtB);
			this.Controls.Add(this.lbl_b);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.txtA);
			this.Controls.Add(this.lblA);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Inputs";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblA;
		private System.Windows.Forms.TextBox txtA;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.TextBox txtStep;
		private System.Windows.Forms.Label lblStep;
		private System.Windows.Forms.TextBox txtXMax;
		private System.Windows.Forms.Label lblXMax;
		private System.Windows.Forms.TextBox txtXMin;
		private System.Windows.Forms.Label lbXMin;
		private System.Windows.Forms.TextBox txtC;
		private System.Windows.Forms.Label lblC;
		private System.Windows.Forms.TextBox txtB;
		private System.Windows.Forms.Label lbl_b;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}