using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS4200team3.Models
{
    public class Recognition
    {
        public int recognitionID { get; set;}

        public string description { get; set; }

        public cValues values { get; set; }

        public enum cValues
        {
            Stewardship,
            Culture,
            DeliveryExcellance,
            Innovation,
            GreaterGood,
            Integrity,
            Balance
        }

        
        public int profileID { get; set; }
        public virtual Profile Profile { get; set; }





    }
}