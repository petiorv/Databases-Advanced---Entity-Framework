namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enums : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Homework", "ContentType", c => c.Int(nullable: false));
            AlterColumn("dbo.Resources", "ResourceType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resources", "ResourceType", c => c.String(nullable: false));
            AlterColumn("dbo.Homework", "ContentType", c => c.String(nullable: false));
        }
    }
}
