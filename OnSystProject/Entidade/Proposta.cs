using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entidade
{
    [Table("propostas")]
    public class Proposta
    {
        [Key]
        [Column("proposta_id")]
        public int ID { get; set; }

        [Column("cliente_id")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        [Column("fornecedor_id")]
        public int FornecedorID { get; set; }
        public Fornecedor Fornecedores { get; set; }

        public IList<ItemProposta> Itens { get; set; }
    }
}