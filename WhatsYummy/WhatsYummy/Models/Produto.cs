using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummyClassLibrary.Models
{
    //[Table("Produto")]
    public class Produto
    {
        [Key]
		[Column(Order = 1)]
        public int id { get; set; }
        [Key]
        [ForeignKey("Estabelecimento")]
		[Column(Order = 2)]
        public int estabelecimento { get; set; }
        public String nome { get; set; }
        public String descricao { get; set; }
        public float preco { get; set; }
        public int visitas { get; set; }


        public virtual ICollection<Avaliacao> avalicacoes { get; set; }
        public virtual ICollection<ProdutoTag> tags { get; set; }

    }
}
