using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpTime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // Uptime Core Code Begins

        public static TimeSpan GetUpTime()
        {
            return TimeSpan.FromMilliseconds(GetTickCount64());
        }

        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();

        // Uptime Core Code Ends


        //Action on MouseOver

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            TimeSpan ts = GetUpTime();

            string TimeString = Convert.ToString(ts);

            TimeString = TimeString.Remove(TimeString.IndexOf('.'));

            notifyIcon1.Text = "UpTime : " + TimeString;
        }

        // Action on Clicking 'End'

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
