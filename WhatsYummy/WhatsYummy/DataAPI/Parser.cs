using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using WhatsYummy.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WhatsYummy.DataAPI
{
    public class Parser
    {
        private readonly WhatsYummyContext _context;
        public Parser(WhatsYummyContext context)
        {
            _context = context;
        }

        public string[] Converte(string s)
        {
            string[] res = new string[3];
            char[] delimiterChars = { ',' };
            string[] outp = s.Split(delimiterChars);

            res[0] = outp[0];

            Regex regex = new Regex(@"[0-9]{4}-[0-9]{3}");
            Match match = regex.Match(s);
            if (match.Success)
            {
                res[1] = match.Value;
            }

            delimiterChars[0] = ' ';
            string[] outp2 = outp[outp.Length - 2].Split(delimiterChars);

            if (outp2.Length > 2) res[2] = outp2[2];
            else res[2] = outp2[1];

            return res;
        }


        public void print(Estabelecimento e){
            Console.WriteLine("Nome: " + e.Nome); 
            Console.WriteLine("Localidade: " + e.Localidade);
            Console.WriteLine("CodigoPostal: " + e.CodigoPostal);
            Console.WriteLine("Rua: " + e.Rua);
            Console.WriteLine("Estado: " + e.Estado);

            foreach(var i in e.Horario){
				Console.WriteLine("Dia: " + i.Dia);
				Console.WriteLine("HA: " + i.HoraAbertura);
				Console.WriteLine("HF: " + i.HoraFecho);
            }
        }


        public async Task Load(string pedido)
        {
            //string key = "AIzaSyCko94hzyMQsWmdYADPFKUTQKIAgtO6sNw";
            string key = "AIzaSyDTqSPvjN5vu1pbbKS8tqTy9D2ehq141rc";
            string sURL = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + pedido + "+in+Braga&key=" + key;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string output = streamReader.ReadToEnd();

            dynamic dynObj = JsonConvert.DeserializeObject(output);

            foreach (var data in dynObj.results)
            {
                string id = data.place_id;
                Console.WriteLine("-------" + id + "-------");

                string restUrl = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + id + "&key=" + key;
                Console.WriteLine(restUrl);
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(restUrl);
                HttpWebResponse response2 = (HttpWebResponse)await request2.GetResponseAsync();

                StreamReader streamReader2 = new StreamReader(response2.GetResponseStream());

                string outputRest = streamReader2.ReadToEnd();

                dynamic restautante = JsonConvert.DeserializeObject(outputRest);
                var rest = restautante.result;

                string[] address = Converte((string)rest.formatted_address);

                Estabelecimento esta = new Estabelecimento();
                esta.Nome = rest.name;
                esta.Localidade = address[2];
                esta.CodigoPostal = address[1];
                esta.Rua = address[0];
                esta.Estado = 1;

                esta.Horario = new List<Horario>();

                if (rest.opening_hours != null)
                {
                    int act = 0;
                    foreach (var dia in rest.opening_hours.periods)
                    {
                        if (act <= Convert.ToInt32((string)dia.open.day))
                        {
                            Horario Hor = new Horario();

                            if (Convert.ToInt32((string)dia.open.day) == 0) Hor.Dia = 7;
                            else Hor.Dia = Convert.ToInt32((string)dia.open.day);

                            int hora = Convert.ToInt32(((string)dia.open.time).Substring(0, 2));
                            int min = Convert.ToInt32(((string)dia.open.time).Substring(2));
                            Hor.HoraAbertura = new TimeSpan(hora, min, 0);

                            hora = Convert.ToInt32(((string)dia.close.time).Substring(0, 2));
                            min = Convert.ToInt32(((string)dia.close.time).Substring(2));
                            Hor.HoraFecho = new TimeSpan(hora, min, 0);

                            esta.Horario.Add(Hor);

                            act = Convert.ToInt32((string)dia.open.day) + 1;
                        }
                    }
                }
                
                break;
            }
        }
    }
}