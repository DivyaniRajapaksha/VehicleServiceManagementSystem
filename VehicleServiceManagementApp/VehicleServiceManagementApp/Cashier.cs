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
using System.Collections;

namespace VehicleServiceManagementApp
{
    public partial class Cashier : Form
    {
        private static List<ServiceItem> myarray = new List<ServiceItem>();
        private static double tot = 0;
        private static double discount1 = 0;
        public Cashier()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void serviceName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           
            String serviceName1 = serviceName.Text;
            double discount1;
            double pricee;

            if (!double.TryParse(discount.Text, out discount1))
            {
                discount1 = 0;
            }
            if (!double.TryParse(price.Text, out pricee))
            {
                pricee = 0;
            }

            double amountt = pricee - discount1;

            ServiceItem serviceItem = new ServiceItem(serviceName1, pricee, discount1, amountt);
            myarray.Add(serviceItem);


            this.display();

            amount.Text = " ";
            serviceName.Text = " ";
            price.Text = " ";
            discount.Text = " ";
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
            double discount1;
            double pricee;

            if (!double.TryParse(discount.Text, out discount1))
            {
                discount1= 0;
            }
            if (!double.TryParse(price.Text, out pricee))
             {
                pricee= 0;
             }

                double amountt = pricee - discount1;
            amount.Text = (amountt).ToString();
        }

        public void display() {
            DataTable dt = new DataTable();
            List<ServiceItem> array = new List<ServiceItem>();
            
            foreach (ServiceItem i in myarray)
            {
                tot = tot + i.Amount;
                Console.WriteLine(i.Amount);
                Console.WriteLine(i.ServiceName);
                discount1 = discount1 +i.Discount;

                array.Add(i);

            }
            this.dataGridView1.DataSource = array;

            label7.Text = tot.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Customer PhoneNo :", "Customer Details");
            Console.WriteLine(promptValue);
            Guid UniqueID = Guid.NewGuid();
            String id;
            id = UniqueID.ToString();
            String date = DateTime.Now.ToString("M/d/yyyy");
            int phoneNo;

            if (!int.TryParse(promptValue, out phoneNo))
            {
                phoneNo = 0;
            }
            ServiceFinal sf = new ServiceFinal(id, tot, discount1, phoneNo, date);
            DatabaseConnection db = new DatabaseConnection();
            db.addService(sf);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String serviceName1 = serviceName.Text;
            double discount1;
            double pricee;

            if (!double.TryParse(discount.Text, out discount1))
            {
                discount1 = 0;
            }
            if (!double.TryParse(price.Text, out pricee))
            {
                pricee = 0;
            }

            double amountt = pricee - discount1;

            ServiceItem serviceItem = new ServiceItem(serviceName1, pricee, discount1, amountt);
            myarray.Add(serviceItem);


            this.display();

            amount.Text = " ";
            serviceName.Text = " ";
            price.Text = " ";
            discount.Text = " ";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Customer PhoneNo :", "Customer Details");
            Console.WriteLine(promptValue);
            Guid UniqueID = Guid.NewGuid();
            String id;
            id = UniqueID.ToString();
            String date = DateTime.Now.ToString("M/d/yyyy");
            int phoneNo;

            if (!int.TryParse(promptValue, out phoneNo))
            {
                phoneNo = 0;
            }
            ServiceFinal sf = new ServiceFinal(id, tot, discount1, phoneNo, date);
            DatabaseConnection db = new DatabaseConnection();
            db.addService(sf);
            dataGridView1.DataSource = null;
            myarray.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            myarray.Clear();
            
        }

        private void Cashier_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
