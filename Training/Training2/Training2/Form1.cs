using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(textBox1.Text);
            int q = Convert.ToInt32(textBox2.Text);
            int sum = Calculator.Add(p, q);
            MessageBox.Show(sum.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Circle c = new Circle();

            MessageBox.Show(c.DrawShape(""));
            MessageBox.Show(c.DrawShape());
        }
    }
}
