namespace Entidade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropostaUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemPropostas", "proposta_id", "dbo.propostas");
            DropPrimaryKey("dbo.propostas");
            AddColumn("dbo.propostas", "numero_proposta", c => c.Int(nullable: false));
            AlterColumn("dbo.propostas", "proposta_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.propostas", "proposta_id");
            AddForeignKey("dbo.ItemPropostas", "proposta_id", "dbo.propostas", "proposta_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPropostas", "proposta_id", "dbo.propostas");
            DropPrimaryKey("dbo.propostas");
            AlterColumn("dbo.propostas", "proposta_id", c => c.Int(nullable: false));
            DropColumn("dbo.propostas", "numero_proposta");
            AddPrimaryKey("dbo.propostas", "proposta_id");
            AddForeignKey("dbo.ItemPropostas", "proposta_id", "dbo.propostas", "proposta_id", cascadeDelete: true);
        }
    }
}
