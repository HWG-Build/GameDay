namespace Data.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Event", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Date", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Event", "DateTime");
        }
    }
}
