﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String firstName = fName.Text;
            String lastName = lName.Text;
            String email1=email.Text;
            String password1 = password.Text;
            String repeatPassword = rPassword.Text;
            String designation1 = designation.Text;
            Guid UniqueID = Guid.NewGuid();
            String id;
            id= UniqueID.ToString();
            if (password1 == repeatPassword)
            {
                User user = new User(id, firstName, lastName, email1, password1, designation1);
                Console.WriteLine(user.Designation);
                Form1 newForm = new Form1();
                DatabaseConnection db = new DatabaseConnection();
                db.addUser(user);
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password does not match");
            }
            
            
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Rectangle resolutionRect = System.Windows.Forms.Screen.FromControl(this).Bounds;
            if (this.Width >= resolutionRect.Width || this.Height >= resolutionRect.Height)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void fName_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            String firstName = fName.Text;
            String lastName = lName.Text;
            String email1 = email.Text;
            String password1 = password.Text;
            String repeatPassword = rPassword.Text;
            String designation1 = designation.Text;
            Guid UniqueID = Guid.NewGuid();
            String id;
            id = UniqueID.ToString();
            if (password1 == repeatPassword)
            {
                if((firstName!="")&&(lastName!="")&&(email1!="")&&(password1!="")&&(designation1!=""))
                {
                    Console.WriteLine("fName Not Null");
                    User user = new User(id, firstName, lastName, email1, password1, designation1);
                    Console.WriteLine(user.Designation);
                    Form1 newForm = new Form1();
                    DatabaseConnection db = new DatabaseConnection();
                   bool res= db.addUser(user);
                    Console.WriteLine(res);
                    if (res == true)
                    {
                        fmAlert fm = new fmAlert();
                        fm.Show();
                        fName.Text = "";
                        lName.Text = "";
                        email.Text = "";
                        password.Text = "";
                        rPassword.Text = "";
                        designation.Text = "";
                    }


                }
                else
                {
                    err fm = new err();
                    fm.Show();
                    fName.Text = "";
                    lName.Text = "";
                    email.Text = "";
                    password.Text = "";
                    rPassword.Text = "";
                    designation.Text = "";
                }
                
            }

            else
            {
                MessageBox.Show("Password does not match");
            }
        }

        private void fName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
    }
}
