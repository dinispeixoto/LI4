using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummy.Models
{
    [Table("UtilizadorProduto")]
    public class UtilizadorProduto
    {
        public int Id { get; set; }   
		//[Key, ForeignKey("Utilizador")]
		//public int Utilizadorid { get; set; }
		public Utilizador Utilizador { get; set; }

		//[Key, ForeignKey("Produto")]
		//[Column(Order = 1)]
		//public int Produtoid { get; set; }

		//[Key, ForeignKey("Produto")]
		//[Column(Order = 2)]
		//public int Estabelecimentoid { get; set; }

		public Produto Produto { get; set; }

        public int Favorito { get; set; }

        public UtilizadorProduto()
        {
        }
    }
}