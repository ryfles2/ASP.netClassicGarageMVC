using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classicGarage.Models
{
    public class PartModels
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public String Name { get; set; }
        public String CatNumber { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime DatePurchase { get; set; }
        public DateTime DateSale { get; set; }

        public String Mail { get; set; }

        public virtual CarModels Car { get; set; }
    }
}