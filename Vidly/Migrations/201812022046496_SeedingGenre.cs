namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES(1,'Comedy')");
           
        }
        
        public override void Down()
        {
        }
    }
}
