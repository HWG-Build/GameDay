namespace Domain.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Player", "FullName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "FullName");
        }
    }
}
