namespace SampleProjectBootStrap.DAL.JobMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Phone = c.Long(nullable: false),
                        Email = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Email, unique: true, name: "IX_Unique_Applicant_email");
            
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostingID = c.Int(nullable: false),
                        ApplicantID = c.Int(nullable: false),
                        FileStoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Applicant", t => t.ApplicantID)
                .ForeignKey("dbo.FileStore", t => t.FileStoreID)
                .ForeignKey("dbo.Posting", t => t.PostingID)
                .Index(t => t.PostingID, unique: true, name: "IX_Unique_Posting")
                .Index(t => t.ApplicantID, name: "IX_Unique_Applicant")
                .Index(t => t.FileStoreID, name: "IX_Unique_FileStore");
            
            CreateTable(
                "dbo.FileStore",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileContent = c.String(nullable: false, maxLength: 256),
                        FileMemeType = c.String(nullable: false, maxLength: 256),
                        FileName = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posting",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ClosingDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(),
                        PositionID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.DepartmentID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .ForeignKey("dbo.Position", t => t.PositionID)
                .Index(t => t.PositionID)
                .Index(t => t.LocationID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.City", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 255),
                        ProvinceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Province", t => t.ProvinceID)
                .Index(t => t.ProvinceID);
            
            CreateTable(
                "dbo.Province",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OccupationID = c.Int(nullable: false),
                        FTEID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FTE", t => t.FTEID)
                .ForeignKey("dbo.Occupation", t => t.OccupationID)
                .Index(t => t.OccupationID)
                .Index(t => t.FTEID);
            
            CreateTable(
                "dbo.FTE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FTEType = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Compensation", t => t.CompensationID)
                .ForeignKey("dbo.JobCode", t => t.JobCodeID)
                .Index(t => t.CompensationID)
                .Index(t => t.JobCodeID);
            
            CreateTable(
                "dbo.Compensation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompensationType = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobCode",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Position_Qualification",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PositionID = c.Int(nullable: false),
                        QualificationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Position", t => t.PositionID)
                .ForeignKey("dbo.Qualification", t => t.QualificationID)
                .Index(t => new { t.PositionID, t.QualificationID }, unique: true, name: "IX_Unique_Position_Qualification");
            
            CreateTable(
                "dbo.Qualification",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QualificationName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posting", "PositionID", "dbo.Position");
            DropForeignKey("dbo.Position_Qualification", "QualificationID", "dbo.Qualification");
            DropForeignKey("dbo.Position_Qualification", "PositionID", "dbo.Position");
            DropForeignKey("dbo.Position", "OccupationID", "dbo.Occupation");
            DropForeignKey("dbo.Occupation", "JobCodeID", "dbo.JobCode");
            DropForeignKey("dbo.Occupation", "CompensationID", "dbo.Compensation");
            DropForeignKey("dbo.Position", "FTEID", "dbo.FTE");
            DropForeignKey("dbo.Posting", "LocationID", "dbo.Location");
            DropForeignKey("dbo.City", "ProvinceID", "dbo.Province");
            DropForeignKey("dbo.Location", "CityID", "dbo.City");
            DropForeignKey("dbo.Posting", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Application", "PostingID", "dbo.Posting");
            DropForeignKey("dbo.Application", "FileStoreID", "dbo.FileStore");
            DropForeignKey("dbo.Application", "ApplicantID", "dbo.Applicant");
            DropIndex("dbo.Position_Qualification", "IX_Unique_Position_Qualification");
            DropIndex("dbo.Occupation", new[] { "JobCodeID" });
            DropIndex("dbo.Occupation", new[] { "CompensationID" });
            DropIndex("dbo.Position", new[] { "FTEID" });
            DropIndex("dbo.Position", new[] { "OccupationID" });
            DropIndex("dbo.City", new[] { "ProvinceID" });
            DropIndex("dbo.Location", new[] { "CityID" });
            DropIndex("dbo.Posting", new[] { "DepartmentID" });
            DropIndex("dbo.Posting", new[] { "LocationID" });
            DropIndex("dbo.Posting", new[] { "PositionID" });
            DropIndex("dbo.Application", "IX_Unique_FileStore");
            DropIndex("dbo.Application", "IX_Unique_Applicant");
            DropIndex("dbo.Application", "IX_Unique_Posting");
            DropIndex("dbo.Applicant", "IX_Unique_Applicant_email");
            DropTable("dbo.Qualification");
            DropTable("dbo.Position_Qualification");
            DropTable("dbo.JobCode");
            DropTable("dbo.Compensation");
            DropTable("dbo.Occupation");
            DropTable("dbo.FTE");
            DropTable("dbo.Position");
            DropTable("dbo.Province");
            DropTable("dbo.City");
            DropTable("dbo.Location");
            DropTable("dbo.Department");
            DropTable("dbo.Posting");
            DropTable("dbo.FileStore");
            DropTable("dbo.Application");
            DropTable("dbo.Applicant");
        }
    }
}
