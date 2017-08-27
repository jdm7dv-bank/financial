using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CsGUI
{
	public enum OptionType
	{
		Put=0,
		Call=1,
	}

	public partial class InputForm: Form
	{
		private double m_r;							// Interest rate
		private double m_sig;						// Volatility
		private double m_K;							// Strike price
		private double m_T;							// Expiry date
		private double m_U;							// Current underlying price (e.g. stock, forward)
		private double m_b;							// Cost of carry
		private OptionType m_optionType;			// The option type
		private bool m_outputToExcel=false;			// Output to Excel?
		private double m_percentageMovement=0.2;	// The percentage movement for the elasticity

		/// <summary>
		/// Helper class fro showing option types.
		/// </summary>
		private class OptionTypeData
		{
			// Public data members for simplicity
			public string Description;
			public OptionType OptionType;

			// Constructor with description and option type
			public OptionTypeData(string Description, OptionType OptionType)
			{
				this.Description=Description;
				this.OptionType=OptionType;
			}

			// The string representation of this type
			public override string ToString()
			{
				return Description;
			}
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public InputForm(double r, double sig, double K, double T, double U, double b, OptionType optionType)
		{
			InitializeComponent();

			// Set the read me text
			rtfAbout.Rtf=Resources.Read_me;

			// Initialise the parameters
			m_r=r;
			m_sig=sig;
			m_K=K;
			m_T=T;
			m_U=U;
			m_b=b;
			m_optionType=optionType;

			// Fill the option type box
			cb_otyp.Items.Add(new OptionTypeData("Call Option", OptionType.Call));
			cb_otyp.Items.Add(new OptionTypeData("Put Option", OptionType.Put));

			// Fill the controls
			FillControls();
		}

		/// <summary>
		/// Access the interest rate.
		/// </summary>
		public double r
		{
			get { return m_r; }
			set { m_r=value; }
		}

		/// <summary>
		/// Access the volatility.
		/// </summary>
		public double sig
		{
			get { return m_sig; }
			set { m_sig=value; }
		}

		/// <summary>
		/// Access the strike price.
		/// </summary>
		public double K
		{
			get { return m_K; }
			set { m_K=value; }
		}

		/// <summary>
		/// Access the expiry date.
		/// </summary>
		public double T
		{
			get { return m_T; }
			set { m_T=value; }
		}

		/// <summary>
		/// Access the current underlying price (e.g. stock, forward)
		/// </summary>
		public double U
		{
			get { return m_U; }
			set { m_U=value; }
		}

		/// <summary>
		/// Access the cost of carry.
		/// </summary>
		public double b
		{
			get { return m_b; }
			set { m_b=value; }
		}

		/// <summary>
		/// Access the option type.
		/// </summary>
		public OptionType OptionType
		{
			get { return m_optionType; }
			set { m_optionType=value; }
		}

		/// <summary>
		/// Access the output to Excel status.
		/// </summary>
		public bool OutputToExcel
		{
			get { return m_outputToExcel; }
			set { m_outputToExcel=value; }
		}

		/// <summary>
		/// Access the percentage movement for elasticity.
		/// </summary>
		public double PercentageMovement
		{
			get { return m_percentageMovement; }
			set { m_percentageMovement=value; }
		}

		/// <summary>
		/// Fill the controls with the option value members.
		/// </summary>
		private void FillControls()
		{
			// Set the option values
			txt_r.Text=String.Format("{0:f4}", m_r);
			txt_sig.Text=String.Format("{0:f4}", m_sig);
			txt_K.Text=String.Format("{0:f4}", m_K);
			txt_T.Text=String.Format("{0:f4}", m_T);
			txt_U.Text=String.Format("{0:f4}", m_U);
			txt_b.Text=String.Format("{0:f4}", m_b);

			// Select the option type
			foreach (OptionTypeData opd in cb_otyp.Items)
			{
				if (opd.OptionType==m_optionType) cb_otyp.SelectedItem=opd;
			}

			// Output to Excel status
			chkOutputToExcel.Checked=m_outputToExcel;

			// Percentage movement
			txt_percentageMovement.Text=String.Format("{0:f4}", m_percentageMovement);
		}

		/// <summary>
		/// Accept the values from the controls in the option.
		/// </summary>
		private void AcceptControls()
		{
			// Control to option values
			m_r=Double.Parse(txt_r.Text);
			m_sig=Double.Parse(txt_sig.Text);
			m_K=Double.Parse(txt_K.Text);
			m_T=Double.Parse(txt_T.Text);
			m_U=Double.Parse(txt_U.Text);
			m_b=Double.Parse(txt_b.Text);

			// Set the option type
			m_optionType=(cb_otyp.SelectedItem as OptionTypeData).OptionType;

			// Output to Excel status
			m_outputToExcel=chkOutputToExcel.Checked;

			// Percentage movement
			m_percentageMovement=Double.Parse(txt_percentageMovement.Text);
		}

		/// <summary>
		/// OK button pressed.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		private void btnOK_Click(object sender, EventArgs e)
		{
			AcceptControls();
		}

		/// <summary>
		/// Validate a control for double contents.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event arguments.</param>
		private void ValidatingDoube(object sender, CancelEventArgs e)
		{
			double val;

			// First clear the last error
			errorProvider.SetError(sender as Control, "");

			// Try to parse the double
			if (Double.TryParse((sender as TextBox).Text, out val)==false)
			{
				errorProvider.SetError(sender as Control, "Value must be a double");
				e.Cancel=true;
			}
		}


	}
}
