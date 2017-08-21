namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tournaments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tournaments", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tournaments", "Location", c => c.String());
            DropColumn("dbo.Tournaments", "Name");
        }
    }
}
