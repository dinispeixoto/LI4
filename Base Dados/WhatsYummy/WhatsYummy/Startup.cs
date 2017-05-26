using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhatsYummyClassLibrary.DAL;


namespace WhatsYummyClassLibrary
{
    public class Startup
    {
		public void ConfigureServices(IServiceCollection services){
			// Add framework services.
			services.AddMvc();

			var connection = @"Server=localhost;Database=WhatsYummy;Trusted_Connection=True;";
			services.AddDbContext<WhatsYummyContext>(options => options.UseSqlServer(connection));
		}
    }
}
