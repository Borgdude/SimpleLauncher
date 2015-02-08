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
using System.Xml;

namespace SimpleLauncher
{
    public partial class stuff : Form
    {

        updateChecker uc = new updateChecker();

        

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
            uc.checkLocalVersion();
            uc.checkUpdate();
            if (uc.newVersion.CompareTo(uc.curVersion) < 0) {
                MessageBox.Show("No update available", "Simple Launcher", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            else {
                if ((MessageBox.Show("There is an update availabe, do you want to update now?", "Simple Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (DialogResult.Yes)));
                {
                    Process.Start(uc.newDownloadUrl);
                }
            }

        }

    }
}
