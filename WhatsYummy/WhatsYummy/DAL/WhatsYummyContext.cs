using System;
using Microsoft.EntityFrameworkCore;

namespace WhatsYummyClassLibrary.DAL
{
    public class WhatsYummyContext : DbContext{

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=WhatsYummy;Trusted_Connection=True;");
		}


		/*public WhatsYummyContext(DbContextOptions<WhatsYummyContext> options)
            : base(options)
        { 
        }*/

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Blog>(entity =>
			{
				entity.Property(e => e.Url).IsRequired();
			});

			modelBuilder.Entity<Post>(entity =>
			{
				entity.HasOne(d => d.Blog)
					.WithMany(p => p.Post)
					.HasForeignKey(d => d.BlogId);
			});
		}

    }
}
