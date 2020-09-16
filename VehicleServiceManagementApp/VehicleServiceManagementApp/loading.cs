using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleServiceManagementApp
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
            gunaCircleProgressBar1.Value = 0;
            timer1.Start();
        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaCircleProgressBar1.Increment(1);
        }

        private void gunaCircleProgressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
