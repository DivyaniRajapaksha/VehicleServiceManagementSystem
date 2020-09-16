using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using VehicleServiceManagementApp.DbConnection;
using VehicleServiceManagementApp.Models;
using System.Data.SqlClient;

namespace VehicleServiceManagementApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            gunaCircleProgressBar1.Value = 0;
            timer1.Start();
            sentMail();
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaCircleProgressBar1.Increment(1);
            if (gunaCircleProgressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                Form1 f1 = new Form1();
                f1.Hide();
               
            }
        }
        private void sentMail()
        {
            try
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                var after = today.AddDays(3);


                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("fashionstoregtsd@gmail.com");
               

                msg.Subject = "Appoinment Reminder";

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "fashionstoregtsd@gmail.com";
                ntcd.Password = "Fashionstore123";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;

                string email1;
                
                DatabaseConnection db = new DatabaseConnection();
                SqlDataReader reader = db.GetAppoinmnetMails(tomorrow.ToString(), after.ToString());
                if (reader.Read())
                {
                    Console.WriteLine(tomorrow.ToString());
                    Console.WriteLine("Mail In");
                    Console.WriteLine((string)reader["email"]);
                    //msg.To.Add((string)reader["email"]);
                    msg.To.Add((string)reader["email"]);
                    msg.Body = "Your appoinment due date is " + tomorrow + " at Mihiran Vehicle Service! This is a friendly Reminder.";
                    smt.Send(msg);
                    MessageBox.Show("Your Mail is sended");
                    //fmAlert fm = new fmAlert();
                    //fm.Show();
                   


                    db.updateStatus(int.Parse(reader["AppoinmentId"].ToString()));
                }





            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
