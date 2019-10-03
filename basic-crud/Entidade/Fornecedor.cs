using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entidade
{
    [Table("fornecedores")]
    public class Fornecedor
    {
        [Key]
        [DisplayName("#")]
        [Column("fornecedor_id")]
        public int ID { get; set; }

        [DisplayName("Nome do Fornecedor")]
        [Column("nome")]
        public string Nome { get; set; }

        [DisplayName("Telefone")]
        [Column("telefone")]
        public string Telefone { get; set; }

        [DisplayName("Logradouro")]
        [Column("logradouro")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        [Column("numero")]
        public string Numero { get; set; }

        public IList<ContatoFornecedor> Contatos { get; set; }
    }
}