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
        public int id { get; set; }
        [Required]
        public String tipo { get; set; }
        [Required]
        public String nome { get; set; }

		public virtual ICollection<Preferencia> preferencias { get; set; }
		public virtual ICollection<ProdutoTag> produtos { get; set; }

	}
}
