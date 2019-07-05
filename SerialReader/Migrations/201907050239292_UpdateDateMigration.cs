namespace SerialReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BalanceDatas", "UpdateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BalanceDatas", "UpdateDate");
        }
    }
}
