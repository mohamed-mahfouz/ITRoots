namespace ITRoots.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivatedColumnToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsActivated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsActivated");
        }
    }
}
