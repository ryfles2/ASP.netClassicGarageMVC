using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classicGarage.Models
{
    public class RepairModels
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public String Name { get; set; }
        public String Desciption { get; set; }
        public double RepairCost { get; set; }

        public virtual CarModels Car { get; set; }
    }
}