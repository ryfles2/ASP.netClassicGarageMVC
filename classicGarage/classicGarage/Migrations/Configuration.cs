namespace classicGarage.Migrations
{
    using classicGarage.DAL;
    using classicGarage.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<classicGarage.DAL.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(classicGarage.DAL.GarageContext context)
        {
            ////SeedOwner(context);
        }

        private void SeedOwner(GarageContext contex)
        {
            var owners = new List<OwnerModels>
            {
                new OwnerModels { FirstName = "Adam", LastName = "Adamski" ,Email = "ad@wp.pl", Phone="41231512"},
                new OwnerModels { FirstName = "Maciej", LastName = "Sawicki" ,Email = "ma@wp.pl", Phone="3512331"},
                new OwnerModels { FirstName = "Adam", LastName = "Adamczyk" ,Email = "ada@wp.pl", Phone="31851221"},
                new OwnerModels { FirstName = "Julian", LastName = "Julczyk" ,Email = "ju@wp.pl", Phone="19364332"}
            };
            foreach(var x in owners)
            {
                contex.Owner.Add(x);
            }
            contex.SaveChanges();

        }
    }
}
