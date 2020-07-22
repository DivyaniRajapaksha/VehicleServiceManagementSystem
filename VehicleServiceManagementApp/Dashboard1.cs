using System;
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
    public partial class Dashboard1 : Form
    {
        public Dashboard1()
        {
            InitializeComponent();
            this.toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.AutoSize = false; toolStrip1.Height = 100;
            toolStrip1.Margin = new System.Windows.Forms.Padding
     (8, 0, 8, 0);
            Shown += Form1_Shown;
            sentMail();

        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Console.WriteLine(global.GlobalVar);
            toolStripLabel1.Text = global.GlobalVar;
            toolStripLabel2.Text = global.GlobalDes;
        }
        private void Dashboard1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Chart newChild = new Chart();
            newChild.MdiParent = this;
            newChild.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AdminServices newChild = new AdminServices();
            newChild.MdiParent = this;
            newChild.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CashierMain cs = new CashierMain();
            this.Hide();
            cs.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void addAppoinmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newChild = new Form3();
            newChild.MdiParent = this;
            newChild.Show();
        }

        private void viewAppoinmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AppoinmentTable newChild = new AppoinmentTable();
            newChild.MdiParent = this;
            newChild.Show();
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
               
                    Console.WriteLine((string)reader["email"]);
                      msg.To.Add((string)reader["email"]);
                 
                    msg.Body = "Your appoinment due date is " + tomorrow + " at Mihiran Vehicle Service! This is a friendly Reminder.";
                    smt.Send(msg);
                    MessageBox.Show("Your Mail is sended");
                     

                  db.updateStatus(int.Parse(reader["AppoinmentId"].ToString()));
                }
                


                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }
    }
}
