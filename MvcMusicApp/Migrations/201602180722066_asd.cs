namespace MvcMusicApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Albumid = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Albumid);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Songid = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        length = c.Int(nullable: false),
                        Album_Albumid = c.Int(),
                    })
                .PrimaryKey(t => t.Songid)
                .ForeignKey("dbo.Albums", t => t.Album_Albumid)
                .Index(t => t.Album_Albumid);
            
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.MyUserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "HomeTown", c => c.String());
            AddColumn("dbo.AspNetUsers", "MyUserInfo_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "MyUserInfo_Id");
            AddForeignKey("dbo.AspNetUsers", "MyUserInfo_Id", "dbo.MyUserInfoes", "Id");
            DropColumn("dbo.AspNetUsers", "MiddleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MiddleName", c => c.String());
            DropForeignKey("dbo.ToDoes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "MyUserInfo_Id", "dbo.MyUserInfoes");
            DropForeignKey("dbo.Songs", "Album_Albumid", "dbo.Albums");
            DropIndex("dbo.ToDoes", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "MyUserInfo_Id" });
            DropIndex("dbo.Songs", new[] { "Album_Albumid" });
            DropColumn("dbo.AspNetUsers", "MyUserInfo_Id");
            DropColumn("dbo.AspNetUsers", "HomeTown");
            DropTable("dbo.MyUserInfoes");
            DropTable("dbo.ToDoes");
            DropTable("dbo.Songs");
            DropTable("dbo.Albums");
        }
    }
}
