namespace SerialReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeightMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BalanceDatas", "Weight", c => c.Single(nullable: false));
            AlterColumn("dbo.BalanceWorks", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BalanceWorks", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.BalanceDatas", "Weight");
        }
    }
}
