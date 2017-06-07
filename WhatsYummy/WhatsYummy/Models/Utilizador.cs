using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace WhatsYummy.Models
{
    [Table("Utilizador")]
    public class Utilizador
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        [Required]
        public String Email { get; set; }
        //[Required]
        public String DataNascimento { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Username { get; set; }
        public String Foto { get; set; }
        public int Admin { get; set; }

        public virtual ICollection<Preferencia> Preferencias { get; set; }
        public virtual ICollection<Avaliacao> Visitas { get; set; }
        public virtual ICollection<UtilizadorProduto> Favoritos { get; set; }

        public Utilizador()
        {
        }
    }
}
