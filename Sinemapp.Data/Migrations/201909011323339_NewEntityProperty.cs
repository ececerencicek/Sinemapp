namespace Sinemapp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntityProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Casts", "FilmName", c => c.String());
            AddColumn("dbo.Casts", "TvSerieName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Casts", "TvSerieName");
            DropColumn("dbo.Casts", "FilmName");
        }
    }
}
