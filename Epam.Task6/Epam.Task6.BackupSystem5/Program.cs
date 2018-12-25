using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Epam.Task6.BackupSystem5
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            
            
            try
            {



                Console.WriteLine("Enter Date and Time of recovery.");
                string s = Console.ReadLine();
                s = Console.ReadLine();
                long parsed = long.Parse(s);
                long recovTime = parsed;
                Backupper.Restore(recovTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}
