namespace MeHospedar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viajantes", "ImagemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Viajantes", "ImagemId");
            AddForeignKey("dbo.Viajantes", "ImagemId", "dbo.Imagems", "ImagemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viajantes", "ImagemId", "dbo.Imagems");
            DropIndex("dbo.Viajantes", new[] { "ImagemId" });
            DropColumn("dbo.Viajantes", "ImagemId");
        }
    }
}
