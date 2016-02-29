namespace Data.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireEventFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Event", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Event", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Event", "Time", c => c.String());
            AlterColumn("dbo.Event", "Date", c => c.String());
            AlterColumn("dbo.Event", "Name", c => c.String());
        }
    }
}
