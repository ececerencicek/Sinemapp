namespace Sinemapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "FilmId", "dbo.Films");
            DropIndex("dbo.Genres", new[] { "FilmId" });
            AddColumn("dbo.Films", "Name", c => c.String());
            AddColumn("dbo.Films", "Genre", c => c.Int(nullable: false));
            DropColumn("dbo.Films", "FilmName");
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        FilmId = c.Guid(),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedBy = c.String(),
                        DeletedAt = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IpAddress = c.String(),
                        UserAgent = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "FilmName", c => c.String());
            DropColumn("dbo.Films", "Genre");
            DropColumn("dbo.Films", "Name");
            CreateIndex("dbo.Genres", "FilmId");
            AddForeignKey("dbo.Genres", "FilmId", "dbo.Films", "Id");
        }
    }
}
