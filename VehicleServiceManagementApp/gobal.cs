using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleServiceManagementApp
{

    static class global
    {
        private static string _globalVar = "";
        private static string _globaldes = "";

        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }

        public static string GlobalDes
        {
            get { return _globaldes; }
            set { _globaldes = value; }
        }
    }

}
