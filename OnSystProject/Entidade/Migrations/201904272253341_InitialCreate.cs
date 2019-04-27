namespace Entidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.clientes",
                c => new
                    {
                        cliente_id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        telefone = c.String(),
                        logradouro = c.String(),
                        numero = c.String(),
                    })
                .PrimaryKey(t => t.cliente_id);
            
            CreateTable(
                "dbo.ContatoFornecedors",
                c => new
                    {
                        contato_fornecedor_id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        telefone = c.String(),
                        fornecedor_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.contato_fornecedor_id)
                .ForeignKey("dbo.fornecedores", t => t.fornecedor_id, cascadeDelete: true)
                .Index(t => t.fornecedor_id);
            
            CreateTable(
                "dbo.fornecedores",
                c => new
                    {
                        fornecedor_id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        telefone = c.String(),
                        logradouro = c.String(),
                        numero = c.String(),
                    })
                .PrimaryKey(t => t.fornecedor_id);
            
            CreateTable(
                "dbo.ItemPropostas",
                c => new
                    {
                        item_proposta_id = c.Int(nullable: false, identity: true),
                        descricao = c.String(),
                        quantidade = c.Double(nullable: false),
                        valor = c.Double(nullable: false),
                        proposta_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.item_proposta_id)
                .ForeignKey("dbo.propostas", t => t.proposta_id, cascadeDelete: true)
                .Index(t => t.proposta_id);
            
            CreateTable(
                "dbo.propostas",
                c => new
                    {
                        proposta_id = c.Int(nullable: false, identity: true),
                        cliente_id = c.Int(nullable: false),
                        fornecedor_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.proposta_id)
                .ForeignKey("dbo.clientes", t => t.cliente_id, cascadeDelete: true)
                .ForeignKey("dbo.fornecedores", t => t.fornecedor_id, cascadeDelete: true)
                .Index(t => t.cliente_id)
                .Index(t => t.fornecedor_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPropostas", "proposta_id", "dbo.propostas");
            DropForeignKey("dbo.propostas", "fornecedor_id", "dbo.fornecedores");
            DropForeignKey("dbo.propostas", "cliente_id", "dbo.clientes");
            DropForeignKey("dbo.ContatoFornecedors", "fornecedor_id", "dbo.fornecedores");
            DropIndex("dbo.propostas", new[] { "fornecedor_id" });
            DropIndex("dbo.propostas", new[] { "cliente_id" });
            DropIndex("dbo.ItemPropostas", new[] { "proposta_id" });
            DropIndex("dbo.ContatoFornecedors", new[] { "fornecedor_id" });
            DropTable("dbo.propostas");
            DropTable("dbo.ItemPropostas");
            DropTable("dbo.fornecedores");
            DropTable("dbo.ContatoFornecedors");
            DropTable("dbo.clientes");
        }
    }
}
