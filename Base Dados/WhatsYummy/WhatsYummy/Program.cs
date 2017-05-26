using System;
using System.Data.SqlClient;
using WhatsYummy.DAL;
using WhatsYummy.Models;

namespace WhatsYummy
{

    public class Program{
        static void Main(string[] args){

			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = "localhost";   // update me
			builder.UserID = "sa";              // update me
			builder.Password = "ASN23FK1a.";      // update me
			builder.InitialCatalog = "WhatsYummy";

            using (WhatsYummyContext context = new WhatsYummyContext(builder.ConnectionString)){

                // Adicionar utilizador
                try
                {

                    Tag tag1 = new Tag { id = 1, tipo = "cenas", nome = "A", };
                    Tag tag2 = new Tag { id = 2, tipo = "cenas", nome = "B", };
                    Tag tag3 = new Tag { id = 3, tipo = "cenas", nome = "C", };

                    context.Tags.Add(tag1);
                    context.SaveChanges();
                    context.Tags.Add(tag2);
                    context.SaveChanges();
                    context.Tags.Add(tag3);
                    context.SaveChanges();

                   

                    Utilizador user = new Utilizador { email = "nadagmailcom", dataNascimento = "10/10/20", 
                                                       nome = "LOL", password = "33", username = "Anna", 
                                                       foto = "naoExiste", id = 1, admin = false };
                    
                    context.Utilizadores.Add(user);
                    context.SaveChanges();

					Preferencia pref = new Preferencia { tagid = 1, utilizadorid = 1 };

                    context.preferencias.Add(pref);
                    context.SaveChanges();

                }
                catch(Exception e){
                    Console.WriteLine(e.ToString());
                }
				// Adicionar produto
				/*Produto produto = new Produto{ id = 1, nome = "Ze", descricao = "cenas", preco = 3.3f, visitas = 2};
				context.Produtos.Add(produto);
				context.SaveChanges();*/

                /**/

                /*user.preferencias.Add(tag1);
				context.SaveChanges();*/

            }
        }
    }
}
