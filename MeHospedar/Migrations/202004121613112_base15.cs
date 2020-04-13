namespace MeHospedar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CafeDaManhas",
                c => new
                    {
                        CafeDaManhaId = c.Guid(nullable: false),
                        Tipo = c.String(),
                        Valor = c.Single(nullable: false),
                        Hotel_HotelId = c.Guid(),
                    })
                .PrimaryKey(t => t.CafeDaManhaId)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId)
                .Index(t => t.Hotel_HotelId);
            
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        CidadeId = c.Guid(nullable: false),
                        NomeCidade = c.String(),
                        Estado_EstadoId = c.Guid(),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estadoes", t => t.Estado_EstadoId)
                .Index(t => t.Estado_EstadoId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        EstadoId = c.Guid(nullable: false),
                        UF = c.String(),
                        NomeEstado = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        EnderecoId = c.Guid(nullable: false),
                        Rua = c.String(),
                        Bairro = c.String(),
                        Cep = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Cidade_CidadeId = c.Guid(),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Cidades", t => t.Cidade_CidadeId)
                .Index(t => t.Cidade_CidadeId);
            
            CreateTable(
                "dbo.Estruturas",
                c => new
                    {
                        EstruturaId = c.Guid(nullable: false),
                        InternetId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EstruturaId)
                .ForeignKey("dbo.Internets", t => t.InternetId, cascadeDelete: true)
                .Index(t => t.InternetId);
            
            CreateTable(
                "dbo.Internets",
                c => new
                    {
                        InternetId = c.Guid(nullable: false),
                        Valor = c.Single(nullable: false),
                        Tipo = c.String(),
                        Abrangencia = c.String(),
                    })
                .PrimaryKey(t => t.InternetId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Guid(nullable: false),
                        Nome = c.String(),
                        NomeContato = c.String(),
                        Telefone = c.String(),
                        Estrelas = c.Int(nullable: false),
                        EnderecoId = c.Guid(nullable: false),
                        EstruturaId = c.Guid(nullable: false),
                        IdiomaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.Enderecoes", t => t.EnderecoId, cascadeDelete: true)
                .ForeignKey("dbo.Estruturas", t => t.EstruturaId, cascadeDelete: true)
                .ForeignKey("dbo.Idiomas", t => t.IdiomaId, cascadeDelete: true)
                .Index(t => t.EnderecoId)
                .Index(t => t.EstruturaId)
                .Index(t => t.IdiomaId);
            
            CreateTable(
                "dbo.Idiomas",
                c => new
                    {
                        IdiomaId = c.Guid(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.IdiomaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hotels", "IdiomaId", "dbo.Idiomas");
            DropForeignKey("dbo.Hotels", "EstruturaId", "dbo.Estruturas");
            DropForeignKey("dbo.Hotels", "EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.CafeDaManhas", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Estruturas", "InternetId", "dbo.Internets");
            DropForeignKey("dbo.Enderecoes", "Cidade_CidadeId", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "Estado_EstadoId", "dbo.Estadoes");
            DropIndex("dbo.Hotels", new[] { "IdiomaId" });
            DropIndex("dbo.Hotels", new[] { "EstruturaId" });
            DropIndex("dbo.Hotels", new[] { "EnderecoId" });
            DropIndex("dbo.Estruturas", new[] { "InternetId" });
            DropIndex("dbo.Enderecoes", new[] { "Cidade_CidadeId" });
            DropIndex("dbo.Cidades", new[] { "Estado_EstadoId" });
            DropIndex("dbo.CafeDaManhas", new[] { "Hotel_HotelId" });
            DropTable("dbo.Idiomas");
            DropTable("dbo.Hotels");
            DropTable("dbo.Internets");
            DropTable("dbo.Estruturas");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Cidades");
            DropTable("dbo.CafeDaManhas");
        }
    }
}
