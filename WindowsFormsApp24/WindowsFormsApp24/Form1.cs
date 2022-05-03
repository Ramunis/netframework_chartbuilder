using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp24
{
    public partial class Form1 : Form
    {
        public static Form1 SelfRef
        {
            get; set;
        }
        public Form1()
        {
            {
                SelfRef = this;
            }

            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("Q1");
            comboBox1.Items.Add("Q2");
            comboBox1.Items.Add("Q3");
            comboBox1.Items.Add("Q4");
            comboBox1.Items.Add("Q5");
            comboBox1.Items.Add("Q6");
            comboBox1.Items.Add("Q7");
            comboBox1.Items.Add("Q8");
            comboBox1.Items.Add("Q9");
            comboBox1.Items.Add("Q10");

            comboBox1.SelectedIndex = 0;

            comboBox1.SelectedIndex = 0;

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Add("Point");
            comboBox2.Items.Add("Column");
            comboBox2.Items.Add("StepLine");
            comboBox2.Items.Add("Line");
            comboBox2.Items.Add("Spline");
            comboBox2.Items.Add("Area");
            comboBox2.Items.Add("SplineArea");
            comboBox2.Items.Add("Range");
            comboBox2.Items.Add("SplineRange");

            comboBox2.SelectedIndex = 4;

            openFileDialog1.Filter = "Text file|*.txt";
            openFileDialog2.Filter = "CSV|*.csv";
     
        }
        List<int> x;
        List<int> y;
        int[] a;
        bool flag = false;

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        public void txt(int r1, int r2, int cn,string crnm, int lt)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                chart1.Visible = false;
                chart2.Visible = true;
                chart2.Series[cn].Name = crnm;

                if (lt == 0) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                if (lt == 1) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                if (lt == 2) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                if (lt == 3) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                if (lt == 4) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                if (lt == 5) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                if (lt == 6) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
                if (lt == 7) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
                if (lt == 8) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;

                try
                {
                    //Инициализация массивов
                    x = new List<int>();
                    y = new List<int>();

                    //Чтение файла и запись значений в List x и y
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    string line;
                    string[] line2;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line2 = line.Split(','); //разбиваем строку на подстроки
                        x.Add(Convert.ToInt32(line2[r1]));
                        y.Add(Convert.ToInt32(line2[r2]));
                        
                    }
                    sr.Close();

                    //Заполняем график считанными значениями
                    //chart1.Series["Series1"].LegendText = "График XY";
                    for (int i = 0; i < x.Count; i++)
                    {
                        chart2.Series[cn].Points.AddXY(x[i], y[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

         public void Cvs(int r1,int r2,int cn, string crnm, int lt)
        {
            
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                chart1.Visible = false;
                chart2.Visible = true;
                chart2.Series[cn].Name = crnm;

                if (lt == 0) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                if (lt == 1) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                if (lt == 2) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                if (lt == 3) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                if (lt == 4) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                if (lt == 5) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                if (lt == 6) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
                if (lt == 7) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
                if (lt == 8) chart2.Series[cn].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
          
                try
                {
                    //Инициализация массивов
                    x = new List<int>();
                    y = new List<int>();

                    //Чтение файла и запись значений в List x и y
                    StreamReader sr = new StreamReader(openFileDialog2.FileName);
                    string line;
                    string[] line2;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line2 = line.Split(';'); //разбиваем строку на подстроки
                        x.Add(Convert.ToInt32(line2[r1]));
                        y.Add(Convert.ToInt32(line2[r2]));
                    }
                    sr.Close();

                    //Заполняем график считанными значениями
                    //chart1.Series["Series1"].LegendText = "График XY";
                    for (int i = 0; i < x.Count; i++)
                    {
                        chart2.Series[cn].Points.AddXY(x[i], y[i]);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart2.Visible = false;

            int nc = comboBox1.SelectedIndex;
            chart1.Series[nc].Name = textBox6.Text;
            int tl = comboBox2.SelectedIndex;

            if (tl == 0) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            if (tl == 1) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            if (tl == 2) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            if (tl == 3) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            if (tl == 4) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            if (tl == 5) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            if (tl == 6) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            if (tl == 7) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            if (tl == 8) chart1.Series[nc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;

            double x_1 = double.Parse(textBox4.Text);
            double x_2 = double.Parse(textBox5.Text);
            double x_3 = double.Parse(textBox32.Text);
            double x_4 = double.Parse(textBox41.Text);
            double x_5 = double.Parse(textBox45.Text);
           
       
            double Xmin = double.Parse(textBox1.Text);
            double Xmax = double.Parse(textBox2.Text);
            double Step = double.Parse(textBox3.Text);

            int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;
            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = Xmin + Step * i;
                if (radioButton1.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Sin(x_2 * x[i] + x_3),x_5);

                if (radioButton2.Checked == true) y1[i] = x_4 + x_1 * Math.Pow(Math.Cos(x_2 * x[i] + x_3), x_5);

                if (radioButton16.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Exp(x_2 * x[i] + x_3),x_5);
                
                if (radioButton13.Checked == true) y1[i] = x_4+x_1 * Math.Pow((Math.Pow((x_2 * x[i] + x_3), 2)),x_5);
                

                if (radioButton14.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow((x_2 * x[i] + x_3), 3),x_5);
              

                if (radioButton10.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow((x_2 * x[i] + x_3), 0.5),x_5);
                

                //if (checkBox2.Checked == true) y1[i] = x_1*Math.Log(x_2*x[i]);
               

                //if (checkBox9.Checked == true) y1[i] = x_1*Math.Log10(x_2*x[i]);
                

                if (radioButton3.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Tan(x_2 * x[i] + x_3),x_5);
               

                if (radioButton7.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Sqrt(x_2 * x[i] + x_3),x_5);
               

                if (radioButton23.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Abs(x_2 * x[i] + x_3),x_5);
                

                if (radioButton4.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Sinh(x_2 * x[i] + x_3),x_5);
              
                if (radioButton5.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Cosh(x_2 * x[i] + x_3),x_5);
               
                if (radioButton6.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Tanh(x_2 * x[i] + x_3),x_5);
               

                if (radioButton17.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow(Math.E, (x_2 * x[i] + x_3)),x_5);
                

                if (radioButton18.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow(Math.E, (x_2 * -x[i] + x_3)),x_5);
                

                if (radioButton19.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow(Math.E, (x_2 * -(x[i]*x[i]) + x_3)),x_5);
                

                if (radioButton15.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow((x_2 * x[i] + x_3), double.Parse(textBox8.Text)),x_5);
                

                if (radioButton24.Checked == true) y1[i] = x_4+x_1 * Math.Pow(((x_2 * x[i] + x_3)),x_5);
               

                if (radioButton25.Checked == true) y1[i] = x_4+x_1 * Math.Pow((double.Parse(textBox10.Text) * (x_2 * x[i] + x_3)),x_5);
                

                if (radioButton26.Checked == true) y1[i] = x_4+x_1 * Math.Pow((double.Parse(textBox12.Text) * (x_2 * x[i] + x_3) + double.Parse(textBox14.Text)),x_5);
                

                if (radioButton27.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow((x_2 * x[i] + x_3), double.Parse(textBox16.Text)),x_5);
                

                if (radioButton28.Checked == true) y1[i] = x_4+x_1 * Math.Pow(((double.Parse(textBox18.Text) * Math.Pow((x_2 * x[i] + x_3), 2)) + (double.Parse(textBox20.Text) * (x_2 * x[i] + x_3)) + double.Parse(textBox21.Text)),x_5);
                

                if (radioButton29.Checked == true) y1[i] = x_4+x_1 * Math.Pow(((double.Parse(textBox24.Text) * Math.Pow((x_2 * x[i] + x_3), 3)) + (double.Parse(textBox25.Text) * Math.Pow((x_2 * x[i] + x_3), 2)) + (double.Parse(textBox26.Text) * (x_2 * x[i] + x_3)) + double.Parse(textBox27.Text)), x_5);
                

                if (radioButton11.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow((x_2 * x[i] + x_3), 0.666666666666667),x_5);
               

                if (radioButton12.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Pow((x_2 * x[i] + x_3), double.Parse(textBox34.Text)/double.Parse(textBox35.Text)),x_5);
                

                if (radioButton8.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Sign(x_2 * x[i] + x_3)* Math.Pow(Math.Abs(x_2 * x[i] + x_3), 1 / 3.0),x_5);
                
                if (radioButton9.Checked == true) y1[i] = x_4+x_1 * Math.Pow(Math.Sign(x_2 * x[i] + x_3) * Math.Pow(Math.Abs(x_2 * x[i] + x_3), 1 / double.Parse(textBox38.Text)),x_5);
              

                if (radioButton20.Checked == true) y1[i] = x_4+x_1 * Math.Pow(((x_2 * (1/(1+x[i]*x[i])) + x_3)),x_5);
               
       
                if (radioButton21.Checked == true) y1[i] = x_4+x_1 * Math.Pow(((x_2 * x[i] + x_3)% 2),x_5);
                
                if (radioButton22.Checked == true) y1[i] = x_4+x_1 * Math.Pow(((x_2 * x[i] + x_3) % double.Parse(textBox40.Text)),x_5);
               

            }
            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;

            chart1.Series[nc].Points.DataBindXY(x, y1);
           


        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox33_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox36_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://ramunisoft.blogspot.com/");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PointChart Builder 4.0\n\n\n© 2020 Ramunis Soft", "Information");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save image as ...";
                sfd.Filter = "*.bmp|*.bmp;|*.png|*.png;|*.jpg|*.jpg;|*.emf|*.emf";
                sfd.AddExtension = true;
                sfd.FileName = "graphicImage";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (chart1.Visible == true)
                    {
                        switch (sfd.FilterIndex)
                        {


                            case 1: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp); break;
                            case 2: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); break;
                            case 3: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); break;
                            case 4: chart1.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Emf); break;

                        }
                    }
                    else
                    {
                        switch (sfd.FilterIndex)
                        {


                            case 1: chart2.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Bmp); break;
                            case 2: chart2.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png); break;
                            case 3: chart2.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); break;
                            case 4: chart2.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Emf); break;
                        }
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox41_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox44_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox43_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox48_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox50_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox52_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {

        }

        private void buildChartXToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                
            

        }

        private void buildChartYToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void buildChartZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void splineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void splineToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
         
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;           
        }

        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;            
        }

        private void stepLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            
        }

        private void columnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            
        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            
        }

        private void splineAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;           
        }

        private void stackedAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            
        }

        private void rangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            
        }

        private void splineRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart1.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[4].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[5].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[6].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[7].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[8].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
            chart2.Series[9].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineRange;
        }

        private void modeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openCVSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
            //Cvs(0, 1, Form2.cn0);
        }

        private void openExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm1 = new Form3(this);
            newForm1.Show();
        }

        private void deleteChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[5].Points.Clear();
            chart1.Series[6].Points.Clear();
            chart1.Series[7].Points.Clear();
            chart1.Series[8].Points.Clear();
            chart1.Series[9].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            chart2.Series[3].Points.Clear();
            chart2.Series[4].Points.Clear();
            chart2.Series[5].Points.Clear();
            chart2.Series[6].Points.Clear();
            chart2.Series[7].Points.Clear();
            chart2.Series[8].Points.Clear();
            chart2.Series[9].Points.Clear();         
          
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://1drv.ms/b/s!Ag9gR5_fOidSgP8tL_ZnVRQNcAmWHw");
       
        }

        private void saveAsVectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save image as ...";
                sfd.Filter = "*.emf|";
                sfd.AddExtension = true;
                sfd.FileName = "graphicImage" + ".emf";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (chart1.Visible == true)
                    {
                       chart1.SaveImage(sfd.FileName , System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Emf); 

                        
                    }
                    else
                    {
                                                
                       chart2.SaveImage(sfd.FileName, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Emf); 
                        
                    }
                }
            }
        }

        private void поТочкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            chart2.Dock = DockStyle.Fill;
            chart1.Visible = false;
            Form2 newForm = new Form2(this);
            newForm.Show();
        }

        private void поМатематическойФункцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            chart1.Visible = true;
            chart2.Visible = false;
        }

        private void скрытьВводФункцийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                TToolStripMenuItem.Text = "Показать ввод функций";
                panel2.Visible = false;
                chart1.Dock = DockStyle.Fill;
                flag = true;
            }
            else
            {
                TToolStripMenuItem.Text = "Скрыть ввод функций";
                panel2.Visible = true;
                chart1.Dock = DockStyle.Left;
                flag = false;
            }
            
        }
    }

      
    
}

