namespace ITRoots.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivations", "UserId", "dbo.Users");
            DropIndex("dbo.UserActivations", new[] { "UserId" });
            AlterColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            DropTable("dbo.UserActivations");
        }
    }
}
