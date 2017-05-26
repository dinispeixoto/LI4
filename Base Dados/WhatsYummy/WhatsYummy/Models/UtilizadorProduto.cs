using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummy.Models
{
    [Table("UtilizadorProduto")]
    public class UtilizadorProduto
    {
        
		[ForeignKey("Utilizador")]
		public int utilizadorid { get; set; }
		public Utilizador utilizador { get; set; }

		[ForeignKey("Produto")]
		[Column(Order = 1)]
		public int produtoid { get; set; }

		[ForeignKey("Produto")]
		[Column(Order = 2)]
		public int estabelecimentoid { get; set; }

		public Produto produto { get; set; }

        public int favorito { get; set; }
    }
}