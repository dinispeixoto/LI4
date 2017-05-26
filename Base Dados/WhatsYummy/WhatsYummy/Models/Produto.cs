using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhatsYummy.Models
{
    [Table("Produto")]
    public class Produto
    {
        public int id { get; set; }

        [Required]
        [ForeignKey("Estabelecimento")]
        public int estabelecimentoid { get; set; }
        public Estabelecimento estabelecimento { get; set; }

        [Required]
        public String nome { get; set; }
        [Required]
        public String descricao { get; set; }
        [Required]
        public float preco { get; set; }
        [Required]
        public int visitas { get; set; }

        public String foto { get; set; }

        public virtual ICollection<Avaliacao> avaliacoes { get; set; }
        public virtual ICollection<ProdutoTag> tags { get; set; }

    }
}
