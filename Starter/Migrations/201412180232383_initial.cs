namespace Starter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeetingRoomCapabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeetingRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeetingRoomMeetingRoomCapabilities",
                c => new
                    {
                        MeetingRoom_Id = c.Int(nullable: false),
                        MeetingRoomCapabilities_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MeetingRoom_Id, t.MeetingRoomCapabilities_Id })
                .ForeignKey("dbo.MeetingRooms", t => t.MeetingRoom_Id, cascadeDelete: true)
                .ForeignKey("dbo.MeetingRoomCapabilities", t => t.MeetingRoomCapabilities_Id, cascadeDelete: true)
                .Index(t => t.MeetingRoom_Id)
                .Index(t => t.MeetingRoomCapabilities_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetingRoomMeetingRoomCapabilities", "MeetingRoomCapabilities_Id", "dbo.MeetingRoomCapabilities");
            DropForeignKey("dbo.MeetingRoomMeetingRoomCapabilities", "MeetingRoom_Id", "dbo.MeetingRooms");
            DropIndex("dbo.MeetingRoomMeetingRoomCapabilities", new[] { "MeetingRoomCapabilities_Id" });
            DropIndex("dbo.MeetingRoomMeetingRoomCapabilities", new[] { "MeetingRoom_Id" });
            DropTable("dbo.MeetingRoomMeetingRoomCapabilities");
            DropTable("dbo.MeetingRooms");
            DropTable("dbo.MeetingRoomCapabilities");
        }
    }
}
