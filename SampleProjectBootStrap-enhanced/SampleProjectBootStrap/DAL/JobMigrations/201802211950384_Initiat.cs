namespace SampleProjectBootStrap.DAL.JobMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "CityID", "dbo.City");
            DropForeignKey("dbo.City", "ProvinceID", "dbo.Province");
            DropForeignKey("dbo.Position", "FTEID", "dbo.FTE");
            DropForeignKey("dbo.Occupation", "CompensationID", "dbo.Compensation");
            DropForeignKey("dbo.Occupation", "JobCodeID", "dbo.JobCode");
            DropForeignKey("dbo.Position", "OccupationID", "dbo.Occupation");
            DropIndex("dbo.Location", new[] { "CityID" });
            DropIndex("dbo.City", new[] { "ProvinceID" });
            DropIndex("dbo.Position", new[] { "OccupationID" });
            DropIndex("dbo.Position", new[] { "FTEID" });
            DropIndex("dbo.Occupation", new[] { "CompensationID" });
            DropIndex("dbo.Occupation", new[] { "JobCodeID" });
            AddColumn("dbo.Location", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Location", "CityName", c => c.String(nullable: false, maxLength: 75));
            AddColumn("dbo.Location", "PostalCode", c => c.Int(nullable: false));
            AddColumn("dbo.Position", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Position", "FTEType", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Position", "CompensationID", c => c.Int(nullable: false));
            AddColumn("dbo.Position", "JobCodeID", c => c.Int(nullable: false));
            AddColumn("dbo.Position", "Department_ID", c => c.Int());
            AddColumn("dbo.Position", "Location_ID", c => c.Int());
            AddColumn("dbo.JobCode", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.JobCode", "Description", c => c.String(nullable: false, maxLength: 700));
            CreateIndex("dbo.Position", "CompensationID");
            CreateIndex("dbo.Position", "JobCodeID");
            CreateIndex("dbo.Position", "Department_ID");
            CreateIndex("dbo.Position", "Location_ID");
            AddForeignKey("dbo.Position", "CompensationID", "dbo.Compensation", "ID");
            AddForeignKey("dbo.Position", "Department_ID", "dbo.Department", "ID");
            AddForeignKey("dbo.Position", "JobCodeID", "dbo.JobCode", "ID");
            AddForeignKey("dbo.Position", "Location_ID", "dbo.Location", "ID");
            DropColumn("dbo.Location", "CityID");
            DropColumn("dbo.Position", "OccupationID");
            DropColumn("dbo.Position", "FTEID");
            DropTable("dbo.City");
            DropTable("dbo.Province");
            DropTable("dbo.FTE");
            DropTable("dbo.Occupation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Occupation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 700),
                        CompensationID = c.Int(nullable: false),
                        JobCodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FTE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FTEType = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 255),
                        ProvinceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Position", "FTEID", c => c.Int(nullable: false));
            AddColumn("dbo.Position", "OccupationID", c => c.Int(nullable: false));
            AddColumn("dbo.Location", "CityID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Position", "Location_ID", "dbo.Location");
            DropForeignKey("dbo.Position", "JobCodeID", "dbo.JobCode");
            DropForeignKey("dbo.Position", "Department_ID", "dbo.Department");
            DropForeignKey("dbo.Position", "CompensationID", "dbo.Compensation");
            DropIndex("dbo.Position", new[] { "Location_ID" });
            DropIndex("dbo.Position", new[] { "Department_ID" });
            DropIndex("dbo.Position", new[] { "JobCodeID" });
            DropIndex("dbo.Position", new[] { "CompensationID" });
            DropColumn("dbo.JobCode", "Description");
            DropColumn("dbo.JobCode", "Name");
            DropColumn("dbo.Position", "Location_ID");
            DropColumn("dbo.Position", "Department_ID");
            DropColumn("dbo.Position", "JobCodeID");
            DropColumn("dbo.Position", "CompensationID");
            DropColumn("dbo.Position", "FTEType");
            DropColumn("dbo.Position", "Salary");
            DropColumn("dbo.Location", "PostalCode");
            DropColumn("dbo.Location", "CityName");
            DropColumn("dbo.Location", "Address");
            CreateIndex("dbo.Occupation", "JobCodeID");
            CreateIndex("dbo.Occupation", "CompensationID");
            CreateIndex("dbo.Position", "FTEID");
            CreateIndex("dbo.Position", "OccupationID");
            CreateIndex("dbo.City", "ProvinceID");
            CreateIndex("dbo.Location", "CityID");
            AddForeignKey("dbo.Position", "OccupationID", "dbo.Occupation", "ID");
            AddForeignKey("dbo.Occupation", "JobCodeID", "dbo.JobCode", "ID");
            AddForeignKey("dbo.Occupation", "CompensationID", "dbo.Compensation", "ID");
            AddForeignKey("dbo.Position", "FTEID", "dbo.FTE", "ID");
            AddForeignKey("dbo.City", "ProvinceID", "dbo.Province", "ID");
            AddForeignKey("dbo.Location", "CityID", "dbo.City", "ID");
        }
    }
}
