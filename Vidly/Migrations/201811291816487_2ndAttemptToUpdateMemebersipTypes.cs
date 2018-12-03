namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndAttemptToUpdateMemebersipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' where id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' where id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Prime' where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
