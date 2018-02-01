namespace classicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairModels", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairModels", "Mail");
        }
    }
}
