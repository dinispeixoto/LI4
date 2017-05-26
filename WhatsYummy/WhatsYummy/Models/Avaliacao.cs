using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummyClassLibrary.Models
{
    //[Table("Avaliacao")]
    public class Avaliacao
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Utilizador")]
        public int Utilizador { get; set; }
        [ForeignKey("Produto")]
        public int Produto { get; set; }
        [ForeignKey("Estabelecimento")]
        public int Estabelecimento { get; set; }
        public float classificacao { get; set; }
        public String comentario { get; set; }
        public String foto { get; set; }

    }
}
