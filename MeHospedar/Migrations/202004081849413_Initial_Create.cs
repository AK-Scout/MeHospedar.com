namespace MeHospedar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.Viajantes", "Telefone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viajantes", "Telefone");
        }
    }
}
