namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GigsIdToInt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Gigs");
            AlterColumn("dbo.Gigs", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Gigs", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Gigs");
            AlterColumn("dbo.Gigs", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Gigs", "Id");
        }
    }
}
