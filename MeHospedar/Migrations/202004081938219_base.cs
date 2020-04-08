namespace MeHospedar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _base : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Viajantes", "Telefone"); 
        }
        
        public override void Down()
        {
            AddColumn("dbo.Viajantes", "Telefone", c => c.String());
        }
    }
}
