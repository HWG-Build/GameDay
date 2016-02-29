namespace Data.Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLog",
                c => new
                    {
                        AuditLogId = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        EventDateUTC = c.DateTime(nullable: false),
                        EventType = c.Int(nullable: false),
                        TypeFullName = c.String(nullable: false, maxLength: 512),
                        RecordId = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.AuditLogId);
            
            CreateTable(
                "dbo.AuditLogDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PropertyName = c.String(nullable: false, maxLength: 256),
                        OriginalValue = c.String(),
                        NewValue = c.String(),
                        AuditLogId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLog", t => t.AuditLogId, cascadeDelete: true)
                .Index(t => t.AuditLogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditLogDetail", "AuditLogId", "dbo.AuditLog");
            DropIndex("dbo.AuditLogDetail", new[] { "AuditLogId" });
            DropTable("dbo.AuditLogDetail");
            DropTable("dbo.AuditLog");
        }
    }
}
