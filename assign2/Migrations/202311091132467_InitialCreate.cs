namespace assign2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Place = c.String(),
                        ToicID = c.Int(),
                        Topic_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Topics", t => t.Topic_Name)
                .Index(t => t.Topic_Name);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Topic_Name", "dbo.Topics");
            DropIndex("dbo.Products", new[] { "Topic_Name" });
            DropTable("dbo.Topics");
            DropTable("dbo.Products");
        }
    }
}
