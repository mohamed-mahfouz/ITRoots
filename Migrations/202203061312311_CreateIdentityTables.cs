namespace ITRoots.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIdentityTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleName = c.String(),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id)
                .Index(t => t.UserRole_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        UserRole_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_Id)
                .Index(t => t.UserRole_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles");
            DropForeignKey("dbo.Roles", "UserRole_Id", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_Id" });
            DropIndex("dbo.Roles", new[] { "UserRole_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
