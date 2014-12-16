namespace Psydpt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_SigeCaps : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.PatientSigeCapId)
                .ForeignKey("dbo.AspNetUsers", t => t.PatientSigeCapId, cascadeDelete: true)
                .Index(t => t.PatientSigeCapId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientSigeCaps", "PatientSigeCapId", "dbo.AspNetUsers");
            DropIndex("dbo.PatientSigeCaps", new[] { "PatientSigeCapId" });
            DropTable("dbo.PatientSigeCaps");
        }
    }
}
