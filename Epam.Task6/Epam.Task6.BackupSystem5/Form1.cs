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
    public partial class Form1 : Form
    {
        private static long recovTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime time = dateTimePicker1.Value;
            string message = $"You selected {time.ToString()}. Click 'OK' to confirm.";
            label1.Text = message;
            recovTime = long.Parse(time.ToString("yyyyMMddHHmmss"));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Backupper.Restore(recovTime);
            Close();
        }
    }
}
