using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummy.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        [Key]
        public int id { get; set; }

        [Required]
        [ForeignKey("Utilizador")]
        public int utilizadorid { get; set; }
        public Utilizador utilizador { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int produtoid { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int estabelecimentoid { get; set; }

		public Produto produto { get; set; }

        [Required]
        public float classificacao { get; set; }

        public String comentario { get; set; }
        public String foto { get; set; }

    }
}
