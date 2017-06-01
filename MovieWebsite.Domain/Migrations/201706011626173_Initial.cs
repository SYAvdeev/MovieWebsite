namespace MovieWebsite.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        MovieID = c.Int(nullable: false),
                        ActorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieID, t.ActorID })
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Actor", t => t.ActorID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.ActorID);
            
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        MovieID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieID, t.GenreID })
                .ForeignKey("dbo.Movie", t => t.MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.GenreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieGenre", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.MovieGenre", "MovieID", "dbo.Movie");
            DropForeignKey("dbo.MovieActor", "ActorID", "dbo.Actor");
            DropForeignKey("dbo.MovieActor", "MovieID", "dbo.Movie");
            DropIndex("dbo.MovieGenre", new[] { "GenreID" });
            DropIndex("dbo.MovieGenre", new[] { "MovieID" });
            DropIndex("dbo.MovieActor", new[] { "ActorID" });
            DropIndex("dbo.MovieActor", new[] { "MovieID" });
            DropTable("dbo.MovieGenre");
            DropTable("dbo.MovieActor");
            DropTable("dbo.Movie");
            DropTable("dbo.Genre");
            DropTable("dbo.Actor");
        }
    }
}
