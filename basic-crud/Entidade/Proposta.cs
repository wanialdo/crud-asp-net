using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("#")]
        [Column("proposta_id")]
        public int ID { get; set; }

        [DisplayName("Número da Proposta")]
        [Column("numero_proposta")]
        public int Numero { get; set; }

        [DisplayName("Cliente")]
        [Column("cliente_id")]
        public int ClienteID { get; set; }

        [DisplayName("Cliente")]
        public Cliente Cliente { get; set; }

        [DisplayName("Fornecedor")]
        [Column("fornecedor_id")]
        public int FornecedorID { get; set; }

        [DisplayName("Fornecedor")]
        public Fornecedor Fornecedores { get; set; }

        [DisplayName("Itens da Proposta")]
        public IList<ItemProposta> Itens { get; set; }
    }
}