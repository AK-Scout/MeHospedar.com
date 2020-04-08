namespace MeHospedar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viajantes", "ImagemId", "dbo.Imagems");
            DropIndex("dbo.Viajantes", new[] { "ImagemId" });
            DropColumn("dbo.Viajantes", "ImagemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Viajantes", "ImagemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Viajantes", "ImagemId");
            AddForeignKey("dbo.Viajantes", "ImagemId", "dbo.Imagems", "ImagemId", cascadeDelete: true);
        }
    }
}
