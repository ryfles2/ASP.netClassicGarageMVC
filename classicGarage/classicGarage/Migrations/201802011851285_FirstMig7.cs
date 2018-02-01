namespace classicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartModels", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PartModels", "Mail");
        }
    }
}
