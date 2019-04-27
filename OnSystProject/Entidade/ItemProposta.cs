using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entidade
{
    public class ItemProposta
    {
        [Key]
        [Column("item_proposta_id")]
        public int ID { get; set; }

        [Column("descricao")]
        public string Descrição { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }

        [Column("valor")]
        public double Valor { get; set; }

        [NotMapped]
        public double Total
        {
            get { return this.Quantidade * this.Valor; }
        }

        [Column("proposta_id")]
        public int PropostaID { get; set; }
        public Proposta Proposta { get; set; }
    }
}
