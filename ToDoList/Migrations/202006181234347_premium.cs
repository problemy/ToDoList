namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class premium : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Premium", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Premium");
        }
    }
}
