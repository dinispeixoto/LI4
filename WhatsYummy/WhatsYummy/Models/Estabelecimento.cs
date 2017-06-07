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
        public int Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Localidade { get; set; }
        [Required]
        public String CodigoPostal { get; set; }
        [Required]
        public String Rua { get; set; }

        [NotMapped]
        //[ForeignKey("Utilizador")]
        public int Utilizador { get; set; }
        //public Utilizador Utilizador { get; set; }
        public int Estado { get; set; }
        [NotMapped]
        public int NumProdutos { get; set; }

		public virtual ICollection<Produto> Menu { get; set; }
		public virtual ICollection<Horario> Horario { get; set; }

        public Estabelecimento()
        {
        }
	}
}
