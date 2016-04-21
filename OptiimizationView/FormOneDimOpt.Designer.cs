namespace OptimizationView
{
    partial class FormOneDimOpt
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.textBoxMinBis = new System.Windows.Forms.TextBox();
            this.labelMinBis = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.groupBoxMethods = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.buttonBuildChart = new System.Windows.Forms.Button();
            this.textBoxF = new System.Windows.Forms.TextBox();
            this.labelF = new System.Windows.Forms.Label();
            this.groupBoxChars = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartFunction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTest = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelX0 = new System.Windows.Forms.Label();
            this.textBoxX0 = new System.Windows.Forms.TextBox();
            this.labelGold = new System.Windows.Forms.Label();
            this.labelMinFib = new System.Windows.Forms.Label();
            this.textBoxMinGold = new System.Windows.Forms.TextBox();
            this.textBoxMinFib = new System.Windows.Forms.TextBox();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxMethods.SuspendLayout();
            this.groupBoxChars.SuspendLayout();
            this.tableLayoutPanelCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxInput.Controls.Add(this.textBoxMinFib);
            this.groupBoxInput.Controls.Add(this.textBoxMinGold);
            this.groupBoxInput.Controls.Add(this.labelMinFib);
            this.groupBoxInput.Controls.Add(this.labelGold);
            this.groupBoxInput.Controls.Add(this.textBoxX0);
            this.groupBoxInput.Controls.Add(this.labelX0);
            this.groupBoxInput.Controls.Add(this.textBoxMinBis);
            this.groupBoxInput.Controls.Add(this.labelMinBis);
            this.groupBoxInput.Controls.Add(this.buttonTest);
            this.groupBoxInput.Controls.Add(this.groupBoxMethods);
            this.groupBoxInput.Controls.Add(this.buttonBuildChart);
            this.groupBoxInput.Controls.Add(this.textBoxF);
            this.groupBoxInput.Controls.Add(this.labelF);
            this.groupBoxInput.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxInput.Location = new System.Drawing.Point(12, 5);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(238, 440);
            this.groupBoxInput.TabIndex = 0;
            this.groupBoxInput.TabStop = false;
            // 
            // textBoxMinBis
            // 
            this.textBoxMinBis.Location = new System.Drawing.Point(148, 321);
            this.textBoxMinBis.Name = "textBoxMinBis";
            this.textBoxMinBis.Size = new System.Drawing.Size(81, 26);
            this.textBoxMinBis.TabIndex = 9;
            // 
            // labelMinBis
            // 
            this.labelMinBis.AutoSize = true;
            this.labelMinBis.Location = new System.Drawing.Point(12, 324);
            this.labelMinBis.Name = "labelMinBis";
            this.labelMinBis.Size = new System.Drawing.Size(130, 19);
            this.labelMinBis.TabIndex = 8;
            this.labelMinBis.Text = "Деление пополам";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(32, 270);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(180, 40);
            this.buttonTest.TabIndex = 7;
            this.buttonTest.Text = "Тест";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // groupBoxMethods
            // 
            this.groupBoxMethods.Controls.Add(this.checkBox1);
            this.groupBoxMethods.Controls.Add(this.checkBox2);
            this.groupBoxMethods.Controls.Add(this.checkBox3);
            this.groupBoxMethods.Location = new System.Drawing.Point(10, 128);
            this.groupBoxMethods.Name = "groupBoxMethods";
            this.groupBoxMethods.Size = new System.Drawing.Size(222, 121);
            this.groupBoxMethods.TabIndex = 6;
            this.groupBoxMethods.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(172, 23);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Половинное деление";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 54);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(140, 23);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Золотое сечение";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 83);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(106, 23);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Фибоначчи";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // buttonBuildChart
            // 
            this.buttonBuildChart.Location = new System.Drawing.Point(32, 82);
            this.buttonBuildChart.Name = "buttonBuildChart";
            this.buttonBuildChart.Size = new System.Drawing.Size(180, 40);
            this.buttonBuildChart.TabIndex = 5;
            this.buttonBuildChart.Text = "Построить график";
            this.buttonBuildChart.UseVisualStyleBackColor = true;
            this.buttonBuildChart.Click += new System.EventHandler(this.buttonBuildChart_Click);
            // 
            // textBoxF
            // 
            this.textBoxF.Location = new System.Drawing.Point(59, 16);
            this.textBoxF.Name = "textBoxF";
            this.textBoxF.Size = new System.Drawing.Size(161, 26);
            this.textBoxF.TabIndex = 1;
            // 
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Location = new System.Drawing.Point(6, 19);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(47, 19);
            this.labelF.TabIndex = 0;
            this.labelF.Text = "f(x) = ";
            // 
            // groupBoxChars
            // 
            this.groupBoxChars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxChars.Controls.Add(this.tableLayoutPanelCharts);
            this.groupBoxChars.Location = new System.Drawing.Point(265, 5);
            this.groupBoxChars.Name = "groupBoxChars";
            this.groupBoxChars.Size = new System.Drawing.Size(409, 440);
            this.groupBoxChars.TabIndex = 1;
            this.groupBoxChars.TabStop = false;
            // 
            // tableLayoutPanelCharts
            // 
            this.tableLayoutPanelCharts.ColumnCount = 1;
            this.tableLayoutPanelCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Controls.Add(this.chartFunction, 0, 0);
            this.tableLayoutPanelCharts.Controls.Add(this.chartTest, 0, 1);
            this.tableLayoutPanelCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCharts.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelCharts.Name = "tableLayoutPanelCharts";
            this.tableLayoutPanelCharts.RowCount = 2;
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelCharts.Size = new System.Drawing.Size(403, 421);
            this.tableLayoutPanelCharts.TabIndex = 0;
            // 
            // chartFunction
            // 
            chartArea3.Name = "ChartArea1";
            this.chartFunction.ChartAreas.Add(chartArea3);
            this.chartFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartFunction.Legends.Add(legend3);
            this.chartFunction.Location = new System.Drawing.Point(3, 3);
            this.chartFunction.Name = "chartFunction";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartFunction.Series.Add(series3);
            this.chartFunction.Size = new System.Drawing.Size(397, 204);
            this.chartFunction.TabIndex = 0;
            this.chartFunction.Text = "chart1";
            // 
            // chartTest
            // 
            chartArea4.Name = "ChartArea1";
            this.chartTest.ChartAreas.Add(chartArea4);
            this.chartTest.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.chartTest.Legends.Add(legend4);
            this.chartTest.Location = new System.Drawing.Point(3, 213);
            this.chartTest.Name = "chartTest";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartTest.Series.Add(series4);
            this.chartTest.Size = new System.Drawing.Size(397, 205);
            this.chartTest.TabIndex = 1;
            this.chartTest.Text = "chart1";
            // 
            // labelX0
            // 
            this.labelX0.AutoSize = true;
            this.labelX0.Location = new System.Drawing.Point(6, 48);
            this.labelX0.Name = "labelX0";
            this.labelX0.Size = new System.Drawing.Size(45, 19);
            this.labelX0.TabIndex = 10;
            this.labelX0.Text = "x0  = ";
            // 
            // textBoxX0
            // 
            this.textBoxX0.Location = new System.Drawing.Point(59, 45);
            this.textBoxX0.Name = "textBoxX0";
            this.textBoxX0.Size = new System.Drawing.Size(161, 26);
            this.textBoxX0.TabIndex = 11;
            // 
            // labelGold
            // 
            this.labelGold.AutoSize = true;
            this.labelGold.Location = new System.Drawing.Point(12, 361);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(121, 19);
            this.labelGold.TabIndex = 12;
            this.labelGold.Text = "Золотое сечение";
            // 
            // labelMinFib
            // 
            this.labelMinFib.AutoSize = true;
            this.labelMinFib.Location = new System.Drawing.Point(12, 394);
            this.labelMinFib.Name = "labelMinFib";
            this.labelMinFib.Size = new System.Drawing.Size(87, 19);
            this.labelMinFib.TabIndex = 13;
            this.labelMinFib.Text = "Фибоначчи";
            // 
            // textBoxMinGold
            // 
            this.textBoxMinGold.Location = new System.Drawing.Point(148, 359);
            this.textBoxMinGold.Name = "textBoxMinGold";
            this.textBoxMinGold.Size = new System.Drawing.Size(81, 26);
            this.textBoxMinGold.TabIndex = 14;
            // 
            // textBoxMinFib
            // 
            this.textBoxMinFib.Location = new System.Drawing.Point(147, 394);
            this.textBoxMinFib.Name = "textBoxMinFib";
            this.textBoxMinFib.Size = new System.Drawing.Size(82, 26);
            this.textBoxMinFib.TabIndex = 15;
            // 
            // FormOneDimOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 457);
            this.Controls.Add(this.groupBoxChars);
            this.Controls.Add(this.groupBoxInput);
            this.Name = "FormOneDimOpt";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxMethods.ResumeLayout(false);
            this.groupBoxMethods.PerformLayout();
            this.groupBoxChars.ResumeLayout(false);
            this.tableLayoutPanelCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxMethods;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button buttonBuildChart;
        private System.Windows.Forms.TextBox textBoxF;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.Label labelMinBis;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.GroupBox groupBoxChars;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFunction;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTest;
        private System.Windows.Forms.TextBox textBoxMinBis;
        private System.Windows.Forms.Label labelX0;
        private System.Windows.Forms.TextBox textBoxX0;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.Label labelMinFib;
        private System.Windows.Forms.TextBox textBoxMinFib;
        private System.Windows.Forms.TextBox textBoxMinGold;
    }
}