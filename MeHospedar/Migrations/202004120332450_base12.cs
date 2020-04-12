namespace MeHospedar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base12 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Viajantes");
        }
        
        public override void Down()
        {
        }
    }
}
