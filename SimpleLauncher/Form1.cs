using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SimpleLauncher
{
    public partial class stuff : Form
    {
        public stuff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://borgdude.github.io");
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

        }

    }
}
