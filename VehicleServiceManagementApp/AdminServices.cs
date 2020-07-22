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
    public partial class AdminServices : Form
    {
        public AdminServices()
        {
            InitializeComponent();
            Display();
        }

        private void AdminServices_Load(object sender, EventArgs e)
        {

        }
        public void Display()
        {

            DatabaseConnection db = new DatabaseConnection();

            DataTable dt = new DataTable();

            db.GetServicess().Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
