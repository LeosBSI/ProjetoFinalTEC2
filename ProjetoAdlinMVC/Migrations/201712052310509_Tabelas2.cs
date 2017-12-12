namespace ProjetoAdlinMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabelas2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Clientes", "Cpf", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Fornecedors", "NomeEmpresa", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Fornecedors", "Cnpj", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Fornecedors", "Cidade", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.LojaVirtuals", "NomeLoja", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.LojaVirtuals", "Cnpj", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Produtoes", "Nome", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Produtoes", "TipoProduto", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "TipoProduto", c => c.String());
            AlterColumn("dbo.Produtoes", "Nome", c => c.String());
            AlterColumn("dbo.LojaVirtuals", "Cnpj", c => c.String());
            AlterColumn("dbo.LojaVirtuals", "NomeLoja", c => c.String());
            AlterColumn("dbo.Fornecedors", "Cidade", c => c.String());
            AlterColumn("dbo.Fornecedors", "Cnpj", c => c.String());
            AlterColumn("dbo.Fornecedors", "NomeEmpresa", c => c.String());
            AlterColumn("dbo.Clientes", "Cpf", c => c.String());
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
        }
    }
}
