namespace Data.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Event", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Time", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
