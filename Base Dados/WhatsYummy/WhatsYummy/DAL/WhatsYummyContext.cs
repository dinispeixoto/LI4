using System;
using Microsoft.EntityFrameworkCore;
using WhatsYummy.Models;
                         
namespace WhatsYummy.DAL
{
    public class WhatsYummyContext : DbContext{

        private string connectionString;
        public DbSet<Utilizador> Utilizadores { get; set; }
		public DbSet<Estabelecimento> Estabelecimentos { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Avaliacao> Avalicoes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Preferencia> preferencias { get; set; }
        public DbSet<ProdutoTag> prodTags { get; set; }
        public DbSet<UtilizadorProduto> utilizadorPord { get; set; }



		public WhatsYummyContext(string connect){
            this.connectionString = connect;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer(this.connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Preferencia>()
				.HasKey(c => new { c.utilizadorid, c.tagid });

			modelBuilder.Entity<Produto>()
				.HasKey(c => new { c.estabelecimentoid, c.id });

			modelBuilder.Entity<ProdutoTag>()
				.HasKey(c => new { c.estabelecimentoid, c.produtoid, c.tagid });

			modelBuilder.Entity<UtilizadorProduto>()
				.HasKey(c => new { c.estabelecimentoid, c.produtoid, c.utilizadorid });
		}
    }
}
