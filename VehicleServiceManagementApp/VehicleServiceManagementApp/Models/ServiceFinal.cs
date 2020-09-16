using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManagementApp.Models
{
    class ServiceFinal
    {
        private String serviceId;
        private double totprice;
        private double discount;
        private int cusphone;
        private String date;

        public ServiceFinal(string serviceId, double totprice, double discount, int cusphone, string date)
        {
            this.serviceId = serviceId;
            this.totprice = totprice;
            this.discount = discount;
            this.cusphone = cusphone;
            this.date = date;
        }

        public string ServiceId { get => serviceId; set => serviceId = value; }
        public double Totprice { get => totprice; set => totprice = value; }
        public double Discount { get => discount; set => discount = value; }
        public int Cusphone { get => cusphone; set => cusphone = value; }
        public string Date { get => date; set => date = value; }
    }
}
