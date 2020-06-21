namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryId3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ToDoes", new[] { "categoryId" });
            CreateIndex("dbo.ToDoes", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ToDoes", new[] { "CategoryId" });
            CreateIndex("dbo.ToDoes", "categoryId");
        }
    }
}
