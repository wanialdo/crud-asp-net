using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entidade
{
    public class ContatoFornecedor
    {
        [Key]
        [DisplayName("#")]
        [Column("contato_fornecedor_id")]
        public int ID { get; set; }

        [DisplayName("Nome do Contato")]
        [Column("nome")]
        public string Nome { get; set; }

        [DisplayName("Telefone")]
        [Column("telefone")]
        public string Telefone { get; set; }

        [DisplayName("Fornecedor")]
        [Column("fornecedor_id")]
        public int FornecedorID { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
