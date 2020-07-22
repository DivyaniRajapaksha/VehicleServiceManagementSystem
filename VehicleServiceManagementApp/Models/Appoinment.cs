using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManagementApp.Models
{
    class Appoinment
    {
        private String appId;
        private String cusName;
        private String cusphn;
        private String email;
        private String vehicle;
        private String dateTime;
        public Appoinment(string appId, string cusName, string cusphn, string email, string vehicle, string dateTime)
        {
            this.appId = appId;
            this.cusName = cusName;
            this.email = email;
            this.cusphn = cusphn;
            this.vehicle = vehicle;
            this.dateTime = dateTime;

        }

        public string AppId { get => appId; set => appId = value; }
        public string CusName { get => cusName; set => cusName = value; }
        public string Cusphn { get => cusphn; set => cusphn = value; }
        public string Email { get => email; set => email = value; }
        public string Vehicle { get => vehicle; set => vehicle = value; }
        public string DateTime { get => dateTime; set => dateTime = value; }
    }
}
