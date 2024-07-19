namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCustomerBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers set Birthdate='07/16/1985' where id=1");
        }
        
        public override void Down()
        {
        }
    }
}
