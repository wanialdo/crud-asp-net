using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Entidade
{
    [Table("ItemPropostas")]
    public class ItemProposta
    {
        [Key]
        [DisplayName("#")]
        [Column("item_proposta_id")]
        public int ID { get; set; }

        [DisplayName("Descrição")]
        [Column("descricao")]
        public string Descrição { get; set; }

        [DisplayName("Quantidade")]
        [Column("quantidade")]
        public double Quantidade { get; set; }

        [DisplayName("Valor")]
        [Column("valor")]
        public double Valor { get; set; }

        [DisplayName("Total")]
        [NotMapped]
        public double Total
        {
            get { return this.Quantidade * this.Valor; }
        }

        [DisplayName("Proposta")]
        [Column("proposta_id")]
        public int PropostaID { get; set; }

        [DisplayName("Proposta")]
        public Proposta Proposta { get; set; }
    }
}
