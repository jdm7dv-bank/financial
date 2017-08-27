using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CsGUI
{
	public partial class ResultsForm: Form
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ResultsForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Add a chart to the form.
		/// </summary>
		/// <param name="xValues">The x-values for the chart.</param>
		/// <param name="yValues">The y-values for the chart.</param>
		/// <param name="chartName">The name of the chart.</param>
		/// <param name="xName">The name of the x column.</param>
		/// <param name="yName">The name of the y-column.</param>
		public void AddChart(IEnumerable<double> xValues, IEnumerable<double> yValues, string chartName, string xName, string yName)
		{
			// Add a tab page
			TabPage page=new TabPage(chartName);
			tabControl.TabPages.Add(page);

			// Add a splitter container
			SplitContainer sc=new SplitContainer();
			sc.Dock=DockStyle.Fill;
			sc.FixedPanel=FixedPanel.Panel1;

			// Add the grid to the spit container
			sc.Panel1.Controls.Add(CreateGrid(xValues, yValues, xName, yName));

			// Add the chart to the split container
			sc.Panel2.Controls.Add(CreateChart(xValues, yValues, chartName));

			// Add the split container to the page
			page.Controls.Add(sc);
			sc.SplitterDistance=300;

		}

		/// <summary>
		/// Create a grid.
		/// </summary>
		/// <param name="xValues">The x-values for the grid.</param>
		/// <param name="yValues">The y-values for the gris.</param>
		/// <param name="xName">The name of the x column.</param>
		/// <param name="yName">The name of the y-column.</param>
		/// <returns>The created chart.</returns>
		private DataGridView CreateGrid(IEnumerable<double> xValues, IEnumerable<double> yValues, string xName, string yName)
		{
			// Create grid
			DataGridView grid=new DataGridView();
			grid.Dock=DockStyle.Fill;
			grid.ReadOnly=true;
			grid.RowHeadersVisible=false;
			grid.AllowUserToAddRows=false;
			grid.AllowUserToDeleteRows=false;
			grid.AllowUserToOrderColumns=false;
			grid.AllowUserToResizeColumns=false;
			grid.AllowUserToResizeRows=false;
			grid.SelectionMode=DataGridViewSelectionMode.FullRowSelect;

			// Create the columns
			grid.Columns.Add("c1", xName);
			grid.Columns.Add("c2", yName);
			grid.Columns[0].AutoSizeMode=DataGridViewAutoSizeColumnMode.ColumnHeader;
			grid.Columns[1].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
			grid.Columns[1].DefaultCellStyle.Format="F4";

			// Create rows
			IEnumerator<double> e1=xValues.GetEnumerator();
			IEnumerator<double> e2=yValues.GetEnumerator();

			// Add the rows
			while (e2.MoveNext())
			{
				e1.MoveNext();
				grid.Rows.Add(e1.Current, e2.Current);
			}

			// Return the created grid
			return grid;
		}

		/// <summary>
		/// Create a chart.
		/// </summary>
		/// <param name="xValues">The x-values for the chart.</param>
		/// <param name="yValues">The y-values for the chart.</param>
		/// <param name="chartName">The name of the chart.</param>
		/// <returns>The created chart.</returns>
		private Chart CreateChart(IEnumerable<double> xValues, IEnumerable<double> yValues, string chartName)
		{
			// Create a chart
			Chart chart=new Chart();
			chart.Dock=DockStyle.Fill;
			chart.BackColor=Color.AliceBlue;
			chart.BackSecondaryColor=Color.LightSkyBlue;
			chart.BackGradientStyle=GradientStyle.TopBottom;

			// Create a chart area
			ChartArea chartArea=chart.ChartAreas.Add(chartName);
			chartArea.BackColor=Color.AntiqueWhite;
			chartArea.BackSecondaryColor=Color.Moccasin;
			chartArea.BackGradientStyle=GradientStyle.TopBottom;
			chartArea.CursorX.IsUserSelectionEnabled=true;
			chartArea.CursorY.IsUserSelectionEnabled=true;

			// Set x-axis
			chartArea.AxisX.IsMarginVisible=false;
			chartArea.AxisX.MinorGrid.Enabled=true;
			chartArea.AxisX.MinorGrid.LineColor=Color.LightGray;

			// Set y-axis (strip line misused to make a thicker zero line)
			chartArea.AxisY.IsMarginVisible=true;
			StripLine sl=new StripLine();
			sl.BorderColor=Color.Black;
			sl.BorderWidth=2;
			chartArea.AxisY.StripLines.Add(sl);
			chartArea.AxisY.MinorGrid.Enabled=true;
			chartArea.AxisY.MinorGrid.LineColor=Color.LightGray;

			// Create a data series and asign it to the chart area
			Series series=chart.Series.Add(chartName);
			series.ChartType=SeriesChartType.Line;
			series.Points.DataBindXY(xValues, yValues);
			series.ChartArea=chartName;
			series.BorderWidth=2;
			series.Color=Color.Red;

			// Create title
			Title title=chart.Titles.Add(chartName);
			title.DockedToChartArea=chartName;
			title.IsDockedInsideChartArea=false;
			title.Font=new Font("Arial", 20, FontStyle.Bold);

			// Return the chart
			return chart;
		}
	}
}
