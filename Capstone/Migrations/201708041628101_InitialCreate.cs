namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        TeamAId = c.Int(nullable: false),
                        TeamBId = c.Int(nullable: false),
                        TournamentId = c.Int(nullable: false),
                        AScore = c.Int(nullable: false),
                        BScore = c.Int(nullable: false),
                        Round = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TournamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Location = c.String(),
                        OrganizerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Matches", "TournamentId", "dbo.Tournaments");
            DropIndex("dbo.Teams", new[] { "TournamentId" });
            DropIndex("dbo.Matches", new[] { "TournamentId" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.Teams");
            DropTable("dbo.Matches");
        }
    }
}
