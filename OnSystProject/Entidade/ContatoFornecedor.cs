using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entidade
{
    public class ContatoFornecedor
    {
        [Key]
        [Column("contato_fornecedor_id")]
        public int ID { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("fornecedor_id")]
        public int FornecedorID { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
