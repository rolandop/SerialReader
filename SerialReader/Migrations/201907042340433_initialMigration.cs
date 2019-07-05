namespace SerialReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BalanceDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        OriginalData = c.String(),
                        WorkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalanceWorks", t => t.WorkId, cascadeDelete: true)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.BalanceWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BalanceDatas", "WorkId", "dbo.BalanceWorks");
            DropIndex("dbo.BalanceDatas", new[] { "WorkId" });
            DropTable("dbo.BalanceWorks");
            DropTable("dbo.BalanceDatas");
        }
    }
}
