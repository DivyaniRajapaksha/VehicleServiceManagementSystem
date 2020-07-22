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
using VehicleServiceManagementApp.Models;

namespace VehicleServiceManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard1 db1 = new Dashboard1();
            String email1 = email.Text;
            String password1 = password.Text;
            DatabaseConnection db = new DatabaseConnection();
            Boolean result=db.loginUser(email1, password1);
            Console.WriteLine(result);
            if (result == true)
            {
                User user = db.Getuser(email1);
                global.GlobalVar = user.FirstName + " " + user.LastName;
                global.GlobalDes = user.Designation;
                this.Hide();
                db1.Show();
                

            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("Invalid Credentials!! Try Again");
                MessageBox.Show("Invalid Credentials!! Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                email.Text=" ";
                password.Text = " ";
            }

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
