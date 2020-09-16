using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManagementApp.Models
{
    class ServiceItem
    {
        private String serviceName;
        private double price;
        private double discount;
        private double amount;

        public ServiceItem(string serviceName, double price, double discount, double amount)
        {
           
            ServiceName = serviceName;
            Price = price;
            Discount = discount;
            Amount = amount;
        }

        public string ServiceName { get => serviceName; set => serviceName = value; }
        public double Price { get => price; set => price = value; }
        public double Discount { get => discount; set => discount = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}
