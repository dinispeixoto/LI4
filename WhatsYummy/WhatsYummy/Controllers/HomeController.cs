using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsYummy.Models;

namespace WhatsYummy.Controllers
{
    public class HomeController : Controller
    {
        private WhatsYummyDBEntities db = new WhatsYummyDBEntities();

        public ActionResult Index(string username="username")
        {
            ViewData["Username"] = username;
            return View();
        }

        
        public ActionResult About(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            ViewData["rua_destino"] = estabelecimento.Rua;
            ViewData["codigo_destino"] = estabelecimento.CodigoPostal;
            ViewData["localidade_destino"] = estabelecimento.Localidade;
            return View();
        }

        [HttpPost]
        public ActionResult Search( string location1, string search )
        {
            string[] tags = search.Split(' ');
            List<Produto> prods = new List<Produto>();

            Dictionary<Produto, int> lista = new Dictionary<Produto, int>();
            
            bool encontrou;

            foreach (var esta in db.Estabelecimento)
            {
                int dist = esta.getDistance(location1);
                
                if (dist <= 25000)
                {
                    foreach (var prod in esta.Produto)
                    {
                        encontrou = false;
                        for(int i = 0;i<tags.Length;i++)
                        {
                            if (encontrou) break;
                            foreach (var prodTag in prod.Tag)
                            {
                                if (tags[i].Equals(prodTag.Nome)){
                                    lista.Add(prod, dist);
                                    prods.Add(prod);
                                    encontrou = true;
                                    ViewData[prod.EstabelecimentoId.ToString()] = esta.Nome;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            ViewData["Distancias"] = lista;
            
            return View(prods.ToList());
        }

        [HttpPost]
        public ActionResult SearchRandom(string location2)
        {
            List<Produto> prods = new List<Produto>();
            Dictionary<Produto, int> lista = new Dictionary<Produto, int>();

            foreach (var esta in db.Estabelecimento)
            {

                int dist = esta.getDistance(location2);

                if (dist <= 25000)
                {
                    foreach (var prod in esta.Produto)
                    {
                        lista.Add(prod, dist);
                        prods.Add(prod);
                    }
                }
            }

            Random rand = new Random();
            int index = rand.Next(0, prods.Count());
            Produto prodRandom = prods.ElementAt(index);

            List<Produto> resList = new List<Produto>();
            resList.Add(prodRandom);

            ViewData["DistanciaRandom"] = lista[prodRandom];
            ViewData["EstabRandom"] = db.Estabelecimento.Find(prodRandom.EstabelecimentoId).Nome;

            return View(resList.ToList());
        }   

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}