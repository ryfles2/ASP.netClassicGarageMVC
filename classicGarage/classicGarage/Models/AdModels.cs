using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classicGarage.Models
{
    public class AdModels
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public bool Active { get; set; }

        public String Mail { get; set; }

        public virtual CarModels Car { get; set; }
    }
}