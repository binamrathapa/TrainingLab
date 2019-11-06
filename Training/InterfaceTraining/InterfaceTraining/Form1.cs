using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceTraining
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory f = new Factory();
            Shape s=  f.GetShape(textBox1.Text) ;
            MessageBox.Show( s.DrawShape(textBox1.Text, 3, 4));
        }
    }
}
