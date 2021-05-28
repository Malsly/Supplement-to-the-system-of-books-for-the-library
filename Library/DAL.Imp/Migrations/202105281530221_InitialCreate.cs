namespace DAL.Imp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accaunts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Access = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrintedEditionOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PrintedEdition_Id = c.Int(),
                        Person_Id = c.Int(),
                        Person_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.PrintedEdition_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .ForeignKey("dbo.People", t => t.Person_Id1)
                .Index(t => t.PrintedEdition_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Person_Id1);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Single(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Accaunts", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PrintedEditionOrders", "Person_Id1", "dbo.People");
            DropForeignKey("dbo.PrintedEditionOrders", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PrintedEditionOrders", "PrintedEdition_Id", "dbo.Books");
            DropForeignKey("dbo.Authors", "Book_Id", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Book_Id" });
            DropIndex("dbo.PrintedEditionOrders", new[] { "Person_Id1" });
            DropIndex("dbo.PrintedEditionOrders", new[] { "Person_Id" });
            DropIndex("dbo.PrintedEditionOrders", new[] { "PrintedEdition_Id" });
            DropIndex("dbo.Accaunts", new[] { "Person_Id" });
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.PrintedEditionOrders");
            DropTable("dbo.People");
            DropTable("dbo.Accaunts");
        }
    }
}
