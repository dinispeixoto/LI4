using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummy.Models
{
    [Table("ProdutoTag")]
    public class ProdutoTag
    {
        public int Id { get; set; }
		//[ForeignKey("Produto")]
		//public int Produtoid { get; set; }
        public Produto Produto { get; set; }
		
        //[Required]
        //[ForeignKey("Produto")]
		//public int Estabelecimentoid { get; set; }

		//[ForeignKey("Tag")]
		//public int Tagid { get; set; }
		public Tag Tag { get; set; }

        public ProdutoTag()
        {
        }
    }
}