namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRomanceToGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres VALUES(6,'Love')");
        }
        
        public override void Down()
        {
        }
    }
}
