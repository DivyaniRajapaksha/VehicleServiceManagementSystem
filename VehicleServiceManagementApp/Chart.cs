using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleServiceManagementApp.DbConnection;


namespace VehicleServiceManagementApp
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
            display();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void display()
        {
            DatabaseConnection db = new DatabaseConnection();
            int cusNo=db.getTotalCustomers();
            Console.WriteLine(cusNo);
        }
    }
}
