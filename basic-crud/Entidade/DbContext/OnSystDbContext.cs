using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class OnSystDbContext : DbContext
    {
        public OnSystDbContext()
            : base("name=DbContextConnection")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContatoFornecedor> ContatosFornecedor { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ItemProposta> ItensPropostas { get; set; }
        public DbSet<Proposta> Propostas { get; set; }
    }
}
