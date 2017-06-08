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
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Estabelecimento")]
        [NotMapped]
        public int Estabelecimento { get; set; }
        //public Estabelecimento Estabelecimento { get; set; }

        [Required]
        public String Nome { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }
        [Required]
        [Display(Name = "Preço")]
        public float Preco { get; set; }
        [NotMapped]
        public int Visitas { get; set; }

        public String Foto { get; set; }

        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
        public virtual ICollection<ProdutoTag> Tags { get; set; }
        
        public Produto()
        {
        }
    }
}
