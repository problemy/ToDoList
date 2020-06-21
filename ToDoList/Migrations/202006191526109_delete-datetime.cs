namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedatetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
