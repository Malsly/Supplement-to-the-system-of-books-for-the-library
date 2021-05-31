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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Access = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accaunts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PrintedEditionOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PersonDebtOrderId = c.Int(nullable: false),
                        PersonTakenOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonDebtOrderId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonTakenOrderId)
                .Index(t => t.PersonDebtOrderId)
                .Index(t => t.PersonTakenOrderId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        PrintedEditionOrderID = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Rate = c.Single(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PrintedEditionOrderID)
                .ForeignKey("dbo.PrintedEditionOrders", t => t.PrintedEditionOrderID)
                .Index(t => t.PrintedEditionOrderID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        BookRefId = c.Int(nullable: false),
                        AuthorRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookRefId, t.AuthorRefId })
                .ForeignKey("dbo.Books", t => t.BookRefId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.AuthorRefId, cascadeDelete: true)
                .Index(t => t.BookRefId)
                .Index(t => t.AuthorRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Id", "dbo.Accaunts");
            DropForeignKey("dbo.PrintedEditionOrders", "PersonTakenOrderId", "dbo.People");
            DropForeignKey("dbo.PrintedEditionOrders", "PersonDebtOrderId", "dbo.People");
            DropForeignKey("dbo.Books", "PrintedEditionOrderID", "dbo.PrintedEditionOrders");
            DropForeignKey("dbo.BookAuthor", "AuthorRefId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthor", "BookRefId", "dbo.Books");
            DropIndex("dbo.BookAuthor", new[] { "AuthorRefId" });
            DropIndex("dbo.BookAuthor", new[] { "BookRefId" });
            DropIndex("dbo.Books", new[] { "PrintedEditionOrderID" });
            DropIndex("dbo.PrintedEditionOrders", new[] { "PersonTakenOrderId" });
            DropIndex("dbo.PrintedEditionOrders", new[] { "PersonDebtOrderId" });
            DropIndex("dbo.People", new[] { "Id" });
            DropTable("dbo.BookAuthor");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.PrintedEditionOrders");
            DropTable("dbo.People");
            DropTable("dbo.Accaunts");
        }
    }
}
