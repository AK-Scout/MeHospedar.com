namespace MeHospedar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotels", "numero");
        }
    }
}
