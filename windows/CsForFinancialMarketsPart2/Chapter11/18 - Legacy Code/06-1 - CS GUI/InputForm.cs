using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS_GUI
{
	public partial class InputForm: Form
	{
		// Data members
		private double m_a;
		private double m_b;
		private double m_c;
		private double m_xMin;
		private double m_xMax;
		private double m_step;

		/// <summary>
		/// Create an input form with default values for the controls.
		/// </summary>
		/// <param name="a">The a parameter for the quadratic equation.</param>
		/// <param name="b">The b parameter for the quadratic equation.</param>
		/// <param name="c">The c parameter for the quadratic equation.</param>
		/// <param name="xMin">The minimum x-value to calcualte for the quadratic equation.</param>
		/// <param name="xMax">The maximum x-value to calcualte for the quadratic equation.</param>
		/// <param name="step">The x step value.</param>
		public InputForm(double a, double b, double c, double xMin, double xMax, double step)
		{
			InitializeComponent();

			// Copy the input
			m_a=a;
			m_b=b;
			m_c=c;
			m_xMin=xMin;
			m_xMax=xMax;
			m_step=step;

			// Fill the controls
			FillControls();
		}

		/// <summary>
		/// Access the a parameter for the quadratic equation.
		/// </summary>
		public double a
		{
			get { return m_a; }
			set { m_a=value; }
		}

		/// <summary>
		/// Access the b parameter for the quadratic equation.
		/// </summary>
		public double b
		{
			get { return m_b; }
			set { m_b=value; }
		}

		/// <summary>
		/// Access the c parameter for the quadratic equation.
		/// </summary>
		public double c
		{
			get { return m_c; }
			set { m_c=value; }
		}

		/// <summary>
		/// Access the minimum x-value to calculate for the quadratic equation.
		/// </summary>
		public double XMin
		{
			get { return m_xMin; }
			set { m_xMin=value; }
		}

		/// <summary>
		/// Access the maximum x-value to calculate for the quadratic equation.
		/// </summary>
		public double XMax
		{
			get { return m_xMax; }
			set { m_xMax=value; }
		}

		/// <summary>
		/// Access the x step value.
		/// </summary>
		public double Step
		{
			get { return m_step; }
			set { m_step=value; }
		}

		/// <summary>
		/// Return all parameters via out arguments.
		/// </summary>
		/// <param name="a">The a parameter for the quadratic equation.</param>
		/// <param name="b">The b parameter for the quadratic equation.</param>
		/// <param name="c">The c parameter for the quadratic equation.</param>
		/// <param name="xMin">The minimum x-value to calculate for the quadratic equation.</param>
		/// <param name="xMax">The maximum x-value to calculate for the quadratic equation.</param>
		/// <param name="step">The x step value.</param>
		public void GetParameters(out double a, out double b, out double c, out double xMin, out double xMax, out double step)
		{
			a=m_a;
			b=m_b;
			c=m_c;
			xMin=m_xMin;
			xMax=m_xMax;
			step=m_step;
		}

		/// <summary>
		/// Fill the controls with the quadratic equation values.
		/// </summary>
		private void FillControls()
		{
			// Fill the controls with the data member values
			txtA.Text=String.Format("{0:f4}", m_a);
			txtB.Text=String.Format("{0:f4}", m_b);
			txtC.Text=String.Format("{0:f4}", m_c);
			txtXMin.Text=String.Format("{0:f4}", m_xMin);
			txtXMax.Text=String.Format("{0:f4}", m_xMax);
			txtStep.Text=String.Format("{0:f4}", m_step);
		}

		/// <summary>
		/// Accept the values from the controls.
		/// </summary>
		private void AcceptControls()
		{
			// Copy control values to data members
			m_a=Double.Parse(txtA.Text);
			m_b=Double.Parse(txtB.Text);
			m_c=Double.Parse(txtC.Text);
			m_xMin=Double.Parse(txtXMin.Text);
			m_xMax=Double.Parse(txtXMax.Text);
			m_step=Double.Parse(txtStep.Text);
		}

		/// <summary>
		/// OK button was pressed.
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