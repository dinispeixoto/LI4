using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummy.Models
{
    [Table("Utilizador")]
    public class Utilizador
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public String dataNascimento { get; set; }
        [Required]
        public String nome { get; set; }
        [Required]
        public String password { get; set; }
        [Required]
        public String username { get; set; }
        [Required]
        public String foto { get; set; }
        [Required]
        public bool admin { get; set; }

        public virtual ICollection<Preferencia> preferencias { get; set; }
        public virtual ICollection<Avaliacao> visitas { get; set; }
        public virtual ICollection<UtilizadorProduto> favoritos { get; set; }
    }
}
