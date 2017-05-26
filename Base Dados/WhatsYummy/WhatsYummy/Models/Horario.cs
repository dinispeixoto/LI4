using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummy.Models
{
    [Table("Horario")]
    public class Horario
    {
		[Key]
		public int dia { get; set; }

        [Required]
        [ForeignKey("Estabelecimento")]
        public int estabelecimentoid { get; set; }
        public Estabelecimento estabelecimento { get; set; }

        [Required]
        public DateTime horaAbertura { get; set; }
        [Required]
        public DateTime horaFecho { get; set; }

    }
}
