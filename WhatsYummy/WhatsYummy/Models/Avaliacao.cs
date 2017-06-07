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
        public int Id { get; set; }

        [NotMapped]
        //[ForeignKey("Utilizador")]
        public int Utilizador { get; set; }
        //public Utilizador Utilizador { get; set; }

        //[ForeignKey("Produto")]
        //[Column(Order = 1)]
        [NotMapped]
        public int Produto { get; set; }

        [NotMapped]
        //[ForeignKey("Produto")]
        //[Column(Order = 2)]
        public int Estabelecimento { get; set; }

		//public Produto Produto { get; set; }


        [Required]
        public float Classificacao { get; set; }
        [Required]
        public String Comentario { get; set; }
        [Required]
        public String Foto { get; set; }

        public Avaliacao()
        {
        }
    }
}
