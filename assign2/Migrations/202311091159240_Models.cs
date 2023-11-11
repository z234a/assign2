namespace assign2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Topic_Name", "dbo.Topics");
            DropIndex("dbo.Products", new[] { "Topic_Name" });
            RenameColumn(table: "dbo.Products", name: "Topic_Name", newName: "TopicID");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Topics");
            AddColumn("dbo.Products", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Products", "Usefulness", c => c.String());
            AddColumn("dbo.Topics", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "TopicID", c => c.Int());
            AlterColumn("dbo.Topics", "Name", c => c.String());
            AddPrimaryKey("dbo.Products", "ID");
            AddPrimaryKey("dbo.Topics", "ID");
            CreateIndex("dbo.Products", "TopicID");
            AddForeignKey("dbo.Products", "TopicID", "dbo.Topics", "ID");
            DropColumn("dbo.Products", "ToicID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ToicID", c => c.Int());
            DropForeignKey("dbo.Products", "TopicID", "dbo.Topics");
            DropIndex("dbo.Products", new[] { "TopicID" });
            DropPrimaryKey("dbo.Topics");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Topics", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Products", "TopicID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Topics", "ID");
            DropColumn("dbo.Products", "Usefulness");
            DropColumn("dbo.Products", "ID");
            AddPrimaryKey("dbo.Topics", "Name");
            AddPrimaryKey("dbo.Products", "Name");
            RenameColumn(table: "dbo.Products", name: "TopicID", newName: "Topic_Name");
            CreateIndex("dbo.Products", "Topic_Name");
            AddForeignKey("dbo.Products", "Topic_Name", "dbo.Topics", "Name");
        }
    }
}
