using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummy.Models
{
    [Table("Estabelecimento")]
    public class Estabelecimento
    {
        [Key]
        public int id { get; set; }
        [Required]
        public String descricao { get; set; }
        [Required]
        public String nome { get; set; }
        [Required]
        public String localidade { get; set; }
        [Required]
        public String codigoPostal { get; set; }
        [Required]
        public String rua { get; set; }

        [Required]
        [ForeignKey("Utilizador")]
        public int utilizadorid { get; set; }
        public Utilizador utilizador { get; set; }

        [Required]
        public int estado { get; set; }
        public int numProdutos { get; set; }

		public virtual ICollection<Produto> menu { get; set; }
		public virtual ICollection<Horario> horario { get; set; }

	}
}
