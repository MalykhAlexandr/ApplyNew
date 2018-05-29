namespace F.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbApplyRequests",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Filled = c.DateTime(nullable: false),
                    FullName = c.String(),
                    Age = c.Int(nullable: false, identity: true),
                    AgeStartCareer = c.Int(nullable: false, identity: true),
                    ExperienceInFootball = c.Int(nullable: false, identity: true),
                    DbRideRequest_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            //DropForeignKey("DbRideRequest_Id", "dbo.DbRideRequests");
            //DropForeignKey("dbo.DbWayPoints", "DbRideRequest_Id", "dbo.DbRideRequests");
            //DropIndex("dbo.DbWayPoints", new[] { "DbRideRequest_Id" });
            //DropTable("dbo.DbWayPoints");
            DropTable("dbo.DbApplyRequests");
        }
    }
}