namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryRefactored : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoes", "categoryId", "dbo.Categories");
            DropIndex("dbo.ToDoes", new[] { "categoryId" });
            RenameColumn(table: "dbo.ToDoes", name: "categoryId", newName: "Category_CategoryId");
            AlterColumn("dbo.ToDoes", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.ToDoes", "Category_CategoryId");
            AddForeignKey("dbo.ToDoes", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoes", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.ToDoes", new[] { "Category_CategoryId" });
            AlterColumn("dbo.ToDoes", "Category_CategoryId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ToDoes", name: "Category_CategoryId", newName: "categoryId");
            CreateIndex("dbo.ToDoes", "categoryId");
            AddForeignKey("dbo.ToDoes", "categoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
