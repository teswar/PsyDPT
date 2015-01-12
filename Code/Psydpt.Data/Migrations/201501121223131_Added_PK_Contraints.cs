namespace Psydpt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_PK_Contraints : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disorders",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Keywords = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PredictionPuntuations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Code = c.String(),
                        Word = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Predictions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DisorderId = c.Guid(nullable: false),
                        PatientId = c.String(maxLength: 128),
                        Symptoms = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disorders", t => t.DisorderId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientId)
                .Index(t => t.DisorderId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.PredictionSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PuntuationIdsToUse = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PatientInfos", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientInfos", "UpdatedOn", c => c.DateTime());
            AddColumn("dbo.PatientSigeCaps", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientSigeCaps", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Predictions", "PatientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Predictions", "DisorderId", "dbo.Disorders");
            DropIndex("dbo.Predictions", new[] { "PatientId" });
            DropIndex("dbo.Predictions", new[] { "DisorderId" });
            DropColumn("dbo.PatientSigeCaps", "UpdatedOn");
            DropColumn("dbo.PatientSigeCaps", "CreatedOn");
            DropColumn("dbo.PatientInfos", "UpdatedOn");
            DropColumn("dbo.PatientInfos", "CreatedOn");
            DropTable("dbo.PredictionSettings");
            DropTable("dbo.Predictions");
            DropTable("dbo.PredictionPuntuations");
            DropTable("dbo.Disorders");
        }
    }
}
