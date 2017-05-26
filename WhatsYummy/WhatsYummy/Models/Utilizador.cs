using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummyClassLibrary.Models
{
    [Table("Utilizador")]
    public class Utilizador
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
        public String email { get; set; }
        public String dataNascimento { get; set; }
        public String nome { get; set; }
        public String password { get; set; }
        public String username { get; set; }
        public String foto { get; set; }
        public bool admin { get; set; }

        public virtual ICollection<Preferencia> preferencias { get; set; }
        public virtual ICollection<Avaliacao> visitas { get; set; }
        public virtual ICollection<UtilizadorProduto> favoritos { get; set; }
    }
}
