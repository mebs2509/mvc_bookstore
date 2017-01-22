namespace Bookstore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Title = c.String(maxLength: 255),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookLevelId = c.Byte(nullable: false),
                        BookStateId = c.Byte(nullable: false),
                        PageNumbers = c.Int(nullable: false),
                        BookCoverId = c.Int(nullable: false),
                        BookFormatId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        ISBN10 = c.String(),
                        ISBB13 = c.String(),
                        Dimensions = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReviewRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RankTop100 = c.Int(nullable: false),
                        StockMin = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.BookCovers", t => t.BookCoverId, cascadeDelete: true)
                .ForeignKey("dbo.BookFormats", t => t.BookFormatId, cascadeDelete: true)
                .ForeignKey("dbo.BookLevels", t => t.BookLevelId, cascadeDelete: true)
                .ForeignKey("dbo.BookStates", t => t.BookStateId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.BookLevelId)
                .Index(t => t.BookStateId)
                .Index(t => t.BookCoverId)
                .Index(t => t.BookFormatId)
                .Index(t => t.PublisherId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.BookCovers",
                c => new
                    {
                        BookCoverId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BookCoverId);
            
            CreateTable(
                "dbo.BookFormats",
                c => new
                    {
                        BookFormatId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BookFormatId);
            
            CreateTable(
                "dbo.BookLevels",
                c => new
                    {
                        BookLevelId = c.Byte(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.BookLevelId);
            
            CreateTable(
                "dbo.BookStates",
                c => new
                    {
                        BookStateId = c.Byte(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.BookStateId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        ContactName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.BookTags",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.TagId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.BookTags", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Books", "BookStateId", "dbo.BookStates");
            DropForeignKey("dbo.Books", "BookLevelId", "dbo.BookLevels");
            DropForeignKey("dbo.Books", "BookFormatId", "dbo.BookFormats");
            DropForeignKey("dbo.Books", "BookCoverId", "dbo.BookCovers");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.BookTags", new[] { "TagId" });
            DropIndex("dbo.BookTags", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "LanguageId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "BookFormatId" });
            DropIndex("dbo.Books", new[] { "BookCoverId" });
            DropIndex("dbo.Books", new[] { "BookStateId" });
            DropIndex("dbo.Books", new[] { "BookLevelId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.BookTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Publishers");
            DropTable("dbo.Languages");
            DropTable("dbo.BookStates");
            DropTable("dbo.BookLevels");
            DropTable("dbo.BookFormats");
            DropTable("dbo.BookCovers");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
