namespace Data.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlayerToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "PlayersAttending", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "PlayersAttending");
        }
    }
}
