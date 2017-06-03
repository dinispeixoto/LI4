using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WhatsYummyApp.Models;

namespace WhatsYummyApp.Migrations
{
    [DbContext(typeof(WhatsYummyAppContext))]
    [Migration("20170603170331_AddEstabelecimentos")]
    partial class AddEstabelecimentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhatsYummyApp.Models.Estabelecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoPostal");

                    b.Property<string>("Descricao");

                    b.Property<int>("Estado");

                    b.Property<string>("Localidade");

                    b.Property<string>("Nome");

                    b.Property<int>("Proprietario");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Estabelecimento");
                });
        }
    }
}
