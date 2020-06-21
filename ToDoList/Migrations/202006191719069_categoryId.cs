namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoes", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.ToDoes", new[] { "Category_CategoryId" });
            RenameColumn(table: "dbo.ToDoes", name: "Category_CategoryId", newName: "categoryId");
            AlterColumn("dbo.ToDoes", "categoryId", c => c.Int(nullable: true));
            CreateIndex("dbo.ToDoes", "categoryId");
            AddForeignKey("dbo.ToDoes", "categoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "categoryId", "dbo.Categories");
            DropIndex("dbo.ToDoes", new[] { "categoryId" });
            AlterColumn("dbo.ToDoes", "categoryId", c => c.Int());
            RenameColumn(table: "dbo.ToDoes", name: "categoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.ToDoes", "Category_CategoryId");
            AddForeignKey("dbo.ToDoes", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
