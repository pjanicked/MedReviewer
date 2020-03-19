namespace MedReviewer.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ReviewTitle = c.String(nullable: false, maxLength: 30, unicode: false),
                        ReviewRating = c.Double(nullable: false),
                        ReviewPros = c.String(maxLength: 200, unicode: false),
                        ReviewCons = c.String(maxLength: 200, unicode: false),
                        ReviewCreatedDate = c.DateTime(),
                        ReviewUpdatedDate = c.DateTime(),
                        ReviewCreatedBy = c.Int(nullable: false),
                        ReviewUpdatedBy = c.Int(nullable: false),
                        PillboxMedicineId = c.Int(nullable: false),
                        PillboxMedicineName = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(nullable: false, maxLength: 30, unicode: false),
                        OktaUserId = c.Double(nullable: false),
                        UserCreatedDate = c.DateTime(),
                        UserUpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
        }
    }
}
