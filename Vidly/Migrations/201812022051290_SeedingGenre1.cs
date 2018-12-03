namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingGenre1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES(2,'Thriller')");
            Sql("INSERT INTO Genres VALUES(3,'Action')");
            Sql("INSERT INTO Genres VALUES(4,'Sex')");
            Sql("INSERT INTO Genres VALUES(5,'Fantasy')");
        }
        
        public override void Down()
        {
        }
    }
}
