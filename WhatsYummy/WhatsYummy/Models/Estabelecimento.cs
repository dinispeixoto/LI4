using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummyClassLibrary.Models
{
    //[Table("Estabelecimento")]
    public class Estabelecimento
    {
        [Key]
        public int id { get; set; }
        public String descricao { get; set; }
        public String nome { get; set; }
        public String localidade { get; set; }
        public String codigoPostal { get; set; }
        public String rua { get; set; }

        [ForeignKey("Utilizador")]
        public int proprietario { get; set; }
        public int estado { get; set; }
        public int numProdutos { get; set; }

		public virtual ICollection<Produto> menu { get; set; }
		public virtual ICollection<Horario> horario { get; set; }

	}
}
