using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummy.Models
{
    [Table("ProdutoTag")]
    public class ProdutoTag
    {
        [Required]
		[ForeignKey("Produto")]
		public int produtoid { get; set; }
		
        [Required]
        [ForeignKey("Produto")]
		public int estabelecimentoid { get; set; }

		public Produto produto { get; set; }

        [Required]
		[ForeignKey("Tag")]
		public int tagid { get; set; }
		public Tag tag { get; set; }
    }
}