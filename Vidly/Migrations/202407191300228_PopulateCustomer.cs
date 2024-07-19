namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Customers (Name,IsSubscribedToNewsletter,MembershipTypeId) Values ('John Smith',0,1)");
            Sql("Insert into Customers (Name,IsSubscribedToNewsletter,MembershipTypeId) Values ('Mary Williams',1,2)");
        }
        
        public override void Down()
        {
        }
    }
}
