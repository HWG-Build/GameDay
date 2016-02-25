namespace Domain.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyAttr : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "Location_ID", "dbo.Address");
            DropIndex("dbo.Event", new[] { "Location_ID" });
            RenameColumn(table: "dbo.Event", name: "Location_ID", newName: "AddressId");
            AlterColumn("dbo.Event", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "AddressId");
            AddForeignKey("dbo.Event", "AddressId", "dbo.Address", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "AddressId", "dbo.Address");
            DropIndex("dbo.Event", new[] { "AddressId" });
            AlterColumn("dbo.Event", "AddressId", c => c.Int());
            RenameColumn(table: "dbo.Event", name: "AddressId", newName: "Location_ID");
            CreateIndex("dbo.Event", "Location_ID");
            AddForeignKey("dbo.Event", "Location_ID", "dbo.Address", "ID");
        }
    }
}
