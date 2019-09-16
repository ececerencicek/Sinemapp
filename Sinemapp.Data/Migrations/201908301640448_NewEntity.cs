namespace Sinemapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TvSeries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Country = c.Int(nullable: false),
                        Genre = c.Int(nullable: false),
                        Rating = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Photo = c.String(),
                        Description = c.String(),
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
            
            AddColumn("dbo.Casts", "TvSerieId", c => c.Guid());
            CreateIndex("dbo.Casts", "TvSerieId");
            AddForeignKey("dbo.Casts", "TvSerieId", "dbo.TvSeries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Casts", "TvSerieId", "dbo.TvSeries");
            DropIndex("dbo.Casts", new[] { "TvSerieId" });
            DropColumn("dbo.Casts", "TvSerieId");
            DropTable("dbo.TvSeries");
        }
    }
}
