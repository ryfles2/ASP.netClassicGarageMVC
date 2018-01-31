
using classicGarage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace classicGarage.DAL
{
    public class GarageContext:DbContext 
    {
      public GarageContext() : base("GarageDatabase") { }  

      public DbSet<CarModels> Car { get; set; }

      public DbSet<OwnerModels> Owner { get; set; }

      public DbSet<PartModels> Part { get; set; }

      public DbSet<RepairModels> Repair { get; set; }

      public DbSet<AdModels> Advertisement { get; set; }

    }
}