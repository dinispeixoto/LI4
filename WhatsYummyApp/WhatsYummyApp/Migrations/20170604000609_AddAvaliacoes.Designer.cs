using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WhatsYummyApp.Models;

namespace WhatsYummyApp.Migrations
{
    [DbContext(typeof(WhatsYummyAppContext))]
    [Migration("20170604000609_AddAvaliacoes")]
    partial class AddAvaliacoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhatsYummyApp.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Autor");

                    b.Property<float>("Classificacao");

                    b.Property<string>("Comentario");

                    b.HasKey("Id");

                    b.ToTable("Avaliacao");
                });

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

            modelBuilder.Entity("WhatsYummyApp.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<float>("Preco");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });
        }
    }
}
