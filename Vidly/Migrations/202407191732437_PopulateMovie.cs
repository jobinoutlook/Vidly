namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Movies(Name, GenreId, ReleaseDate) values('Hangover', 1, '07/16/2007')");
            Sql("insert into Movies(Name, GenreId, ReleaseDate) values('The Terminator', 2, '11/23/1990')");
            Sql("insert into Movies(Name, GenreId, ReleaseDate) values('Titanic', 3, '06/08/1997')");
        }
        
        public override void Down()
        {

        }
    }
}
