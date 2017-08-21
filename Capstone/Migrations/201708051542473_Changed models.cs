namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tournaments", "OrganizerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tournaments", "OrganizerId", c => c.Int(nullable: false));
        }
    }
}
