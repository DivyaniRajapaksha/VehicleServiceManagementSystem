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
    public partial class CashierMain : Form
    {
        public CashierMain()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cashier newChild = new Cashier();
            newChild.MdiParent = this;
            newChild.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SearchAppoinemnt sa = new SearchAppoinemnt();
            sa.MdiParent = this;
            sa.Show();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Feedback sa = new Feedback();
            sa.MdiParent = this;
            sa.Show();
        }
    }
}
