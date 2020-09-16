using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleServiceManagementApp.Models;
using VehicleServiceManagementApp.DbConnection;

namespace VehicleServiceManagementApp
{
    public partial class AppoinmentTable : Form
    {
        public AppoinmentTable()
        {
            InitializeComponent();
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Display()
        {

            DatabaseConnection db = new DatabaseConnection();
            
            DataTable dt = new DataTable();

            db.GetAppoinments().Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
