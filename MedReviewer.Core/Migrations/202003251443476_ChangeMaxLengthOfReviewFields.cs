namespace MedReviewer.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMaxLengthOfReviewFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "ReviewTitle", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Reviews", "ReviewPros", c => c.String(maxLength: 500, unicode: false));
            AlterColumn("dbo.Reviews", "ReviewCons", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "ReviewCons", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Reviews", "ReviewPros", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.Reviews", "ReviewTitle", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
    }
}
