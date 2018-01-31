using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classicGarage.Models
{
    public class CarModels
    {
        public int ID { get; set; }

        public String Brand { get; set; }

        public String Model { get; set; }

        public String Year { get; set; }

        public int VIN { get; set; }

        public String Name { get; set; }

        public String PhotoAdress { get; set; }

        public DateTime DatePurchase { get; set; }

        public DateTime DateSale { get; set; }

        public double PurchasePrice { get; set; }

        public double SellingPrice { get; set; }

        public int OwnerID { get; set; }

        public virtual OwnerModels owner { get; set; }//bo jeden właściciel
    }
}