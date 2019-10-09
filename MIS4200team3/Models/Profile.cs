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
        public string businessUnit { get; set; }
        public string hireDate { get; set; }
        public string employeeTitle { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}