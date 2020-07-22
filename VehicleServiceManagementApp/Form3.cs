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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String cusName = textBox1.Text;
            String cusPhn = textBox2.Text;
            String email = textBox3.Text;
            String vehicle = textBox4.Text;
           // String dtaTime = dateTimePicker1.Value.ToString("yyyy-MM-dd"); 
            Guid UniqueID = Guid.NewGuid();
            String id;
            id = UniqueID.ToString();

            Appoinment appoinment = new Appoinment(id ,cusName, cusPhn, email, vehicle, dateTimePicker1.Value.ToString());
            DatabaseConnection db = new DatabaseConnection();
            db.addAppoinment(appoinment);
        }
    }
}
