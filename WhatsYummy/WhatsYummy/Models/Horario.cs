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
		public int Dia { get; set; }

        //[ForeignKey("Estabelecimento")]
        [Column("Estabelecimento")]
        public int Estabelecimento { get; set; }
        //public Estabelecimento Estabelecimento { get; set; }

        [Required]
        [Display(Name = "Hora de abertura")]
        public TimeSpan HoraAbertura { get; set; }
        [Required]
        [Display(Name = "Hora de fecho")]
        public TimeSpan HoraFecho { get; set; }

        public Horario()
        {
        }
    }
}
