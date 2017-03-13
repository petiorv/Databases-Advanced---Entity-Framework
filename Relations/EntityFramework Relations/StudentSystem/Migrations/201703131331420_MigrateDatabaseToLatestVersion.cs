namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDatabaseToLatestVersion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "PhoneNumber", c => c.Int());
        }
    }
}
