using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummy.Models
{
	[Table("Preferencia")]
    public class Preferencia
    {
      
        [ForeignKey("Utilizador")]
        [Column("Utilizador")]
        public int utilizadorid { get; set; }
        public Utilizador utilizador { get; set; }

       
        [ForeignKey("Tag")]
        [Column("Tag")]
        public int tagid { get; set; }
        public Tag tag { get; set; }

    }
}