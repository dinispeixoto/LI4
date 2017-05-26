using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummyClassLibrary.Models
{  
    [Table("Tag")]
    public class Tag 
    {
        [Key]
        public int id { get; set; }
        public String tipo { get; set; }
        public String nome { get; set; }

		public virtual ICollection<Preferencia> preferencias { get; set; }
		public virtual ICollection<ProdutoTag> produtos { get; set; }

	}
}
