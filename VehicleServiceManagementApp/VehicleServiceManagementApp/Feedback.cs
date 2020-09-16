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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
            
        }
        static String state;
        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            state = "delighted";
        }

        private void gunaImageButton2_Click(object sender, EventArgs e)
        {
            state = "happy";
        }

        private void gunaImageButton3_Click(object sender, EventArgs e)
        {
            state = "average";
        }

        private void gunaImageButton4_Click(object sender, EventArgs e)
        {
            state = "angry";
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            String descrip = gunaTextBox1.Text;
            DatabaseConnection db = new DatabaseConnection();
            bool res=db.addFeedbacks(state, descrip);
            if (res == true)
            {
                fmAlert fm = new fmAlert();
                fm.Show();
            }
            else
            {
                err er = new err();
                er.Show();
            }
            gunaTextBox1.Text="";
            state = "";
        }
    }
}
