namespace MedReviewer.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedUserModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "OktaUserName", c => c.String(unicode: false));
            AlterColumn("dbo.Users", "OktaUserId", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "OktaUserId", c => c.Double(nullable: false));
            DropColumn("dbo.Users", "OktaUserName");
        }
    }
}
