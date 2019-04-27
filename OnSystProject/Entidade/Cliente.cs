using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entidade
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DisplayName("#")]
        [Column("cliente_id")]
        public int ID { get; set; }

        [DisplayName("Nome do Cliente")]
        [Column("nome")]
        public string Nome { get; set; }

        [DisplayName("Telefone de Contato")]
        [Column("telefone")]
        public string Telefone { get; set; }

        [DisplayName("Logradouro")]
        [Column("logradouro")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        [Column("numero")]
        public string Numero { get; set; }
    }
}