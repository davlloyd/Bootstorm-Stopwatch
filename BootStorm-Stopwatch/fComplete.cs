using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BootStorm_Stopwatch
{
    public partial class fComplete : Form
    {
        public fComplete()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fComplete_Load(object sender, EventArgs e)
        {

        }

        public string TimeCompleted { set { lCompleteTime.Text = value; } }

        public string LUNName { set { lLUN.Text = value; } }

        public string Location { set { this.Location = value; } }


        private void fComplete_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
