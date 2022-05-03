using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp24
{
    public partial class Form2 : Form
    {
        private Form1 refForm;
        public Form2(Form1 refForm)
        {
            InitializeComponent();
            this.refForm = refForm;          

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

            comboBox2.SelectedIndex = 3;
        }
        public static int cn0;
        public static int lt0;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lt0 = comboBox2.SelectedIndex;
            cn0 = comboBox1.SelectedIndex;
           
            string chnm1 =textBox3.Text;
                      
            if (radioButton1.Checked == true)
            {
                if (Form1.SelfRef != null)
                {
                    Form1.SelfRef.Cvs(0, 1, cn0, chnm1, lt0);
                }
            }
            if (radioButton2.Checked == true)
            {
                if (Form1.SelfRef != null)
                {
                    Form1.SelfRef.Cvs(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), cn0, chnm1, lt0);
                }
            }
            //Cvs(0, 1, Form2.cn0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
