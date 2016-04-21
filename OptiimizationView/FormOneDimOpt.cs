using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace OptimizationView
{
    public partial class FormOneDimOpt : Form
    {
        protected Controller controller;
        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }
        public FormOneDimOpt()
        {
            InitializeComponent();
            chartFunction.ChartAreas[0].AxisX.Interval = 10;
            chartFunction.ChartAreas[0].AxisX.Title = "x";
            chartFunction.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;
            chartFunction.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            chartFunction.ChartAreas[0].AxisY.Title = "f(x)";
            chartFunction.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;
            chartFunction.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
            chartFunction.Update();
            chartTest.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartTest.ChartAreas[0].AxisX.MinorTickMark.Interval = 0.001;
            chartTest.ChartAreas[0].AxisX.Title = "eps";
            chartTest.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;
            chartTest.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            chartTest.ChartAreas[0].AxisY.Title = "кол-во вычислений f(x)";
            chartTest.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;
            chartTest.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
            chartTest.ChartAreas[0].AxisY.Interval = 10;
        }

        private void buttonBuildChart_Click(object sender, EventArgs e)
        {
            try
            {
                chartFunction.Series.Clear();
                chartFunction.Series.Add("f(x)");
                chartFunction.Series[0].Color = Color.Black;
                chartFunction.Series[0].BorderWidth = 2;
                chartFunction.Series[0].ChartType = SeriesChartType.Line;
                chartFunction.Series[0].XValueType = ChartValueType.Int32;
                foreach (KeyValuePair<double, double> pair in
                    controller.EvaluateFunction(textBoxF.Text.Replace(" ", ""), 
                        double.Parse(textBoxX0.Text))) 
                {
                    chartFunction.Series[0].Points.Add(new DataPoint(pair.Key, pair.Value));
                }
                chartFunction.Update();
            }
            catch(Exception)
            {
                MessageBox.Show("При построении графика возникла ошибка. Попробуйте изменить функцию или начальное значение.");
            }
            using (FileStream fs = File.Open(textBoxF.Text.Replace("*", "⋅") + ".tiff", FileMode.OpenOrCreate))
            {
                chartFunction.SaveImage(fs, ChartImageFormat.Tiff);
            }
        }
        private Series GetSeries(OneDimensionalMethod method)
        {
            Series series = new Series();
            if (method == OneDimensionalMethod.BisectionMethod)
            {
                series.Name = "Половинное деление";
                series.Color = Color.Black;
                series.BorderDashStyle = ChartDashStyle.Dash;
                series.BorderWidth = 2;
            }
            else if (method == OneDimensionalMethod.GoldenSectionMethod)
            {
                series.Name = "Золотое сечение";
                series.Color = Color.Black;
                series.BorderWidth = 2;
            }
            else if (method == OneDimensionalMethod.FibonacciNumbersMethod)
            {
                series.Name = "Метод Фибоначчи";
                series.Color = Color.Black;
                series.BorderDashStyle = ChartDashStyle.Dot;
                series.BorderWidth = 2;
            }
            foreach (KeyValuePair<double, double> pair in
                controller.TestMethod(textBoxF.Text.Replace(" ", ""), method))
            {
                series.Points.Add(new DataPoint(pair.Key, pair.Value));
            }
            series.ChartType = SeriesChartType.Line;
            series.IsXValueIndexed = true;
            return series;
        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            textBoxMinBis.Text = string.Empty;
            textBoxMinFib.Text = string.Empty;
            textBoxMinGold.Text = string.Empty;
            try
            {
                double x0 = double.Parse(textBoxX0.Text);
                chartTest.Series.Clear();
                textBoxMinBis.Text = controller.GetMin(textBoxF.Text.Replace(" ", ""),
                    OneDimensionalMethod.FibonacciNumbersMethod, 0).ToString();
                if (checkBox1.Checked)
                {
                    chartTest.Series.Add(GetSeries(OneDimensionalMethod.BisectionMethod));
                    textBoxMinGold.Text = controller.GetMin(textBoxF.Text.Replace(" ", ""),
                        OneDimensionalMethod.BisectionMethod, x0).ToString();
                }
                if (checkBox2.Checked)
                {
                    chartTest.Series.Add(GetSeries(OneDimensionalMethod.GoldenSectionMethod));
                    textBoxMinFib.Text = controller.GetMin(textBoxF.Text.Replace(" ", ""),
                         OneDimensionalMethod.GoldenSectionMethod, x0).ToString();
                }
                if (checkBox3.Checked)
                {
                    chartTest.Series.Add(GetSeries(OneDimensionalMethod.FibonacciNumbersMethod));
                    textBoxMinBis.Text = controller.GetMin(textBoxF.Text.Replace(" ", ""),
                        OneDimensionalMethod.FibonacciNumbersMethod, x0).ToString();
                }

            }
            catch(Exception)
            {
                MessageBox.Show("При построении графиков возникла ошибка. Попробуйте изменить функцию или начальное значение.");
            }
            OneDimensionalMethod methods = (OneDimensionalMethod)0;
              if (checkBox1.Checked) methods |= OneDimensionalMethod.BisectionMethod;
                if (checkBox2.Checked) methods |= OneDimensionalMethod.GoldenSectionMethod;
                if (checkBox3.Checked) methods |= OneDimensionalMethod.FibonacciNumbersMethod;
                using (FileStream fs = File.Open(textBoxF.Text.Replace("*", "⋅") + " " + methods.ToString()
                    + ".tiff", FileMode.OpenOrCreate))
                {
                    chartTest.SaveImage(fs, ChartImageFormat.Tiff);
                }
        }
    }
}
