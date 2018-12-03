namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CORRECTION : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Movies");
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "ReleasedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Movies", "Id");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Movies", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "ReleasedDate");
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
            AddPrimaryKey("dbo.Movies", "Id");
        }
    }
}
