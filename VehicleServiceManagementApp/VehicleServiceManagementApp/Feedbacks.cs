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
    public partial class Feedbacks : Form
    {
        public Feedbacks()
        {
            InitializeComponent();
            Display();
        }
        public void Display()
        {

            DatabaseConnection db = new DatabaseConnection();

            DataTable dt = new DataTable();

            db.GetFeedbacks().Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
