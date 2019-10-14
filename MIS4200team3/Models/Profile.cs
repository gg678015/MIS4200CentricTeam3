using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200team3.Models
{
    public class Profile
    {
        public int profileID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public CoreValue businessUnit { get; set; }
        public string hireDate { get; set; }
        public string employeeTitle { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public enum CoreValue
        {
            Boston = 1,
            Charlotte =2,
            Chicago =3,
            Cincinnati =4,
            Cleveland =5,
            Columbus =6,
            India =7,
            Indianapolis =8,
            Louisville =9,
            Miami =10,
            Seattle =11,
            StLouis =12,
            Tampa =13
        }
    }
}