namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.ToDoes", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.ToDoes", "Category_CategoryId");
            AddForeignKey("dbo.ToDoes", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.ToDoes", new[] { "Category_CategoryId" });
            DropColumn("dbo.ToDoes", "Category_CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
