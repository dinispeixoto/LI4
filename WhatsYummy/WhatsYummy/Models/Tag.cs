using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummy.Models
{  
    [Table("Tag")]
    public class Tag 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Tipo { get; set; }
        [Required]
        public String Nome { get; set; }

		public virtual ICollection<Preferencia> Preferencias { get; set; }
		public virtual ICollection<ProdutoTag> Produtos { get; set; }

        public Tag()
        {
        }
	}
}
