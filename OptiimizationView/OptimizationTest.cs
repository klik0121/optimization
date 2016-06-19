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
using nzy3D.Chart;
using nzy3D.Chart.Controllers.Thread.Camera;
using nzy3D.Colors;
using nzy3D.Colors.ColorMaps;
using nzy3D.Maths;
using nzy3D.Plot3D.Builder;
using nzy3D.Plot3D.Builder.Concrete;
using nzy3D.Plot3D.Primitives;
using nzy3D.Plot3D.Primitives.Axes.Layout;
using nzy3D.Plot3D.Rendering.Canvas;
using nzy3D.Plot3D.Rendering.View;
using System.IO;
using OpenTK.Graphics;

namespace OptimizationView
{
    public partial class OptimizationTest : Form
    {
        protected Controller controller;
        protected Dictionary<string, OneDimensionalMethod> methodNames;
        protected Dictionary<string, NDimensinalMethod> nMethodNames;
        protected Dictionary<OneDimensionalMethod, System.Drawing.Color> methodColors;
        protected Dictionary<NDimensinalMethod, System.Drawing.Color> nMethodColors;

        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }
        public OptimizationTest()
        {
            InitializeComponent();
            CreateGraphic();
            CreateNames();
            CreateColors();
        }
        private void CreateColors()
        {
            CreateMethodList();
            methodColors = new Dictionary<OneDimensionalMethod, System.Drawing.Color>();
            methodColors.Add(OneDimensionalMethod.BisectionMethod, System.Drawing.Color.Red);
            methodColors.Add(OneDimensionalMethod.ChordMethod, System.Drawing.Color.Green);
            methodColors.Add(OneDimensionalMethod.CubicApproximation, System.Drawing.Color.Blue);
            methodColors.Add(OneDimensionalMethod.FibonacciNumbersMethod, System.Drawing.Color.Brown);
            methodColors.Add(OneDimensionalMethod.GoldenSectionMethod, System.Drawing.Color.Gold);
            methodColors.Add(OneDimensionalMethod.MidPointMethod, System.Drawing.Color.Black);
            methodColors.Add(OneDimensionalMethod.QuadraticApproximation, System.Drawing.Color.PaleVioletRed);
            methodColors.Add(OneDimensionalMethod.TangentsMethod, System.Drawing.Color.Purple);
            methodColors.Add(OneDimensionalMethod.QuadraticFunction, System.Drawing.Color.DarkRed);

            nMethodColors = new Dictionary<NDimensinalMethod, System.Drawing.Color>();
            nMethodColors.Add(NDimensinalMethod.CoordinateDescent, System.Drawing.Color.Red);
            nMethodColors.Add(NDimensinalMethod.HookJeeves, System.Drawing.Color.Green);
            nMethodColors.Add(NDimensinalMethod.NelderMead, System.Drawing.Color.Blue);
        }
        private void CreateGraphic()
        {
            chartFunction.ChartAreas[0].AxisX.Interval = 1;
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
            chartTest.ChartAreas[0].AxisY.Title = "кол-во\nвычислений f(x)";
            chartTest.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;
            chartTest.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
            chartTest.ChartAreas[0].AxisY.Interval = 10;

            chartNTest.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartNTest.ChartAreas[0].AxisX.MinorTickMark.Interval = 0.001;
            chartNTest.ChartAreas[0].AxisX.Title = "eps";
            chartNTest.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;
            chartNTest.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            chartNTest.ChartAreas[0].AxisY.Title = "кол-во\nвычислений f(x)";
            chartNTest.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;
            chartNTest.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
            chartNTest.ChartAreas[0].AxisY.Interval = 50;
        }
        private void CreateMethodList()
        {
            foreach (var pair in methodNames)
                listBoxMethod.Items.Add(pair.Key);
            foreach (var pair in nMethodNames)
                listBoxNMethod.Items.Add(pair.Key);
        }
        private void CreateNames()
        {
            methodNames = new Dictionary<string, OneDimensionalMethod>();
            methodNames.Add("Метод половинного деления", OneDimensionalMethod.BisectionMethod);
            methodNames.Add("Метод хорд", OneDimensionalMethod.ChordMethod);
            methodNames.Add("Метод кубической аппрокисмации", OneDimensionalMethod.CubicApproximation);
            methodNames.Add("Метод чисел Фиббоначчи", OneDimensionalMethod.FibonacciNumbersMethod);
            methodNames.Add("Метод золотого сечения", OneDimensionalMethod.GoldenSectionMethod);
            methodNames.Add("Метод средней точки", OneDimensionalMethod.MidPointMethod);
            methodNames.Add("Метод квадратической аппроксимации",
                OneDimensionalMethod.QuadraticApproximation);
            methodNames.Add("Метод касательных", OneDimensionalMethod.TangentsMethod);
            methodNames.Add("Квадратичные функции", OneDimensionalMethod.QuadraticFunction);

            nMethodNames = new Dictionary<string, NDimensinalMethod>();
            nMethodNames.Add("Покординатный спуск", NDimensinalMethod.CoordinateDescent);
            nMethodNames.Add("Метод Хука-Дживса", NDimensinalMethod.HookJeeves);
            nMethodNames.Add("Метод Нелдера-Мида", NDimensinalMethod.NelderMead);
        }
        private void buttonBuildChart_Click(object sender, EventArgs e)
        {
            try
            {
                chartFunction.Series.Clear();
                chartFunction.Series.Add("f(x)");
                chartFunction.Series[0].Color = System.Drawing.Color.Blue;
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
                using (FileStream fs = File.Open(textBoxF.Text.Replace("*", "⋅") + ".tiff", FileMode.OpenOrCreate))
                {
                    chartFunction.SaveImage(fs, ChartImageFormat.Tiff);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("При построении графика возникла ошибка. Попробуйте изменить функцию или начальное значение.");
            }

        }
        private Series GetSeries(OneDimensionalMethod method)
        {
            Series series = new Series();
            foreach (var pair in methodNames)
                if (pair.Value == method) series.Name = pair.Key;
            series.Color = methodColors[method];
            series.ChartType = SeriesChartType.Line;
            series.IsXValueIndexed = true;
            series.BorderWidth = 2;
            return series;
        }
        private Series GetSeries(NDimensinalMethod method)
        {
            Series series = new Series();
            foreach (var pair in nMethodNames)
                if (pair.Value == method) series.Name = pair.Key;
            series.Color = nMethodColors[method];
            series.ChartType = SeriesChartType.Line;
            series.IsXValueIndexed = true;
            series.BorderWidth = 2;
            return series;
        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                minTable.Rows.Clear();
                chartTest.Series.Clear();
                OneDimensionalMethod method = (OneDimensionalMethod)0;
                int i = 0;
                double x0 = double.Parse(textBoxX0.Text);
                string function = textBoxF.Text.Replace(" ", "");
                foreach(var item in listBoxMethod.CheckedItems)
                {
                    foreach(var pair in methodNames)
                    {
                        if(item.ToString() == pair.Key)
                        {
                            method |= pair.Value;
                            Series series = GetSeries(pair.Value);
                            minTable.Rows.Add();
                            minTable.Rows[i].Cells[0].Value = pair.Key.ToString();
                            minTable.Rows[i].Cells[1].Value = controller.GetMin(function, pair.Value, x0);
                            foreach(var point in controller.TestMethod(function, pair.Value))
                            {
                                series.Points.Add(new DataPoint(point.Key, point.Value));
                            }
                            chartTest.Series.Add(series);
                            i++;
                            break;                            
                        }
                    }
                }
                chartTest.Update();
                string name = method.ToString();
                function = function.Replace("*", "⋅");
                using(FileStream fs = File.Open(string.Format("{0} {1}.tiff", function, method.ToString()),
                     FileMode.Create))
                {
                    chartTest.SaveImage(fs, ChartImageFormat.Tiff);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("При построении графиков возникла ошибка. Попробуйте изменить функцию или начальное значение.");
            }
        }
        private void btnCreateGraphics_Click(object sender, EventArgs e)
        {
            try
            {
                string function = textBoxFXX.Text;
                string x0 = textBoxXX0.Text;
                string[] splitted = x0.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                double[] x = new double[splitted.Length];
                for(int i = 0; i < splitted.Length; i++)
                {
                    x[i] = double.Parse(splitted[i]);
                }
                //without contoller
                DynamicMapper mapper = new DynamicMapper(function);
                int steps = 30; //amount of steps at each axis
                Shape surface = Builder.buildOrthonomal(new OrthonormalGrid(new Range(x[0] - 100, x[0] + 100), steps,
                    new Range(x[1] - 100, x[1] + 100), steps), mapper);
                surface.ColorMapper = new ColorMapper(new ColorMapRainbow(), surface.Bounds.zmin, surface.Bounds.zmax, new nzy3D.Colors.Color(1, 1, 1, 0.8));
                surface.FaceDisplayed = true;
                //surface.WireframeDisplayed = true;
                //surface.WireframeColor = nzy3D.Colors.Color.CYAN;
                //surface.WireframeColor.mul(new nzy3D.Colors.Color(1, 1, 1, 0.5));
                nzy3D.Chart.Chart chart = new nzy3D.Chart.Chart(renderer3D, Quality.Nicest);
                chart.Scene.Graph.Add(surface);
                renderer3D.setView(chart.View);
                renderer3D.Invalidate();
                renderer3D.Update();
                renderer3D.Refresh();
                Bitmap bm = CreateImage();
                
                using(FileStream fs = File.Open(function.Replace("*", "⋅") + ".tiff", FileMode.OpenOrCreate))
                {
                    bm.Save(fs, System.Drawing.Imaging.ImageFormat.Tiff);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("При построении графика возникла ошибка. Попробуйте изменить функцию или начальное значение.");
            }
        }
        private void btnTestN_Click(object sender, EventArgs e)
        {
            try
            {
                minNTable.Rows.Clear();
                chartNTest.Series.Clear();
                chartNTest.ChartAreas[0].AxisY.Maximum = double.NaN;
                if (rbFunc.Checked) chartNTest.ChartAreas[0].AxisY.Title = "кол-во\nвычислений f(x)";
                else chartNTest.ChartAreas[0].AxisY.Title = "кол-во\nитераций";
                NDimensinalMethod method = (NDimensinalMethod)0;
                int i = 0;
                string x0 = textBoxXX0.Text;
                string[] splitted = x0.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                double[] x = new double[splitted.Length];
                for (int j = 0; j < splitted.Length; j++)
                {
                    x[j] = double.Parse(splitted[j]);
                }
                string function = textBoxFXX.Text;
                foreach (var item in listBoxNMethod.CheckedItems)
                {
                    foreach (var pair in nMethodNames)
                    {
                        if (item.ToString() == pair.Key)
                        {
                            method |= pair.Value;
                            Series series = GetSeries(pair.Value);
                            minNTable.Rows.Add();
                            minNTable.Rows[i].Cells[0].Value = pair.Key.ToString();
                            minNTable.Rows[i].Cells[1].Value = controller.GetMin(function, pair.Value, x);
                            List<KeyValuePair<double, double>> collection;
                            if (rbFunc.Checked) collection = controller.TestMethodFunc(function, pair.Value, x);
                            else collection = controller.TestMethodIter(function, pair.Value, x);
                            foreach (var point in collection)
                            {
                                series.Points.Add(new DataPoint(point.Key, point.Value));
                            }
                            chartNTest.Series.Add(series);
                            i++;
                            break;
                        }
                    }
                }
                chartNTest.ChartAreas[0].RecalculateAxesScale();
                int yMax = (int)chartNTest.ChartAreas[0].AxisY.Maximum;
                if (yMax > 1000) chartNTest.ChartAreas[0].AxisY.Interval = 1000;
                else if (yMax > 500) chartNTest.ChartAreas[0].AxisY.Interval = 500;
                else if (yMax > 100) chartNTest.ChartAreas[0].AxisY.Interval = 100;
                else if (yMax > 50) chartNTest.ChartAreas[0].AxisY.Interval = 50;
                else if (yMax > 10) chartNTest.ChartAreas[0].AxisY.Interval = 10;
                chartNTest.Update();
                function = function.Replace("*", "⋅");
                string name = rbFunc.Checked ? function.ToString() + " (func)" : function.ToString() + " (iter)";              
                using (FileStream fs = File.Open(string.Format("{0} {1}.tiff", name, method.ToString()),
                     FileMode.Create))
                {
                    chartNTest.SaveImage(fs, ChartImageFormat.Tiff);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("При построении графика возникла ошибка. Попробуйте изменить функцию или начальное значение.");
            }
        }
        private Bitmap CreateImage()
        {
            if (GraphicsContext.CurrentContext == null)
                throw new GraphicsContextMissingException();

            Bitmap bmp = new Bitmap(renderer3D.ClientSize.Width, renderer3D.ClientSize.Height);
            System.Drawing.Imaging.BitmapData data =
                bmp.LockBits(renderer3D.ClientRectangle, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            GL.ReadPixels(0, 0, renderer3D.Width, renderer3D.Height,
                OpenTK.Graphics.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bmp;
        }
    }
}
