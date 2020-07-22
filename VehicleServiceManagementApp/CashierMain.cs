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
    }
}
