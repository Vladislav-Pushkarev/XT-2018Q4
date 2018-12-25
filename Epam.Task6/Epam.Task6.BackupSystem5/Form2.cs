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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                Backupper.targetPath = fbd.SelectedPath;
                ActiveForm.Hide();
                try
                {
                    Backupper.CopyAll(Backupper.targetPath);
                    Watcher.RunWatch(Backupper.targetPath);
                    Application.Run(new Form2());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}