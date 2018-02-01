namespace classicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdModels", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdModels", "Mail");
        }
    }
}
