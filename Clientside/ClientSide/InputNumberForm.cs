using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientSide
{
    public partial class InputNumberForm : Form
    {
        public int number { get; private set; }

        public InputNumberForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result;
            if (int.TryParse(textBox1.Text, out result))
            {
                number = result;
            }
            else
            {
                MessageBox.Show("You need to pick a number!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
