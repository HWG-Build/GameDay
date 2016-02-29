namespace Data.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Event", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Event", "Date", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Event", "Time", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Address", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Address", "Line1", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Address", "Line2", c => c.String(maxLength: 50));
            AlterColumn("dbo.Address", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Player", "FirstName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Player", "LastName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Player", "Position", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Player", "Phone", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Player", "Phone", c => c.String());
            AlterColumn("dbo.Player", "Position", c => c.String());
            AlterColumn("dbo.Player", "LastName", c => c.String());
            AlterColumn("dbo.Player", "FirstName", c => c.String());
            AlterColumn("dbo.Address", "City", c => c.String());
            AlterColumn("dbo.Address", "Line2", c => c.String());
            AlterColumn("dbo.Address", "Line1", c => c.String());
            AlterColumn("dbo.Address", "Name", c => c.String());
            AlterColumn("dbo.Event", "Time", c => c.String(nullable: false));
            AlterColumn("dbo.Event", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Event", "Name", c => c.String(nullable: false));
        }
    }
}
