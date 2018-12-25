using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task6.BackupSystem5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            this.InitializeComponent();
        }

        private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Watcher.Stopped = true;
            this.Close();
        }
    }
}