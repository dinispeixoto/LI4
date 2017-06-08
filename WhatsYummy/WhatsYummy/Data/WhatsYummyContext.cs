using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatsYummy.Models;

namespace WhatsYummy.Models
{
    public class WhatsYummyContext : DbContext
    {
        public WhatsYummyContext (DbContextOptions<WhatsYummyContext> options)
            : base(options)
        {
        }

        public Utilizador LoggedUser { get; set; }

        public DbSet<WhatsYummy.Models.Utilizador> Utilizador { get; set; }

        public DbSet<WhatsYummy.Models.Estabelecimento> Estabelecimento { get; set; }

        public DbSet<WhatsYummy.Models.Produto> Produto { get; set; }

        public DbSet<WhatsYummy.Models.Avaliacao> Avaliacao { get; set; }

        public DbSet<WhatsYummy.Models.Horario> Horario { get; set; }

        public DbSet<WhatsYummy.Models.Preferencia> Preferencia { get; set; }

        public DbSet<WhatsYummy.Models.ProdutoTag> ProdutoTag { get; set; }

        public DbSet<WhatsYummy.Models.Tag> Tag { get; set; }

        public DbSet<WhatsYummy.Models.UtilizadorProduto> UtilizadorProduto { get; set; }
    }
}
