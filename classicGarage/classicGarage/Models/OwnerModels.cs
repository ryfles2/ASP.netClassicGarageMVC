using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classicGarage.Models
{
    public class OwnerModels
    {
        public int ID { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Phone { get; set; }

        public String Email { get; set; }
        public OwnerModels() { }

        public virtual ICollection<CarModels> Cars { get; set; }//bo wiele aut
    }
}