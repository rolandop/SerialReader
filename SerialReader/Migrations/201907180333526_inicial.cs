namespace SerialReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "BalanceDatas",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        OriginalData = c.String(),
                        Weight = c.Single(nullable: false),
                        WorkId = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("BalanceWorks", t => t.WorkId, cascadeDelete: true)
                .Index(t => t.WorkId);
            
            CreateTable(
                "BalanceWorks",
                c => new
                    {
                        Id = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Code = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Status = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("BalanceDatas", "WorkId", "BalanceWorks");
            DropIndex("BalanceDatas", new[] { "WorkId" });
            DropTable("BalanceWorks");
            DropTable("BalanceDatas");
        }
    }
}
