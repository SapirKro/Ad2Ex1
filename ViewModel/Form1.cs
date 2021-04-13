using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace BEH_LAST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            OxyPlot.WindowsForms.PlotView pv = new PlotView();
            pv.Location = new Point(0, 0);
            pv.Size = new Size(500, 500);
            this.Controls.Add(pv);

            pv.Model = new PlotModel { Title="title" };
            FunctionSeries fs = new FunctionSeries();
            fs.Points.Add(new DataPoint(0, 0));
            fs.Points.Add(new DataPoint(5, 2));
            fs.Points.Add(new DataPoint(7, 1));
            fs.Title = "Plot";
            pv.Model.Series.Add(fs);

            pv.Model.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.2, "sin(x)"));
            pv.Model.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.2, "cos(x)"));

        }
    }
}