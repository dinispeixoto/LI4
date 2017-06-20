using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsYummy.Models;

namespace WhatsYummy.DataAPI
{
    public class Load
    {
        private WhatsYummyDBEntities context = new WhatsYummyDBEntities();

        public void LoadTags()
        {
            if (context.Estabelecimento.Any() && !context.Tag.Any())
            {
                Tag t1 = new Tag{Nome = "pizza", Tipo = "Fast Food"};
                context.Tag.Add(t1);
            Tag t2 = new Tag { Nome = "francesinha", Tipo = "Portuguesa" };
            context.Tag.Add(t2);
            Tag t3 = new Tag { Nome = "bacalhau", Tipo = "Peixe" };
            context.Tag.Add(t3);
            Tag t4 = new Tag { Nome = "nata", Tipo = "Doce" };
            context.Tag.Add(t4);
            Tag t5 = new Tag{Nome = "hambúrguer", Tipo = "Fast Food"};
        context.Tag.Add(t5);
            Tag t6 = new Tag { Nome = "sarrabulho", Tipo = "Portuguesa" };
        context.Tag.Add(t6);
            Tag t7 = new Tag { Nome = "vegetariano", Tipo = "Vegetariano" };
        context.Tag.Add(t7);
            Tag t8 = new Tag { Nome = "gin", Tipo = "Bebida" };
        context.Tag.Add(t8);
            Tag t9 = new Tag { Nome = "sumo", Tipo = "Bebida" };
        context.Tag.Add(t9);
            Tag t10 = new Tag { Nome = "vinho", Tipo = "Bebida" };
        context.Tag.Add(t10);
            Tag t11 = new Tag { Nome = "bolo", Tipo = "Doce" };
        context.Tag.Add(t11);
            Tag t12 = new Tag { Nome = "cheesecake", Tipo = "Doce" };
        context.Tag.Add(t12);
            Tag t13 = new Tag { Nome = "arroz", Tipo = "Portuguesa" };
        context.Tag.Add(t13);
            Tag t14 = new Tag { Nome = "massa", Tipo = "Italiana" };
        context.Tag.Add(t14);
            Tag t15 = new Tag { Nome = "alface", Tipo = "Legumes" };
        context.Tag.Add(t15);
            Tag t16 = new Tag { Nome = "salada", Tipo = "Legumes" };
        context.Tag.Add(t16);
            Tag t17 = new Tag { Nome = "tomate", Tipo = "Legumes" };
        context.Tag.Add(t17);
            Tag t18 = new Tag { Nome = "cabidela", Tipo = "Portuguesa" };
        context.Tag.Add(t18);
            Tag t19 = new Tag { Nome = "chocolate", Tipo = "Doce" };
        context.Tag.Add(t19);
            Tag t20 = new Tag { Nome = "sopa", Tipo = "Legumes" };
        context.Tag.Add(t20);
            Tag t21 = new Tag { Nome = "whisky", Tipo = "Bebida" };
        context.Tag.Add(t21);

            Produto p1 = new Produto { EstabelecimentoId = 1, Nome = "Pizza Havaina", Descricao = " ", Preco = (decimal)7.75, Visitas = 0, Foto = " " };
                p1.Tag.Add(t1);
        context.Produto.Add(p1);

        Produto p2 = new Produto { EstabelecimentoId = 1, Nome = "Francesinha com ovo", Descricao = " ", Preco = (decimal)9.50, Visitas = 0, Foto = " " };
        p2.Tag.Add(t2);
            context.Produto.Add(p2);

            Produto p3 = new Produto { EstabelecimentoId = 2, Nome = "Francesinha Vegetariana", Descricao = " ", Preco = (decimal)9.50, Visitas = 0, Foto = " " };
        p3.Tag.Add(t2);
            p3.Tag.Add(t7);
            context.Produto.Add(p3);

            Produto p4 = new Produto { EstabelecimentoId = 2, Nome = "Bolo de Bolacha", Descricao = " ", Preco = (decimal)5.00, Visitas = 0, Foto = " " };
        p4.Tag.Add(t11);
            context.Produto.Add(p4);

            Produto p5 = new Produto { EstabelecimentoId = 3, Nome = "Sopa de Legumes", Descricao = " ", Preco = (decimal)2.50, Visitas = 0, Foto = " " };
        p5.Tag.Add(t20);
            p5.Tag.Add(t17);
            context.Produto.Add(p5);

            Produto p6 = new Produto { EstabelecimentoId = 3, Nome = "Salada especial", Descricao = " ", Preco = (decimal)4.30, Visitas = 0, Foto = " " };
        p6.Tag.Add(t7);
            p6.Tag.Add(t16);
            p6.Tag.Add(t15);
            p6.Tag.Add(t17);
            context.Produto.Add(p6);

            Produto p7 = new Produto { EstabelecimentoId = 3, Nome = "Mousse de Chocolate", Descricao = " ", Preco = (decimal)2.40, Visitas = 0, Foto = " " };
        p7.Tag.Add(t19);
            p7.Tag.Add(t11);
            context.Produto.Add(p7);

            Produto p8 = new Produto { EstabelecimentoId = 4, Nome = "Bolo de Chocolate", Descricao = " ", Preco = (decimal)3.3, Visitas = 0, Foto = " " };
        p8.Tag.Add(t11);
            p8.Tag.Add(t19);
            context.Produto.Add(p8);

            Produto p9 = new Produto { EstabelecimentoId = 4, Nome = "Pizza à la Chef", Descricao = " ", Preco = (decimal)10.85, Visitas = 0, Foto = " " };
        p9.Tag.Add(t1);
            p9.Tag.Add(t17);
            context.Produto.Add(p9);

            Produto p10 = new Produto { EstabelecimentoId = 5, Nome = "Pizza especial", Descricao = " ", Preco = (decimal)13.20, Visitas = 0, Foto = " " };
        p10.Tag.Add(t1);
            p10.Tag.Add(t17);
            context.Produto.Add(p10);

            Produto p11 = new Produto { EstabelecimentoId = 5, Nome = "Pizza com ovo", Descricao = " ", Preco = (decimal)11.90, Visitas = 0, Foto = " " };
        p11.Tag.Add(t1);
            p11.Tag.Add(t17);
            context.Produto.Add(p11);

            Produto p12 = new Produto { EstabelecimentoId = 5, Nome = "Pizza Vegetariana", Descricao = " ", Preco = (decimal)7.50, Visitas = 0, Foto = " " };
        p12.Tag.Add(t1);
            p12.Tag.Add(t17);
            p12.Tag.Add(t7);
            context.Produto.Add(p12);

            Produto p13 = new Produto { EstabelecimentoId = 6, Nome = "Massa Italiana", Descricao = " ", Preco = (decimal)6.80, Visitas = 0, Foto = " " };
        p13.Tag.Add(t14);
            p13.Tag.Add(t17);
            p13.Tag.Add(t16);
            context.Produto.Add(p13);

            Produto p14 = new Produto { EstabelecimentoId = 6, Nome = "Massa à bolonhesa", Descricao = " ", Preco = (decimal)5.45, Visitas = 0, Foto = " " };
        p14.Tag.Add(t17);
            p14.Tag.Add(t16);
            context.Produto.Add(p14);

            Produto p15 = new Produto { EstabelecimentoId = 6, Nome = "Massa vegetariana", Descricao = " ", Preco = (decimal)6.85, Visitas = 0, Foto = " " };
        p15.Tag.Add(t14);
            p15.Tag.Add(t16);
            p15.Tag.Add(t7);
            p15.Tag.Add(t17);
            p15.Tag.Add(t15);
            context.Produto.Add(p15);

            Produto p16 = new Produto { EstabelecimentoId = 7, Nome = "Bacalhau à Braga", Descricao = " ", Preco = (decimal)13.50, Visitas = 0, Foto = " " };
        p16.Tag.Add(t3);
            context.Produto.Add(p16);

            Produto p17 = new Produto { EstabelecimentoId = 7, Nome = "Bacalhau à Braz", Descricao = " ", Preco = (decimal)11.20, Visitas = 0, Foto = " " };
        p17.Tag.Add(t3);
                context.Produto.Add(p17);

            Produto p18 = new Produto { EstabelecimentoId = 7, Nome = "Cheesecake de bolacha", Descricao = " ", Preco = (decimal)3.40, Visitas = 0, Foto = " " };
        p18.Tag.Add(t12);
            context.Produto.Add(p18);

            Produto p19 = new Produto { EstabelecimentoId = 8, Nome = "Nata", Descricao = " ", Preco = (decimal)0.90, Visitas = 0, Foto = " " };
        p19.Tag.Add(t4);
            context.Produto.Add(p19);

            Produto p20 = new Produto { EstabelecimentoId = 8, Nome = "Gin tónico", Descricao = " ", Preco = (decimal)3.50, Visitas = 0, Foto = " " };
        p20.Tag.Add(t8);
            context.Produto.Add(p20);

            Produto p21 = new Produto { EstabelecimentoId = 8, Nome = "Sumo de laranja natural", Descricao = " ", Preco = (decimal)3.00, Visitas = 0, Foto = " " };
        p21.Tag.Add(t9);
            context.Produto.Add(p21);

            Produto p22 = new Produto { EstabelecimentoId = 9, Nome = "Sumo de ananás natural", Descricao = " ", Preco = (decimal)3.00, Visitas = 0, Foto = " " };
        p22.Tag.Add(t9);
            context.Produto.Add(p22);

            Produto p23 = new Produto { EstabelecimentoId = 9, Nome = "Sumo de morango natural", Descricao = " ", Preco = (decimal)3.20, Visitas = 0, Foto = " " };
        p23.Tag.Add(t9);
            context.Produto.Add(p23);

            Produto p24 = new Produto { EstabelecimentoId = 9, Nome = "Sumo de framboesa natural", Descricao = " ", Preco = (decimal)3.10, Visitas = 0, Foto = " " };
        p24.Tag.Add(t9);
            context.Produto.Add(p24);

            Produto p25 = new Produto { EstabelecimentoId = 10, Nome = "Whisky cola", Descricao = " ", Preco = (decimal)4.50, Visitas = 0, Foto = " " };
        p25.Tag.Add(t21);
            context.Produto.Add(p25);

            Produto p26 = new Produto { EstabelecimentoId = 10, Nome = "Vinho do Porto", Descricao = " ", Preco = (decimal)8.00, Visitas = 0, Foto = " " };
        p26.Tag.Add(t10);
            context.Produto.Add(p26);

            Produto p27 = new Produto { EstabelecimentoId = 10, Nome = "Vinho Verde de Ponte de Lima", Descricao = " ", Preco = (decimal)6.50, Visitas = 0, Foto = " " };
        p27.Tag.Add(t10);
            context.Produto.Add(p27);

            Produto p28 = new Produto { EstabelecimentoId = 11, Nome = "Vinho tinto Montevelho", Descricao = " ", Preco = (decimal)7.80, Visitas = 0, Foto = " " };
        p28.Tag.Add(t10);
            context.Produto.Add(p28);

            Produto p29 = new Produto { EstabelecimentoId = 11, Nome = "Francesinha especial", Descricao = " ", Preco = (decimal)9.00, Visitas = 0, Foto = " " };
        p29.Tag.Add(t2);
            context.Produto.Add(p29);

            Produto p30 = new Produto { EstabelecimentoId = 12, Nome = "Francesinha de legumes", Descricao = " ", Preco = (decimal)8.50, Visitas = 0, Foto = " " };
        p30.Tag.Add(t2);
            p30.Tag.Add(t15);
            p30.Tag.Add(t17);
            p30.Tag.Add(t7);
            context.Produto.Add(p30);

            Produto p31 = new Produto { EstabelecimentoId = 12, Nome = "Hambúrguer simples", Descricao = " ", Preco = (decimal)3.50, Visitas = 0, Foto = " " };
        p31.Tag.Add(t5);
            p31.Tag.Add(t15);
            p31.Tag.Add(t17);
            context.Produto.Add(p31);        

            Produto p32 = new Produto { EstabelecimentoId = 12, Nome = "Hambúrguer especial", Descricao = " ", Preco = (decimal)4.50, Visitas = 0, Foto = " " };
        p32.Tag.Add(t5);
            p32.Tag.Add(t15);
            p32.Tag.Add(t17);
            context.Produto.Add(p32); 

            Produto p33 = new Produto { EstabelecimentoId = 13, Nome = "Hambúrguer vegetariano", Descricao = " ", Preco = (decimal)4.00, Visitas = 0, Foto = " " };
        p33.Tag.Add(t5);
            p33.Tag.Add(t15);
            p33.Tag.Add(t17);
            p33.Tag.Add(t7);
            context.Produto.Add(p33); 

            Produto p34 = new Produto { EstabelecimentoId = 13, Nome = "Francesinha à rei", Descricao = " ", Preco = (decimal)15.00, Visitas = 0, Foto = " " };
        p34.Tag.Add(t2);  
            context.Produto.Add(p34);  

            Produto p35 = new Produto { EstabelecimentoId = 14, Nome = "Francesinha gourmet", Descricao = " ", Preco = (decimal)20.00, Visitas = 0, Foto = " " };
        p35.Tag.Add(t2);  
            context.Produto.Add(p35); 

            Produto p36 = new Produto { EstabelecimentoId = 14, Nome = "Whisky simples", Descricao = " ", Preco = (decimal)5.00, Visitas = 0, Foto = " " };
        p36.Tag.Add(t21);  
            context.Produto.Add(p36); 

            Produto p37 = new Produto { EstabelecimentoId = 15, Nome = "Whisky escocês", Descricao = " ", Preco = (decimal)4.50, Visitas = 0, Foto = " " };
        p37.Tag.Add(t21);  
            context.Produto.Add(p37); 

            Produto p38 = new Produto { EstabelecimentoId = 15, Nome = "Sumo de amora", Descricao = " ", Preco = (decimal)1.50, Visitas = 0, Foto = " " };
        p38.Tag.Add(t9);  
            context.Produto.Add(p38); 

            Produto p39 = new Produto { EstabelecimentoId = 16, Nome = "Francesinha sem ovo", Descricao = " ", Preco = (decimal)10.00, Visitas = 0, Foto = " " };
        p39.Tag.Add(t2);  
            context.Produto.Add(p39); 

            Produto p40 = new Produto { EstabelecimentoId = 16, Nome = "Francesinha de marisco", Descricao = " ", Preco = (decimal)15.00, Visitas = 0, Foto = " " };
        p40.Tag.Add(t2);  
            context.Produto.Add(p40); 

            Produto p41 = new Produto { EstabelecimentoId = 16, Nome = "Creme de Legumes", Descricao = " ", Preco = (decimal)2.00, Visitas = 0, Foto = " " };
        p41.Tag.Add(t20); 
            p41.Tag.Add(t7); 
            context.Produto.Add(p41); 

            Produto p42 = new Produto { EstabelecimentoId = 17, Nome = "Sopa de tomate", Descricao = " ", Preco = (decimal)3.00, Visitas = 0, Foto = " " };
        p42.Tag.Add(t20);
            p42.Tag.Add(t7);
            p42.Tag.Add(t17);  
            context.Produto.Add(p42); 

            Produto p43 = new Produto { EstabelecimentoId = 17, Nome = "Francesinha de peixe", Descricao = " ", Preco = (decimal)9.00, Visitas = 0, Foto = " " };
        p43.Tag.Add(t2);  
            context.Produto.Add(p43); 

            Produto p44 = new Produto { EstabelecimentoId = 18, Nome = "Francesinha de verão", Descricao = " ", Preco = (decimal)13.90, Visitas = 0, Foto = " " };
        p44.Tag.Add(t2);  
            context.Produto.Add(p44); 

            Produto p45 = new Produto { EstabelecimentoId = 18, Nome = "Francesinha à moda do Porto", Descricao = " ", Preco = (decimal)8.70, Visitas = 0, Foto = " " };
        p45.Tag.Add(t2);  
            context.Produto.Add(p45); 

            Produto p46 = new Produto { EstabelecimentoId = 19, Nome = "Arroz de Sarrabulho", Descricao = " ", Preco = (decimal)12.75, Visitas = 0, Foto = " " };
        p46.Tag.Add(t6); 
            p46.Tag.Add(t13); 
            context.Produto.Add(p46); 

            Produto p47 = new Produto { EstabelecimentoId = 19, Nome = "Arroz de Cabidela", Descricao = " ", Preco = (decimal)12.75, Visitas = 0, Foto = " " };
        p47.Tag.Add(t6); 
            p47.Tag.Add(t13); 
            context.Produto.Add(p47); 

            Produto p48 = new Produto { EstabelecimentoId = 20, Nome = "Hambúrguer gigante", Descricao = " ", Preco = (decimal)16.80, Visitas = 0, Foto = " " };
        p48.Tag.Add(t5); 
            context.Produto.Add(p48); 

            Produto p49 = new Produto { EstabelecimentoId = 20, Nome = "Mini-Hambúrguer", Descricao = " ", Preco = (decimal)5.00, Visitas = 0, Foto = " " };
        p49.Tag.Add(t5); 
            context.Produto.Add(p49); 

            Produto p50 = new Produto { EstabelecimentoId = 20, Nome = "Cheesecake de morango", Descricao = " ", Preco = (decimal)3.70, Visitas = 0, Foto = " " };
        p50.Tag.Add(t12); 
            context.Produto.Add(p50); 

            context.SaveChanges();
            }
              
        }
        }
    }
