namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
          Sql("update MembershipTypes set Name =  where id = '3' ");
        }
        public override void Down()
        {

        }
    }
}
