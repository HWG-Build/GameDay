namespace Data.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsFieldToEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "Comments");
        }
    }
}
