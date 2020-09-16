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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
            display();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void display()
        {
            s1.Titles.Add("Service Statistics");
            DatabaseConnection db = new DatabaseConnection();
            int cusNo=db.getTotalCustomers();
            Console.WriteLine(cusNo);
            s1.Series["s1"].Points.AddXY("1", cusNo);
            s1.Series["s1"].Points.AddXY("2", db.getTotalAppoinmnets());
            s1.Series["s1"].Points.AddXY("2", db.getTotalEmplyees());
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            //CrystalReport cs = new CrystalReport();
            
        }
    }
}
