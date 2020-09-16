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
    public partial class SearchAppoinemnt : Form
    {
        public SearchAppoinemnt()
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

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            String search=gunaTextBox1.Text;
            DatabaseConnection db = new DatabaseConnection();
            DataTable dt = new DataTable();

            db.GetSelectedAppoinments(search).Fill(dt);
            dataGridView1.DataSource = dt;
            

        }
    }
}
