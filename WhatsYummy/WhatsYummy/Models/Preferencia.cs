using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsYummy.Models
{
	[Table("Preferencia")]
    public class Preferencia
    {
        public int Id { get; set; }
        //[ForeignKey("Utilizador")]
        //[Column("Utilizador")]
        //public int Utilizadorid { get; set; }
        public Utilizador Utilizador { get; set; }

       
        //[ForeignKey("Tag")]
        //[Column("Tag")]
        //public int Tagid { get; set; }
        public Tag Tag { get; set; }

        public Preferencia()
        {
        }
    }
}