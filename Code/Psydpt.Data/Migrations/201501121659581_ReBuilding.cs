namespace Psydpt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReBuilding : DbMigration
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
                        ExternalInfoUrl = c.String(),
                        Keywords = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Predictions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        DisorderId = c.Guid(nullable: false),
                        PatientId = c.String(nullable: false, maxLength: 128),
                        Symptoms = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disorders", t => t.DisorderId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DisorderId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PatientInfos",
                c => new
                    {
                        PatientInfoId = c.String(nullable: false, maxLength: 128),
                        DateofBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        MatialStatus = c.Int(nullable: false),
                        BloodType = c.Int(nullable: false),
                        NumberOfChildren = c.Int(),
                        DescriptionAboutSelf = c.String(),
                        WeightInKg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HeightInCm = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientInfoId)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientInfoId, cascadeDelete: true)
                .Index(t => t.PatientInfoId);
            
            CreateTable(
                "dbo.PatientSigeCaps",
                c => new
                    {
                        PatientSigeCapId = c.String(nullable: false, maxLength: 128),
                        Sleepiness = c.Int(nullable: false),
                        Interest = c.Int(nullable: false),
                        EnergyLevel = c.Int(nullable: false),
                        Concentration = c.Int(nullable: false),
                        Appetite = c.Int(nullable: false),
                        Agitation = c.Int(nullable: false),
                        GuiltyFeelings = c.Int(nullable: false),
                        SucidalThoughts = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.PatientSigeCapId)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientSigeCapId, cascadeDelete: true)
                .Index(t => t.PatientSigeCapId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.PredictionSettings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        PuntuationIdsToUse = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Predictions", "PatientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PatientSigeCaps", "PatientSigeCapId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PatientInfos", "PatientInfoId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Predictions", "DisorderId", "dbo.Disorders");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.PatientSigeCaps", new[] { "PatientSigeCapId" });
            DropIndex("dbo.PatientInfos", new[] { "PatientInfoId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Predictions", new[] { "PatientId" });
            DropIndex("dbo.Predictions", new[] { "DisorderId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PredictionSettings");
            DropTable("dbo.PredictionPuntuations");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.PatientSigeCaps");
            DropTable("dbo.PatientInfos");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Predictions");
            DropTable("dbo.Disorders");
        }
    }
}
