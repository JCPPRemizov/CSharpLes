using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string num1, num2,D = "";
        private bool n2;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
            switch (D)
            {
                case "+":
                    {
                        textBox1.Text = (float.Parse(num1) + float.Parse(num2)).ToString();
                        break;
                    }
                case "-":
                    {
                        textBox1.Text = (float.Parse(num1) - float.Parse(num2)).ToString();
                        break;
                    }
                case "*":
                    {
                        textBox1.Text = (float.Parse(num1) * float.Parse(num2)).ToString();
                        break;
                    }
            }
            num1 = textBox1.Text;
            num2 = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            num1 = "";
            num2 = "";
            n2 = false;
            textBox1.Text = "0";

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (n2)
            {
                num2 += ".";
                textBox1.Text += ".";
            }
            else
            {
                num1 += ".";
                textBox1.Text += ".";
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            n2 = true;
            D = B.Text;
            textBox1.Text = num1 + D;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            if (n2)
            {
                num2 += B.Text;
                textBox1.Text += B.Text;
            }
            else
            {
                num1 += B.Text;
                textBox1.Text = num1;
            }
        }
    }
}
