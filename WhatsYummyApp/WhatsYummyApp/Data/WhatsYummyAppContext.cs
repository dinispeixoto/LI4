using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhatsYummyApp.Models;

namespace WhatsYummyApp.Models
{
    public class WhatsYummyAppContext : DbContext
    {
        public WhatsYummyAppContext (DbContextOptions<WhatsYummyAppContext> options)
            : base(options)
        {
        }

        public DbSet<WhatsYummyApp.Models.Estabelecimento> Estabelecimento { get; set; }

        public DbSet<WhatsYummyApp.Models.Produto> Produto { get; set; }
    }
}
