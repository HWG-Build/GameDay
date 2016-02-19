namespace Domain.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventLocation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Event", name: "Address_ID", newName: "Location_ID");
            RenameIndex(table: "dbo.Event", name: "IX_Address_ID", newName: "IX_Location_ID");
            DropColumn("dbo.Event", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Location", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Event", name: "IX_Location_ID", newName: "IX_Address_ID");
            RenameColumn(table: "dbo.Event", name: "Location_ID", newName: "Address_ID");
        }
    }
}
