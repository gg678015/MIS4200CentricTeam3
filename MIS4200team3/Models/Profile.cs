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
        public bUnit businessUnit { get; set; }
        public string hireDate { get; set; }
        public string employeeTitle { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public enum bUnit
        {
            Boston,
            Charlotte,
            Chicago,
            Cincinnati,
            Cleveland,
            Columbus,
            India,
            Indianapolis,
            Louisville,
            Miami,
            Seattle,
            StLouis,
            Tampa
        }
        ICollection<Recognition> Recognition { get; set; }

        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }

    }
}