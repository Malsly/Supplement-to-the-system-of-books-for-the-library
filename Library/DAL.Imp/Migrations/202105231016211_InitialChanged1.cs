namespace DAL.Imp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialChanged1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authors", "Book_Id", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Book_Id" });
            DropTable("dbo.Authors");
        }
    }
}
