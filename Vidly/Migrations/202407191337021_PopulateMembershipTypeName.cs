namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name='Pay as You go' where id=1");
            Sql("Update MembershipTypes set Name='Pay Monthly' where id=2");
            Sql("Update MembershipTypes set Name='Pay Quarterly' where id=3");
            Sql("Update MembershipTypes set Name='Pay Yearly' where id=4");

        }

        public override void Down()
        {
        }
    }
}
