using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummyClassLibrary.Models
{
    //[Table("Horario")]
    public class Horario
    {
		[Key]
		public int dia { get; set; }
        [ForeignKey("Estabelecimento")]
        public int Estabelecimento { get; set; }
        public DateTime horaAbertura { get; set; }
        public DateTime horaFecho { get; set; }

    }
}
