namespace ProjetoAdlinMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeEmpresa = c.String(),
                        Cnpj = c.String(),
                        Cidade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LojaVirtuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeLoja = c.String(),
                        Cnpj = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        TipoProduto = c.String(),
                        Preco = c.Single(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedors", t => t.FornecedorId, cascadeDelete: true)
                .Index(t => t.FornecedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "FornecedorId", "dbo.Fornecedors");
            DropIndex("dbo.Produtoes", new[] { "FornecedorId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.LojaVirtuals");
            DropTable("dbo.Fornecedors");
            DropTable("dbo.Clientes");
        }
    }
}
