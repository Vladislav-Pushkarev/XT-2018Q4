using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task6.BackupSystem5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            this.InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Backupper.TargetPath = fbd.SelectedPath;
                this.Hide();
                try
                {
                    Backupper.PrepareToWork();
                    Backupper.CopyAll(Backupper.TargetPath);
                    Watcher.RunWatch(Backupper.TargetPath);
                    this.Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            Form1 f = new Form1(); 
            f.ShowDialog();
            Console.WriteLine("Your txt files was restored.");
            this.Close();
        }
    }
}