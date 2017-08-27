using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS_GUI
{
	public partial class ResultsForm: Form
	{
		private PointF[] m_points;

		public ResultsForm(double a, double b, double c, IEnumerable<double> xValues, IEnumerable<double> yValues)
		{
			InitializeComponent();
			
			// Fill the formula
			lblFormula.Text=String.Format(lblFormula.Text, a, b, c);

			// Fill the grid
			IEnumerator<double> e1=xValues.GetEnumerator();
			IEnumerator<double> e2=yValues.GetEnumerator();

			// Add the rows
			int count=0;
			while (e1.MoveNext())
			{
				e2.MoveNext();
				grid.Rows.Add(e1.Current, e2.Current);
				count++;
			}

			// Turn the x- and y-values in an array of PointF
			e1.Reset(); e2.Reset();
			m_points=new PointF[count];
			int i=0;
			while (e1.MoveNext())
			{
				e2.MoveNext();
				m_points[i++]=new PointF((float)e1.Current, (float)e2.Current);
			}
		}

		/// <summary>
		/// Draw the panel.
		/// </summary>
		/// <param name="sender">The sender of the events.</param>
		/// <param name="e">The event arguments.</param>
		private void graphPanel_Paint(object sender, PaintEventArgs e)
		{
			Pen pen;
			float tickSize=0.3f;
			float thickOffset;

			Graphics g=e.Graphics;
			g.TranslateTransform(graphPanel.Width*0.5f, graphPanel.Height*0.5f);
			g.ScaleTransform(10.0f, -10.0f);

			pen=new Pen(Color.LightGray, 0.0f);

			// Draw x-axis
			g.DrawLine(pen, -graphPanel.Height*5f, 0.0f, graphPanel.Height*5f, 0.0f);
			thickOffset=0;
			while (thickOffset<graphPanel.Width*5f)
			{
				// Draw ticks
				g.DrawLine(pen, thickOffset, tickSize, thickOffset, -tickSize);
				g.DrawLine(pen, -thickOffset, tickSize, -thickOffset, -tickSize);
				thickOffset+=1.0f;
			}

			// Draw y-axis
			g.DrawLine(pen, 0.0f, -graphPanel.Width*5f, 0.0f, graphPanel.Width*5f);
			thickOffset=0;
			while (thickOffset<graphPanel.Height*5f)
			{
				// Draw ticks
				g.DrawLine(pen, -tickSize, thickOffset, tickSize, thickOffset);
				g.DrawLine(pen, -tickSize, -thickOffset, tickSize, -thickOffset);
				thickOffset+=1.0f;
			}

			// Draw graph
			pen=new Pen(Color.Blue, 0.0f);
			e.Graphics.DrawLines(pen, m_points);
		}

		/// <summary>
		/// The panel was resized.
		/// </summary>
		/// <param name="sender">The sender of the event.</param>
		/// <param name="e">The event parameters.</param>
		private void graphPanel_Resize(object sender, EventArgs e)
		{
			// Ensure the panel is redrawn
			graphPanel.Refresh();
		}
	}
}