namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelMovieUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockCount");
        }
    }
}
